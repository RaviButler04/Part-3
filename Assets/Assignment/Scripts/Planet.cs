using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    //gravity maths floats
    public float gravitationalPull = 10f;
    public static float gravitationalConstant = 2f;

    //reference the transform of the planet to get the scale
    Transform planetSize;

    //planet size
    float size;

    //number that, when reached, will trigger planet destruction
    float destroyNum;

    //number to multiply size by for destruction calculation
    public static float sizeMultiplier = 150f;

    //counter for how many asteroids have collided
    float asteroidCounter = 0f;

    //float for shrinkrate
    float shrinkRate = 0.000000000001f;

    //get reference to impact object
    public GameObject impact;

    //get reference to explosion object
    public GameObject explosion;

    //gameobject to manipulate instantiated impact
    protected  GameObject instantiatedImpact;

    // List to hold attracted objects
    public List<GameObject> attractedObjects = new List<GameObject>();

    void Start()
    {
        //get planet transform and scale
        planetSize = GetComponent<Transform>();
        size = planetSize.localScale.x;

        //calculate how many asteroids need to collide with the planet before it explodes - based off of planet scale.
        destroyNum = Mathf.Round(size * sizeMultiplier);
    }

    protected void Update()
    {
        //trigger explode function after number of asteroids is equal to the destroy number
        if(asteroidCounter >= destroyNum)
        {
            explode();
        }
    }

    void FixedUpdate()
    {
        //attract asteroids
        gravity();
    }

    //function to add asteroids to the list
    public void AddAsteroidToList(GameObject instantiatedAsteroid)
    {
        attractedObjects.Add(instantiatedAsteroid);
    }

    public void gravity()
    {
        //attract each object in list
        foreach (var attractedObject in attractedObjects)
        {
            //check that there is an object in the list
            if (attractedObject != null)
            {
                //get rigidbody of each onject in list
                Rigidbody2D attractedRigidbody = attractedObject.GetComponent<Rigidbody2D>();

                //check to make sure list is not empty
                if (attractedRigidbody != null)
                {
                    //get direction from planet to asteroid
                    Vector2 direction = (transform.position - attractedObject.transform.position).normalized;

                    //get distance from planet to asteroid
                    float distance = Vector2.Distance(transform.position, attractedObject.transform.position);

                    //gravity math used is Newton's Law of Universal Gravitation. I used this video: https://youtu.be/fy-LcFZTTZU?si=I9HEB0xc_EnDR24e. Also this: https://www.physicsclassroom.com/class/circles/Lesson-3/Newton-s-Law-of-Universal-Gravitation
                    float forceMagnitude = gravitationalConstant * (attractedRigidbody.mass * GetComponent<Rigidbody2D>().mass) / Mathf.Pow(distance, 2);
                    Vector2 force = direction * forceMagnitude * gravitationalPull;

                    //add caluclated gravitational force to each asteroid
                    attractedRigidbody.AddForce(force);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //attractedObjects.Remove(collision.gameObject);
        Destroy(collision.gameObject);

        //increment counter for planet destruction
        asteroidCounter++;

        //call asteroid collision function
        AsteroidCollision(collision);
    }

    //start explosion coroutine
    private void explode()
    {
        StartCoroutine(planetExplosion());
    }

    public virtual void AsteroidCollision(Collision2D collision)
    {
        //instantiate impact object
        instantiatedImpact = Instantiate(impact, collision.gameObject.transform.position, Quaternion.identity);
    }

    //explosion coroutine
    IEnumerator planetExplosion()
    {
        while(transform.localScale.x > 0)
        {
            //exponentially shrink planet
            Vector3 localScale = transform.localScale;
            localScale.x = localScale.x - shrinkRate;
            localScale.y = localScale.y - shrinkRate;
            transform.localScale = localScale;
            shrinkRate = shrinkRate + 0.00000000001f;
            yield return null;
        }
        //instantiate explosion object
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        yield return null;
        //destroy self
        Destroy(gameObject);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    // Start is called before the first frame update
    public float gravitationalPull = 10f;
    public static float gravitationalConstant = 2f;
    public Transform planetSize;
    float size;
    float destroyNum;
    public static float sizeMultiplier = 100f;
    float asteroidCounter = 0f;

    // List to hold attracted objects
    public List<GameObject> attractedObjects = new List<GameObject>();

    void Start()
    {
        planetSize = GetComponent<Transform>();
        size = planetSize.localScale.x;
        destroyNum = Mathf.Round(size * sizeMultiplier);
    }

    void Update()
    {
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
            if (attractedObject != null)
            {
                //get rigidbody of each onject in list
                Rigidbody2D attractedRigidbody = attractedObject.GetComponent<Rigidbody2D>();

                //check to make sure list is not empty
                if (attractedRigidbody != null)
                {
                    //get direction from planet to asteroid
                    Vector2 direction = (transform.position - attractedObject.transform.position).normalized;

                    //get distancce from planet to asteroid
                    float distance = Vector2.Distance(transform.position, attractedObject.transform.position);

                    //gravity math used is Newton's Law of Universal Gravitation. Found all of this using a gravity calculator online
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

        asteroidCounter++;
    }

    private void explode()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHandler : MonoBehaviour
{
    public float gravitationalPull = 10f;
    public float gravitationalConstant = 0.1f;

    // List to hold attracted objects
    public List<GameObject> attractedObjects = new List<GameObject>();

    void FixedUpdate()
    {
        //attract each object in list
        foreach (var attractedObject in attractedObjects)
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

    //function to add asteroids to the list
    public void AddAsteroidToList(GameObject instantiatedAsteroid)
    {
        attractedObjects.Add(instantiatedAsteroid);
    }
}

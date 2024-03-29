using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHandler : MonoBehaviour
{
    //reference asteroid prefab
    public GameObject asteroid;

    //make list of all the planets that will attract the asteroid
    public List<GravityHandler> planets = new List<GravityHandler>();

    // Update is called once per frame
    void Update()
    {
        //if player clicks, create asteroid at their mouse location
        if (Input.GetMouseButtonDown(0))
        {
            //get location of mouse position
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //instantiate asteroid and make it a gameobject variable
            GameObject instantiatedAsteroid = Instantiate(asteroid, mousePosition, Quaternion.identity);

            //add the instantiated prefab to each planet's list of attracted object
            foreach (var gravityHandler in planets)
            {
                gravityHandler.AddAsteroidToList(instantiatedAsteroid);
            }
        }
    }
}

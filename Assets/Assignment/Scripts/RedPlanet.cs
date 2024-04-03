using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlanet : Planet
{
    //float for tracking number of asteroids collided with
    float asteroidNum = 0;

    //override asteroid collision function.
    public override void AsteroidCollision(Collision2D collision)
    {
        base.AsteroidCollision(collision);

        //get sprite renderer of instantiated impact
        SpriteRenderer sr = instantiatedImpact.GetComponent<SpriteRenderer>();

        //change color to red
        sr.color = Color.red;

        //increment asteroid counter
        asteroidNum++;
    }

    //trigger asteroid interaction if hit by 6 asteroids
    void Update()
    {
        base.Update();
        if(asteroidNum >= 6)
        {
            asteroidInteraction();
        }
    }

    //start shake coroutine
    private void asteroidInteraction()
    {
        StartCoroutine(shake());
    }

    //shake the planet back and forth
    IEnumerator shake()
    {
        //reset asteroid num so that it doesn't keep shaking
        asteroidNum = 0;

        //variables for initial positions
        float initialY = transform.position.y;
        float initialZ = transform.position.z;
        float initialPos = transform.position.x;

        //variables for right and left positions
        float rightPos = initialPos + 0.5f;
        float leftPos = initialPos - 0.5f;

        //move right
        while (transform.position.x < rightPos)
        {
            transform.position = new Vector3(transform.position.x + 0.01f, initialY, initialZ);
            yield return null;
        }

        //move left
        while (transform.position.x > leftPos)
        {
            transform.position = new Vector3(transform.position.x - 0.01f, initialY, initialZ);
            yield return null;
        }

        //move back to center
        while (transform.position.x < initialPos)
        {
            transform.position = new Vector3(transform.position.x + 0.01f, initialY, initialZ);
            yield return null;
        }
    }

}

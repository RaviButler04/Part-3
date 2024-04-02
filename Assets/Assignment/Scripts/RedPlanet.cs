using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlanet : Planet
{
    float asteroidNum = 0;

    public override void AsteroidCollision(Collision2D collision)
    {
        base.AsteroidCollision(collision);

        //get sprite renderer of instantiated impact
        SpriteRenderer sr = base.instantiatedImpact.GetComponent<SpriteRenderer>();

        //change color to red
        sr.color = Color.red;
        asteroidNum++;
    }

    void Update()
    {
        base.Update();
        if(asteroidNum >= 6)
        {
            asteroidInteraction();
        }
    }

    private void asteroidInteraction()
    {
        StartCoroutine(shake());
    }

    IEnumerator shake()
    {
        asteroidNum = 0;
        float initialY = transform.position.y;
        float initialZ = transform.position.z;

        float initialPos = transform.position.x;
        float rightPos = initialPos + 0.5f;
        float leftPos = initialPos - 0.5f;

        while (transform.position.x < rightPos)
        {
            transform.position = new Vector3(transform.position.x + 0.01f, initialY, initialZ);
            yield return null;
        }
        //yield return new WaitForSeconds(3);
        while (transform.position.x > leftPos)
        {
            transform.position = new Vector3(transform.position.x - 0.01f, initialY, initialZ);
            yield return null;
        }
        while (transform.position.x < initialPos)
        {
            transform.position = new Vector3(transform.position.x + 0.01f, initialY, initialZ);
            yield return null;
        }
        StopCoroutine(shake());
    }

}

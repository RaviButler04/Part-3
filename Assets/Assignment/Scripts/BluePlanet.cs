using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlanet : Planet
{
    //float for tracking number of asteroids collided with
    float asteroidNum = 0;

    //colour for impact animation
    Color blue = new Color(0, 255, 250);

    //changed colour
    static Color changedColor = new Color(224, 131, 0);

    //public Sprite newPlanetSprite;
    static SpriteRenderer planetSR;

    //override asteroid collision function.
    public override void AsteroidCollision(Collision2D collision)
    {
        base.AsteroidCollision(collision);

        //get sprite renderer of instantiated impact
        SpriteRenderer sr = base.instantiatedImpact.GetComponent<SpriteRenderer>();
        planetSR = GetComponent<SpriteRenderer>();

        //change color to blue
        sr.color = blue;

        //increment asteroid counter
        asteroidNum++;
    }

    //change colour if hit by 9 asteroids
    void Update()
    {
        base.Update();
        if (asteroidNum >= 9)
        {
            changeColor();
        }
    }

    //unique change colour function
    private static void changeColor()
    {
        planetSR.color = changedColor;
    }
}

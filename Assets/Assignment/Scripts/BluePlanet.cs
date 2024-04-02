using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlanet : Planet
{
    float asteroidNum = 0;
    Color blue = new Color(0, 255, 250);
    Color changedColor = new Color(224, 131, 0);
    //public Sprite newPlanetSprite;

    public override void AsteroidCollision(Collision2D collision)
    {
        base.AsteroidCollision(collision);

        //get sprite renderer of instantiated impact
        SpriteRenderer sr = base.instantiatedImpact.GetComponent<SpriteRenderer>();

        //change color to blue
        sr.color = blue;
        asteroidNum++;
    }

    void Update()
    {
        base.Update();
        if (asteroidNum >= 9)
        {
            changeColor();
        }
    }

    private void changeColor()
    {
        SpriteRenderer planetSR = GetComponent<SpriteRenderer>();
        planetSR.color = changedColor;
        //planetSR.sprite = newPlanetSprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlanet : Planet
{
    Color blue = new Color(0, 255, 250);

    public override void AsteroidCollision(Collision2D collision)
    {
        base.AsteroidCollision(collision);

        //get sprite renderer of instantiated impact
        SpriteRenderer sr = base.instantiatedImpact.GetComponent<SpriteRenderer>();

        //change color to blue
        sr.color = blue;
    }
}

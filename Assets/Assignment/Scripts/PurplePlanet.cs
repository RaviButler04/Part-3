using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePlanet : Planet
{
    //Color purple = new Color(204, 151, 255);
    public override void AsteroidCollision(Collision2D collision)
    {
        base.AsteroidCollision(collision);

        //get sprite renderer of instantiated impact
        //SpriteRenderer sr = base.instantiatedImpact.GetComponent<SpriteRenderer>();
        //change color to red
        //sr.color = purple;
    }
}

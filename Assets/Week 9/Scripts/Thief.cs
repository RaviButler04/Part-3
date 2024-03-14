using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public TextMeshProUGUI textMeshProUGUI;

    protected override void Attack()
    {
        destination = transform.position;
        base.Attack();
        Instantiate(daggerPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(daggerPrefab, spawnPoint2.position, spawnPoint2.rotation);
        //destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //dash
        if (transform.localScale.x == -1)
        {
            destination.x += 10;
            speed = 8;
        }
        if (transform.localScale.x == 1)
        {
            destination.x -= 10;
            speed = 8;
        }
        speed = 3;
    }

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    public override void Selected(bool value)
    {
        base.Selected(value);
        if (isSelected == true)
        {
            textMeshProUGUI.text = "Thief";
        }
    }

    //public void UIStuff()
    //{
    //    if(isSelected == true)
    //    {
    //        textMeshProUGUI.text = "Thief";
    //    }
    //}
}

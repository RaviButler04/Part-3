using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Archer : Villager
{
    public GameObject arrowPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI textMeshProUGUI;

    protected override void Attack()
    {
        destination = transform.position;
        base.Attack();
        Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public override ChestType CanOpen()
    {
        return ChestType.Archer;
    }

    public override void Selected(bool value)
    {
        base.Selected(value);
        if (isSelected == true)
        {
            textMeshProUGUI.text = "Archer";
        }
    }
}

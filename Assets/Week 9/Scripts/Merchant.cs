using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Merchant : Villager
{
    public TextMeshProUGUI textMeshProUGUI;

    public override ChestType CanOpen()
    {
        return ChestType.Merchant;
    }

    public override void Selected(bool value)
    {
        base.Selected(value);
        if (isSelected == true)
        {
            textMeshProUGUI.text = "Merchant";
        }
    }
}

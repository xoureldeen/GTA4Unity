using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_TANM : IDE_Item
{
    private int gameType;

    public Item_TANM(int gameType)
    {
        this.gameType = gameType;
    }

    public override void read(string line)
    {
        Debug.Log($"{GetType().Name} not supported yet.");
    }
}

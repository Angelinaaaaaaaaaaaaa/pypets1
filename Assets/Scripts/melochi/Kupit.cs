using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kupit : MonoBehaviour
{
    public void kupitEda()
    {
        if (Memory.coins >= 10)
        {
            Memory.coins -= 10;
            Memory.food += 1;
        }
        else
        {
            Debug.Log("NoMoney");
        }
    }
    public void kupitLek()
    {
        if (Memory.coins >= 100)
        {
            Memory.coins -= 100;
            Memory.water += 1;
        }
        else
        {
            Debug.Log("NoMoney");
        }
    }
}

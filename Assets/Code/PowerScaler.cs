using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScaler : MonoBehaviour
{
    static protected int PowerUsing;
    static public float FPowerLeft;
    void Start()
    {
        PowerUsing = 1;
        FPowerLeft = 100;
    }
}

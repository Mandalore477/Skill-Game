using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class IceResistance : Resistance
    {
        void Start()
        {
            skillNameLow_s = "Frost Resistance";
            skillNameMid_s = "Ice Resistance";
            skillNameHigh_s = "Glacial Resistance";
            skillNameMax_s = "Glacial Immunity";
            SetResistance();
        }

    }








}
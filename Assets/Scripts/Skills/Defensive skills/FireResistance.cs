using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class FireResistance : Resistance
    {

        void Start()
        {
            skillNameLow_s = "Flame Resistance";
            skillNameMid_s = "Fire Resistance";
            skillNameHigh_s = "Inferno Resistance";
            skillNameMax_s = "Inferno Immunity";
            SetResistance();
        }

    }





}
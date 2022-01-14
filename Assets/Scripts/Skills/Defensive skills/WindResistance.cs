using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class WindResistance : Resistance
    {
        // Start is called before the first frame update
        void Start()
        {
            skillNameLow_s = "Wind Resistance";
            skillNameMid_s = "Gale Resistance";
            skillNameHigh_s = "Tempest Resistance";
            skillNameMax_s = "Tempest Immunity";
            SetResistance();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }











}
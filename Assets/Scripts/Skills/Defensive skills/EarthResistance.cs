using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class EarthResistance : Resistance
    {
        // Start is called before the first frame update
        void Start()
        {
            skillNameLow_s = "Dirt Resistance";
            skillNameMid_s = "Earth Resistance";
            skillNameHigh_s = "Terra Resistance";
            skillNameMax_s = "Terra Immunity";
            SetResistance();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }












}
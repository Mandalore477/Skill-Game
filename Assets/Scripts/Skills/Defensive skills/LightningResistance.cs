using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skills
{
    public class LightningResistance : Resistance
    {
        // Start is called before the first frame update
        void Start()
        {
            skillNameLow_s = "Spark Resistance";
            skillNameMid_s = "Lightning Resistance";
            skillNameHigh_s = "Storm Resistance";
            skillNameMax_s = "Storm Immunity";
            SetResistance();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }












}

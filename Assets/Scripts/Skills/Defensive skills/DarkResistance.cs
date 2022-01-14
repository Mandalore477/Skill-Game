using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class DarkResistance : Resistance
    {
        
        // Start is called before the first frame update
        void Start()
        {
            skillNameLow_s = "Shadow Resistance";
            skillNameMid_s = "Dark Resistance";
            skillNameHigh_s = "Tenebrous Resistance";
            skillNameMax_s = "Tenebrous Immunity";
            SetResistance();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }











}
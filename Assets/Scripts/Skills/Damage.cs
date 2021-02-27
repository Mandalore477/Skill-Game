using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public float fireDmg_f;
    public float lightningDmg_f;
    public float iceDmg_f;
    public float earthDmg_f;
    public float windDmg_f;
    public float darkDmg_f;


    public Damage(float fireDmg, float lightningDmg, float iceDmg, float earthDmg, float windDmg, float darkDmg)
    {
        fireDmg_f = fireDmg;
        lightningDmg_f = lightningDmg;
        iceDmg_f = iceDmg;
        earthDmg_f = earthDmg;
        windDmg_f = windDmg;
        darkDmg_f = darkDmg;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

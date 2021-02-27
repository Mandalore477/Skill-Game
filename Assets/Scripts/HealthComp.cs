using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skills;

public class HealthComp : MonoBehaviour
{
    [SerializeField] float maxHealth_f;
    [SerializeField] float health_f;
    [SerializeField] float totalDamage_f;

    [SerializeField] HealthRegen HealthRegen;
    [SerializeField] FireResistance FireResistance;
    [SerializeField] IceResistance IceResistance;
    [SerializeField] LightningResistance LightningResistance;
    [SerializeField] EarthResistance EarthResistance;
    [SerializeField] WindResistance WindResistance;
    [SerializeField] DarkResistance DarkResistance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health_f < maxHealth_f && HealthRegen.IsRegen())
        {
            health_f = Mathf.Clamp( health_f + HealthRegen.Regen_f(), 0, maxHealth_f);
        }else if (health_f >= maxHealth_f && HealthRegen.IsRegen())
        {
            HealthRegen.StopRegen();
        }
    }

    public void TakeDamage(Damage damage)
    {
        totalDamage_f = 0;
        totalDamage_f += FireResistance.Mitigation_f(damage.fireDmg_f);
        totalDamage_f += IceResistance.Mitigation_f(damage.iceDmg_f);
        totalDamage_f += LightningResistance.Mitigation_f(damage.lightningDmg_f);
        totalDamage_f += EarthResistance.Mitigation_f(damage.earthDmg_f);
        totalDamage_f += WindResistance.Mitigation_f(damage.windDmg_f);
        totalDamage_f += DarkResistance.Mitigation_f(damage.darkDmg_f);
        health_f -= totalDamage_f;
        health_f += HealthRegen.Regen_f();
    }

}

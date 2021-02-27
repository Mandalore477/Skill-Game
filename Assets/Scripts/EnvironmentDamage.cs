using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDamage : MonoBehaviour
{
    [SerializeField] float fireDmg_f;
    [SerializeField] float lightningDmg_f;
    [SerializeField] float iceDmg_f;
    [SerializeField] float earthDmg_f;
    [SerializeField] float windDmg_f;
    [SerializeField] float darkDmg_f;
    [SerializeField] float tickDmgTimer;
    [SerializeField] float timer;
    Damage environmentDmg;
    bool isTickDmg;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        environmentDmg = new Damage(fireDmg_f, lightningDmg_f, iceDmg_f, earthDmg_f, windDmg_f, darkDmg_f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if( timer > tickDmgTimer)
        {
            isTickDmg = true;
            timer = 0;
        }else if(timer < tickDmgTimer && isTickDmg)
        {
            isTickDmg = false;
        }
        
    }

    //private void OnTriggerEnter(Collider c)
    //{
    //    c.gameObject.GetComponent<HealthComp>().TakeDamage(environmentDmg);
    //}

    private void OnTriggerStay(Collider c)
    {
        if (c.GetComponent<HealthComp>() && isTickDmg)
        {
            c.gameObject.GetComponent<HealthComp>().TakeDamage(environmentDmg);
        }
    }
}

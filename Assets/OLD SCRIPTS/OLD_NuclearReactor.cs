using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class OLD_NuclearReactor : MonoBehaviour
{

    public PylonNode my_pylon;

    public float power_production;

    public float remaining_fuel;
    public float remaining_water;

    public float power_stored;
    public float max_power_stored;

    public ParticleSystem radio_smoke;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (remaining_fuel > 0f && remaining_water > 0f)
        {
            power_stored += (power_production * Time.deltaTime);
            remaining_fuel -= Time.deltaTime / 40f;
            remaining_water -= Time.deltaTime / 10f;
            radio_smoke.Play();
        } else
        {
            radio_smoke.Stop();
        }

        power_stored = power_stored - my_pylon.DrawPowerFromProducer(power_stored, 5f);

        if (power_stored > max_power_stored)
        {
            power_stored = max_power_stored;
        }
    }
}
*/

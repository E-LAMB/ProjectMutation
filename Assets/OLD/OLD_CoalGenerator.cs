using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class OLD_CoalGenerator : MonoBehaviour
{

    public PylonNode my_pylon;

    public float power_production;
    public float remaining_fuel;

    public float power_stored;
    public float max_power_stored;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (power_stored < (max_power_stored * 0.9f) && remaining_fuel > 0f)
        {
            if (remaining_fuel > 1f)
            {
                power_stored += (power_production * Time.deltaTime);
                remaining_fuel -= Time.deltaTime / 6f;
            } else
            {
                power_stored += (power_production * Time.deltaTime * remaining_fuel);
                remaining_fuel -= Time.deltaTime / 6f;
            }
        }

        power_stored = power_stored - my_pylon.DrawPowerFromProducer(power_stored, 5f);

        if (power_stored > max_power_stored)
        {
            power_stored = max_power_stored;
        }
    }
}
*/
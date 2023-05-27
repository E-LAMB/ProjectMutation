using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubNode : MonoBehaviour
{

    public PylonNode my_pylon;

    public float power_stored;
    public float max_power_stored;

    // Start is called before the first frame update
    void Start()
    {
        power_stored = max_power_stored;
    }

    void DrawPower()
    {
        if (my_pylon != null)
        {

            float needed_power = max_power_stored - power_stored;
            needed_power = needed_power / 1.5f;
            needed_power = needed_power * Time.deltaTime;
            if (needed_power > Mind.max_pylon_transfer)
            {
                needed_power = Mind.max_pylon_transfer;
            }

            if (my_pylon.internal_power_supply >= 0f)
            {
                if (needed_power > my_pylon.internal_power_supply)
                {
                    needed_power = my_pylon.internal_power_supply;
                }

                if (my_pylon.internal_power_supply < 1f)
                {
                    needed_power = 0f;
                }

                my_pylon.internal_power_supply -= needed_power;
                power_stored += needed_power;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        power_stored -= Time.deltaTime / 2.5f;

        if (power_stored < 0f)
        {
            Debug.Log("Base Died");
        }
        
        if (power_stored > max_power_stored)
        {
            power_stored = max_power_stored;
        }
    }
}

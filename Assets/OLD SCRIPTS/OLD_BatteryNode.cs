using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class OLD_BatteryNode : MonoBehaviour
{

    public float power_storage;
    public float internal_power_supply;

    public PylonNode my_pylon;

    void DrawPower()
    {
        if (my_pylon != null)
        {

            float needed_power = power_storage - internal_power_supply;
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

                my_pylon.internal_power_supply -= needed_power;
                internal_power_supply += needed_power;
            }
        }
    }

    void Update()
    {
        DrawPower();
        internal_power_supply = internal_power_supply - my_pylon.DrawPowerFromProducer(internal_power_supply, Mind.max_pylon_transfer);
    }

}
*/
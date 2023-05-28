using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class OLD_TrainCharger : MonoBehaviour
{

    public Train my_train;

    public PylonNode my_pylon;

    public float internal_power_supply;
    public float max_power_stored;

    public LineRenderer my_connector;

    public Transform my_orb;

    void DrawPower()
    {
        if (my_pylon != null)
        {

            float needed_power = max_power_stored - internal_power_supply;
            needed_power = needed_power / 2.5f;
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
                internal_power_supply += needed_power - (needed_power * (1f / Mind.pylon_power_loss));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        DrawPower();

        if (my_train.accepting_charge)
        {
            my_connector.SetPosition(0,new Vector3(0f,0f,0f));
            my_connector.SetPosition(1,my_train.my_orb.position - my_orb.position);

            float needed_power = 25.5f - my_train.wait_time;
            needed_power = needed_power / 1.3f;
            needed_power = needed_power * Time.deltaTime;

            if (needed_power > Mind.max_pylon_transfer)
            {
                needed_power = Mind.max_pylon_transfer;
            }

            if (my_train.wait_time >= 0f)
            {
                if (needed_power > 25.5f - my_train.wait_time)
                {
                    needed_power = 25f - my_train.wait_time;
                }

                my_train.wait_time += needed_power - (needed_power * (1f / Mind.pylon_power_loss));
                internal_power_supply -= needed_power;
            }

        } else
        {
            my_connector.SetPosition(0,new Vector3(0f,0f,0f));
            my_connector.SetPosition(1,new Vector3(0f,0f,0f));
        }
    }
}
*/

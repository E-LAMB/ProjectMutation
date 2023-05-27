using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerNode : MonoBehaviour
{

    public Drone my_drone;
    public bool has_a_drone;

    public PylonNode my_pylon;

    public float internal_power_supply;
    public float max_power_stored;

    public LineRenderer my_connector;

    public Transform my_orb;

    void OnTriggerStay(Collider other)
    {
        if (!has_a_drone && other.gameObject.GetComponent<Drone>())
        {
            if (other.gameObject.GetComponent<Drone>().state == 2)
            {
                my_drone = other.gameObject.GetComponent<Drone>();
                has_a_drone = true;
            }
        }
    }

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

        if (has_a_drone)
        {

            my_connector.SetPosition(0,new Vector3(0f,0f,0f));
            my_connector.SetPosition(1,my_drone.my_orb.position - my_orb.position);

            float needed_power = my_drone.maximum_battery - my_drone.battery;
            needed_power = needed_power / 1.3f;
            needed_power = needed_power * Time.deltaTime;

            if (needed_power > Mind.max_pylon_transfer)
            {
                needed_power = Mind.max_pylon_transfer;
            }

            if (my_drone.battery >= 0f)
            {
                if (needed_power > my_drone.battery)
                {
                    needed_power = my_drone.battery;
                }

                my_drone.battery += needed_power - (needed_power * (1f / Mind.pylon_power_loss));
                internal_power_supply -= needed_power;
            }

            if (my_drone.state != 2)
            {
                has_a_drone = false;
                my_drone = null;
            }
        } else
        {
            my_connector.SetPosition(0,new Vector3(0f,0f,0f));
            my_connector.SetPosition(1,new Vector3(0f,0f,0f));
        }
    }
}

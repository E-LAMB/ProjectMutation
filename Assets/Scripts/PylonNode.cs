using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonNode : MonoBehaviour
{

    public PylonNode connected_node;
    
    public float internal_power_supply;

    public Transform my_orb;
    public LineRenderer my_line;

    void SharePower()
    {

        float my_needed = Mind.max_pylon_capacity - internal_power_supply;
        float connected_needed = -5f;
        
        if (connected_node != null)
        {
            connected_needed = Mind.max_pylon_capacity - connected_node.internal_power_supply;
        }

        if (my_needed > connected_needed)
        {
            if (my_needed > connected_node.internal_power_supply)
            {
                my_needed = connected_node.internal_power_supply;
            }

            my_needed = my_needed * 0.75f;
            if (my_needed > Mind.max_pylon_transfer)
            {
                my_needed = Mind.max_pylon_transfer;
            }

            connected_node.internal_power_supply -= my_needed;
            internal_power_supply += my_needed;

        } else
        {
            if (connected_needed > internal_power_supply)
            {
                connected_needed = internal_power_supply;
            }

            connected_needed = connected_needed * 0.75f;
            if (connected_needed > Mind.max_pylon_transfer)
            {
                connected_needed = Mind.max_pylon_transfer;
            }

            connected_node.internal_power_supply += connected_needed;
            internal_power_supply -= connected_needed;
        }

    }

    public float DrawPowerFromProducer(float power_stored, float max_transfer)
    {
        float needed_power = Mind.max_pylon_capacity - internal_power_supply;
        needed_power = needed_power * Time.deltaTime;

        if (needed_power > max_transfer)
        {
            needed_power = max_transfer;
        }

        if (power_stored < 0f)
        {
            power_stored = 0f;
        }

        if (power_stored >= 0f)
        {
            if (needed_power > power_stored)
            {
                needed_power = power_stored;
            }

            internal_power_supply += needed_power;
            return needed_power;
        }
        return 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (connected_node != null)
        {
            SharePower();
            my_line.SetPosition(0,new Vector3(0f,0f,0f));
            my_line.SetPosition(1,connected_node.my_orb.position - my_orb.position);
        } else
        {
            my_line.SetPosition(0,new Vector3(0f,0f,0f));
            my_line.SetPosition(1,new Vector3(0f,0f,0f));
        }
    }
}

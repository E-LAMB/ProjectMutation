using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{

    public bool able_to_select;
    public int my_place;

    public int stage;
    // 0 - Awaiting Order

    public Transform self;

    public float my_battery;
    // Low power mode is 40%. During this, A 20% speed reduction is applied.
    // At 0%, This drone becomes disfunctional.

    public DroneOrderer my_orderer;

    public OrderFormat my_order;

    public float objective_distance;

    public bool RequestedOrder(OrderFormat proposed_order)
    {

        if (Vector3.Distance(proposed_order.order_origin.transform.position, self.position) > 60f)
        {
            return true;
        }

        if (my_battery < 40f)
        {
            return true;
        }

        if (!able_to_select)
        {
            return true;
        }

        my_order = proposed_order;
        able_to_select = false;
        stage = 1;

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        my_place = Mind.drone_ID_startup;
        Mind.drone_ID_startup += 1;
        able_to_select = true;
        my_orderer.bot_list[my_place] = gameObject;
        my_orderer.avaliable_bots += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (my_order.order_code == "HAUL/COAL/STAT")
        {
            /* 
            (1)
            Move to COAL
            Pick up COAL
            (2)
            Move to STATION
            Drop off COAL
            */

            if (stage == 1)
            {

            }
        }
    }
}

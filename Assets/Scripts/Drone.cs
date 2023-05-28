using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{

    public bool able_to_select;
    public int stage;
    // -1 : Completed Order
    // -2 : Dusting Self
    // -3 : Requesting and Awaiting Charge
    // 0 : Awaiting Order

    public Transform self;
    public NavMeshAgent agent;

    public float my_battery;
    // Drones will call over a Charger Unit if there is one avaliable at 50% battery.
    // Low power mode is 40%. During this, A 20% speed reduction is applied.
    // At 0%, This drone becomes disfunctional.

    public float my_dust;
    // Drones will visit maintenance whenever they become Dirty 
    // At below 80%, The Drone becomes Dirty. During this, A 5% speed reduction is applied.
    // At below 30%, The Drone becomes Weakened. During this, A 40% speed reduction is applied.
    // At 0%, The Drone becomes disfunctional.

    public string mine_ordercode;
    public GameObject mine_primary;
    public GameObject mine_secondary;
    public string mine_status;

    public float objective_distance;

    public string item_in_hand;
    public GameObject[] items;
    public GameObject open_hand;
    public GameObject close_hand;

    public bool RequestedOrder(string proposed_ordercode, GameObject proposed_primary, GameObject proposed_secondary, string proposed_status)
    {

        if (proposed_primary == null)
        {
            return true;
        }
        if (proposed_secondary == null)
        {
            return true;
        }

        if (Vector3.Distance(proposed_primary.transform.position, self.position) > 60f)
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

        mine_ordercode = proposed_ordercode;
        mine_primary = proposed_primary;
        mine_secondary = proposed_secondary;
        mine_status = "PEND";
        able_to_select = false;
        stage = 1;
        agent.enabled = true; 

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        agent.enabled = false;
        able_to_select = true;
        ChangeItem("Empty");
        my_battery = 100f;
        my_dust = 100f;
    }

    void ChangeItem(string new_item)
    {
        item_in_hand = new_item;
        
        if (new_item == "Empty")
        {
            open_hand.SetActive(true);
            close_hand.SetActive(false);

        } else
        {
            open_hand.SetActive(false);
            close_hand.SetActive(true);
        }

        if (new_item == "Coal") {items[0].SetActive(true);} else {items[0].SetActive(false);}
        if (new_item == "RadioactiveOre") {items[1].SetActive(true);} else {items[1].SetActive(false);}
        if (new_item == "Water") {items[2].SetActive(true);} else {items[2].SetActive(false);}
        if (new_item == "Waste") {items[3].SetActive(true);} else {items[3].SetActive(false);}
    }

    void CompleteTask()
    {
        mine_ordercode = "";
        mine_primary = null;
        mine_secondary = null;
        mine_status = "";
        stage = -1;
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (stage == -1)
        {

            if (my_battery < 50f)
            {
                stage = -3;

            } else if (my_dust < 50f)
            {
                stage = -2;

            } else 
            {
                stage = 0;
                able_to_select = true;
            }
        }

        if (mine_ordercode == "HAUL/RADO/REAC")
        {
            if (stage == 1)
            {

            }
            if (stage == 2)
            {
                
            }
        }


    }
}

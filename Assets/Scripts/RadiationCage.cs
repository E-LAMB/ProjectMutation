using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationCage : MonoBehaviour
{

    public int cage_state; // (Needs 15 waste to go into a cleaning state)
    // 1 = Collecting Waste
    // 2 = Waiting for Cleaning

    public int waste_enroute;
    public int waste_inside;

    public bool requested_cleaner;

    public int order_stage;
    // 0 - Ready to make
    // 1 - Process has started (Searching for Item) + Verifying with item
    // 2 - Process has started (Searching for avaliable drone) + Verifying with drone
    // 3 - Cooldown

    public float order_cooldown;
    
    public GameObject self;
    public Transform self_trans;

    public GameObject[] items_list;
    public GameObject[] drones_list;

    public GameObject selected_item;
    public GameObject selected_drone;

    // Start is called before the first frame update
    void Start()
    {
        cage_state = 1;
    }

    void StartOrder()
    {
        if (order_stage != 0)
        {
            return;
        }

        items_list = GameObject.FindGameObjectsWithTag("Item");
        drones_list = GameObject.FindGameObjectsWithTag("Drone");

        order_stage = 1;

        return;

    }

    public void Operated()
    {
        if (cage_state == 2)
        {
            cage_state = 1;
            waste_inside = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (cage_state == 1)
        {

            if (order_stage == 1)
            {
                items_list = GameObject.FindGameObjectsWithTag("Item");
                selected_item = items_list[Random.Range(0, items_list.Length)];
                if (selected_item != null && selected_item.GetComponent<BuildingIdentity>().can_be_chosen("Waste",self_trans))
                {
                    order_stage = 2;
                }
            }
            if (order_stage == 2)
            {
                selected_drone = drones_list[Random.Range(0, drones_list.Length)];
                if (!selected_drone.GetComponent<Drone>().RequestedOrder("HAUL", selected_item, self))
                {
                    waste_enroute += 1;
                    order_cooldown = 2f;
                    order_stage = 3;
                }
            }
            if (order_stage == 3)
            {
                order_cooldown -= Time.deltaTime;
                if (order_cooldown < 0f)
                {
                    order_stage = 0;
                }
            }

            if ((waste_inside + waste_enroute) < 10)
            {
                StartOrder();
            }

            if (waste_inside > 9 && order_stage == 0)
            {
                cage_state = 2;
                requested_cleaner = false;
            }

        } else
        {

            if (order_stage == 1)
            {
                order_stage = 2;
            }
            if (order_stage == 2)
            {
                selected_drone = drones_list[Random.Range(0, drones_list.Length)];
                if (!selected_drone.GetComponent<Drone>().RequestedOrder("OPERATE/10", self, self))
                {
                    order_cooldown = 2f;
                    order_stage = 3;
                }
            }
            if (order_stage == 3)
            {
                order_cooldown -= Time.deltaTime;
                if (order_cooldown < 0f)
                {
                    order_stage = 0;
                }
            }

            if (!requested_cleaner)
            {
                requested_cleaner = true;
                StartOrder();
            }

        }

    }
}

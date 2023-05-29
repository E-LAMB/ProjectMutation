using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalBurner : MonoBehaviour
{

    public int coal_enroute;
    public int coal_inside;

    public float burn_time;

    public float internal_power;

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

    // Update is called once per frame
    void Update()
    {
        if (order_stage == 1)
        {
            items_list = GameObject.FindGameObjectsWithTag("Item");
            selected_item = items_list[Random.Range(0, items_list.Length)];
            if (selected_item != null && selected_item.GetComponent<BuildingIdentity>().can_be_chosen("Coal",self_trans))
            {
                order_stage = 2;
            }
        }
        if (order_stage == 2)
        {
            selected_drone = drones_list[Random.Range(0, drones_list.Length)];
            if (!selected_drone.GetComponent<Drone>().RequestedOrder("HAUL", selected_item, self))
            {
                coal_enroute += 1;
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

        if ((coal_inside + coal_enroute) < 5)
        {
            StartOrder();
        }

        if (coal_inside > 0 && burn_time < 0.5f)
        {
            burn_time = 20f;
            coal_inside -= 1;
        }

        if (burn_time > 0f)
        {
            burn_time -= Time.deltaTime;
            internal_power += Time.deltaTime * 10f;
        }
    }
}

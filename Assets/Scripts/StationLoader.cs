using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationLoader : MonoBehaviour
{

    public int items_coal;
    public int items_water;
    public int items_radioactive_ore;
    public int items_waste;

    public int coal_enroute;
    public int water_enroute;
    public int waste_enroute;
    public int radioactiveore_enroute;

    public int items_inside;

    public float time_back;

    public Train my_train;

    public bool accepting_item_coal;
    public bool accepting_item_water;
    public bool accepting_item_radioactive_ore;
    public bool accepting_item_waste;

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
            if (accepting_item_coal && selected_item != null && selected_item.GetComponent<BuildingIdentity>().can_be_chosen("Coal",self_trans))
            {
                order_stage = 2;
            } else if (accepting_item_water && selected_item != null && selected_item.GetComponent<BuildingIdentity>().can_be_chosen("Water",self_trans))
            {
                order_stage = 2;
            } else if (accepting_item_waste && selected_item != null && selected_item.GetComponent<BuildingIdentity>().can_be_chosen("Waste",self_trans))
            {
                order_stage = 2;
            } else if (accepting_item_radioactive_ore && selected_item != null && selected_item.GetComponent<BuildingIdentity>().can_be_chosen("RadioactiveOre",self_trans))
            {
                order_stage = 2;
            }
        }
        if (order_stage == 2)
        {
            selected_drone = drones_list[Random.Range(0, drones_list.Length)];
            if (!selected_drone.GetComponent<Drone>().RequestedOrder("HAUL", selected_item, self))
            {
                if (selected_item.GetComponent<BuildingIdentity>().my_identity == "Water")
                {
                    water_enroute += 1;
                } else if (selected_item.GetComponent<BuildingIdentity>().my_identity == "Coal")
                {
                    coal_enroute += 1;
                } else if (selected_item.GetComponent<BuildingIdentity>().my_identity == "Waste")
                {
                    waste_enroute += 1;
                } else if (selected_item.GetComponent<BuildingIdentity>().my_identity == "RadioactiveOre")
                {
                    radioactiveore_enroute += 1;
                }

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

        if (accepting_item_coal && (items_coal + coal_enroute) < 15)
        {
            StartOrder();
        }
        if (accepting_item_water && (items_water + water_enroute) < 15)
        {
            StartOrder();
        }

        if (accepting_item_waste && (items_waste + waste_enroute) < 15)
        {
            StartOrder();
        }

        if (accepting_item_radioactive_ore && (items_radioactive_ore + radioactiveore_enroute) < 15)
        {
            StartOrder();
        }

        items_inside = items_coal + items_water + items_waste + items_radioactive_ore;

        if (items_inside == 0)
        {
            my_train.loader_empty = true;
        } else
        {
            my_train.loader_empty = false;
        }

        time_back += Time.deltaTime;

        if (time_back > 0.25f && my_train.accepting_items)
        {
            time_back = 0f;
            if (items_coal > 0)
            {
                my_train.LoadedItem();
                items_coal -= 1;
                my_train.items_coal += 1;
            } else if (items_water > 0)
            {
                my_train.LoadedItem();
                items_water -= 1;
                my_train.items_water += 1;
            } else if (items_waste > 0)
            {
                my_train.LoadedItem();
                items_waste -= 1;
                my_train.items_waste += 1;
            } else if (items_radioactive_ore > 0)
            {
                my_train.LoadedItem();
                items_radioactive_ore -= 1;
                my_train.items_radioactive_ore += 1;
            }
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearReactor : MonoBehaviour
{

    public int fuel_enroute;
    public int water_enroute;

    public int fuel_stored;
    public int water_stored;

    public float run_time;
    public float internal_power;
    public float heat;

    public int order_stage;
    // 0 - Ready to make
    // 1 - Process has started (Searching for Item) + Verifying with item - Either FUEL or WATER depending on WATER abundance
    // 2 - Process has started (Searching for avaliable drone) + Verifying with drone
    // 3 - Cooldown

    public float order_cooldown;

    public GameObject self;
    public Transform self_trans;

    public GameObject[] items_list;
    public GameObject[] drones_list;

    public GameObject selected_item;
    public GameObject selected_drone;

    public GameObject waste_prefab;
    public Transform waste_disposal;
    public float waste_creation;

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
            if ((water_enroute + water_stored) < 3 || (fuel_enroute + fuel_stored) > 0)
            {
                if (selected_item != null && selected_item.GetComponent<BuildingIdentity>().can_be_chosen("Water",self_trans))
                {
                    order_stage = 2;
                }
            } else
            {
                if (selected_item != null && selected_item.GetComponent<BuildingIdentity>().can_be_chosen("RadioactiveOre",self_trans))
                {
                    order_stage = 2;
                }
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
                } else
                {
                    fuel_enroute += 1;
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

        if ((water_enroute + water_stored) < 5)
        {
            StartOrder();
        }

        if ((fuel_stored + fuel_enroute) < 1 && water_stored > 0)
        {
            StartOrder();
        }

        if (water_stored > 0 && heat > 20f)
        {
            water_stored -= 1;
            heat -= 15f;
        }

        if (fuel_stored > 0 && run_time < 0.5f)
        {
            fuel_stored -= 1;
            run_time += 15f;
        }

        if (heat > 100f && 0f > run_time)
        {
            run_time -= Time.deltaTime * 10f;
        }

        if (run_time > 0f)
        {
            waste_creation += Time.deltaTime;
            heat += Time.deltaTime * 2f;
            run_time -= Time.deltaTime;
            internal_power += Time.deltaTime * 105f;
        }

        if (waste_creation > 3f)
        {
            waste_creation = 0f;
            Instantiate(waste_prefab, waste_disposal.position, waste_disposal.localRotation);
        }

        if (heat > 0f)
        {
            heat -= Time.deltaTime / 10f;
        }
    }
}

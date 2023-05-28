using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingReactor : MonoBehaviour
{

    public GameObject self;
    public GameObject interaction_point;
    public DroneOrderer my_orderer;

    public int fuel_inside;
    public int water_inside;

    public int fuel_enroute;
    public int water_enroute;

    public float generation_time;

    public float internal_power;

    public bool order_submitted;
    public bool selected_secondary;

    public GameObject fuel_item;
    public GameObject water_item;

    public Transform waste_output;
    public GameObject waste;
    public float waste_time;

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<BuildingIdentity>())
        {
            if (other.GetComponent<BuildingIdentity>().my_identity == "RadioactiveOre" && !other.GetComponent<BuildingIdentity>().should_be_ignored)
            {
                fuel_item = other.gameObject;
                // fuel_item.GetComponent<BuildingIdentity>().should_be_ignored = true;
            }
            if (other.GetComponent<BuildingIdentity>().my_identity == "Water" && !other.GetComponent<BuildingIdentity>().should_be_ignored)
            {
                water_item = other.gameObject;
                // water_item.GetComponent<BuildingIdentity>().should_be_ignored = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        my_orderer = GameObject.FindGameObjectWithTag("DroneOrderer").GetComponent<DroneOrderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (fuel_inside < (1 - fuel_enroute) && fuel_item != null)
        {
            order_submitted = my_orderer.AddOrder("HAUL/RADO/REAC", fuel_item, self, 2);
            if (order_submitted)
            {
                fuel_item.GetComponent<BuildingIdentity>().should_be_ignored = true;
                fuel_item = null;
                fuel_enroute += 1;
                Debug.Log("Submitted");
            } else
            {
                fuel_item.GetComponent<BuildingIdentity>().should_be_ignored = false;
            }
        }

        if (water_inside < (5 - water_enroute) && water_item != null)
        {
            order_submitted = my_orderer.AddOrder("HAUL/WATE/REAC", water_item, self, 3);
            if (order_submitted)
            {
                water_item.GetComponent<BuildingIdentity>().should_be_ignored = true;
                water_item = null;
                water_enroute += 1;
            } else
            {
                water_item.GetComponent<BuildingIdentity>().should_be_ignored = false;
            }
        }

        if (water_inside >= 5 && fuel_inside >= 1 && generation_time <= 0.5f)
        {
            water_inside -= 5;
            fuel_inside -= 1;
            generation_time = 10f;
        }
        
        if (waste_time > 1f)
        {
            waste_time = 0f;
            Instantiate(waste, waste_output.position, waste_output.localRotation);
        }

        if (generation_time > 0f)
        {
            generation_time -= Time.deltaTime;
            waste_time += Time.deltaTime;
            internal_power += Time.deltaTime * 5f;
        }
    }
}

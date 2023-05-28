using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCage : MonoBehaviour
{

    public GameObject self;
    public GameObject interaction_point;
    public DroneOrderer my_orderer;

    public int waste_inside;
    public int waste_enroute;
    public int waste_storage;
    public int waste_to_remove;

    public bool order_submitted;
    public bool selected_secondary;

    public GameObject waste_item;

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<BuildingIdentity>())
        {
            if (other.GetComponent<BuildingIdentity>().my_identity == "Waste" && !other.GetComponent<BuildingIdentity>().should_be_ignored)
            {
                waste_item = other.gameObject;
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

        if (waste_inside < (waste_storage - waste_enroute) && waste_item != null && waste_to_remove == 0)
        {
            order_submitted = my_orderer.AddOrder("HAUL/WAST/CAGE", waste_item, self, 3);
            if (order_submitted)
            {
                waste_item.GetComponent<BuildingIdentity>().should_be_ignored = true;
                waste_item = null;
                waste_enroute += 1;
            } else
            {
                waste_item.GetComponent<BuildingIdentity>().should_be_ignored = false;
            }
        }

        if (waste_inside == waste_storage && waste_to_remove == 0)
        {
            waste_to_remove = waste_storage;
            order_submitted = my_orderer.AddOrder("OPER/CAGE", self, self, 3);
        }


    }
}


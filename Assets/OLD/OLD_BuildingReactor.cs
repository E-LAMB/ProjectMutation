using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
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

    public bool order_submitted_fuel;
    public bool order_submitted_water;

    public bool selected_secondary;

    public GameObject fuel_item;
    public GameObject water_item;

    public Transform waste_output;
    public GameObject waste;
    public float waste_time;

    // Start is called before the first frame update
    void Start()
    {
        my_orderer = GameObject.FindGameObjectWithTag("DroneOrderer").GetComponent<DroneOrderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((fuel_enroute + fuel_inside) < 1)
        {
            
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
*/
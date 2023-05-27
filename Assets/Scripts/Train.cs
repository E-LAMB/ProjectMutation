using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{

    public int items_coal;
    public int items_water;

    public bool has_space;

    public float wait_time;

    public bool accepting_charge;
    public bool accepting_items;

    public bool loader_empty;

    public int state;
    // 0 = Waiting for Cargo
    // 1 = Travelling to Unloader
    // 2 = Unloading Cargo
    // 3 = Travelling to Loader
    // 4 = Charging

    public Transform loader_position;
    public Transform unloader_position;
    public Transform self;

    public StationLoader my_loader;
    public StationUnloader my_unloader;

    public Transform my_orb;
    public GameObject orb_object;

    public Vector3 speed_to_loader;

    public float distance_to_destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadedItem()
    {
        if (state == 0)
        {
            wait_time = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        orb_object.SetActive(accepting_charge);

        if (state == 0)
        {
            accepting_items = true;
            wait_time += Time.deltaTime;

            if ((items_coal + items_water) > 47)
            {
                has_space = false;
            } else
            {
                has_space = true;
            }

            if (loader_empty && (items_coal + items_water) > 9 && wait_time > 3f)
            {
                state = 1;
            }
            if (wait_time > 30f)
            {
                state = 1;
            }
            if (!has_space)
            {
                state = 1;
            }
        }

        if (state == 1)
        {
            accepting_items = false;
            distance_to_destination = Vector3.Distance(self.position, unloader_position.position);
            self.position += speed_to_loader * Time.deltaTime;
            if (distance_to_destination < 1.2f)
            {
                state = 2;
                wait_time = 0f;
            }
        }

        if (state == 2)
        {
            wait_time += Time.deltaTime;

            if (wait_time > 0.25f)
            {
                wait_time = 0f;
                if (items_coal > 0)
                {
                    items_coal -= 1;
                    my_unloader.Unloader("COAL");
                } else if (items_water > 0)
                {
                    items_water -= 1;
                    my_unloader.Unloader("WATER");
                }
            }

            if (items_coal == 0 && items_water == 0)
            {
                state = 3;
                speed_to_loader.x = speed_to_loader.x * -1f;
                speed_to_loader.y = speed_to_loader.y * -1f;
                speed_to_loader.z = speed_to_loader.z * -1f;
            }
        }

        if (state == 3)
        {
            distance_to_destination = Vector3.Distance(self.position, loader_position.position);
            self.position += speed_to_loader * Time.deltaTime;
            if (distance_to_destination < 1.2f)
            {
                state = 4;
                wait_time = 0f;
                accepting_charge = true;
            }
        }

        if (state == 4)
        {
            if (wait_time > 25f)
            {
                state = 0;
                accepting_charge = false;
                speed_to_loader.x = speed_to_loader.x * -1f;
                speed_to_loader.y = speed_to_loader.y * -1f;
                speed_to_loader.z = speed_to_loader.z * -1f;
            }
        }
    }
}

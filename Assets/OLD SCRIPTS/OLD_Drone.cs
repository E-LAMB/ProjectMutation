using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
public class OLD_Drone : MonoBehaviour
{

    public int state;
    // 0 = Idle. If no tasks are avaliable, Then it will go to "Home"

    // 1 = Low Power - (Searching For Charger) 
    // 2 = Low Power - (Move To Charger + Charging) ---> Now results in state 0

    // 3 = Clean Self (Takes 5 seconds)

    // 4 = Coal Task - (Searching For Coal)
    // 5 = Coal Task - (Moving to Coal + Collection)

    // 6 = Coal Generator - (Searching For Generator)
    // 7 = Coal Generator - (Moving to Generator + Depositing)

    // 8 = Test For Importance (Radiation)

    // (WATER)
    // 9 = Radioactive Task - (Searching For Well)
    // 10 = Radioactive Task - (Moving to Well + Collection)
    // 11 = Radioactive Generator - (Searching for Reactor)
    // 12 = Radioactive Generator - (Moving to Reactor + Depositing)

    // (RADIOACTIVE ORE)
    // 13 = Radioactive Task - (Searching For Ore)
    // 14 = Radioactive Task - (Moving to Ore + Collection)
    // 15 = Radioactive Generator - (Searching for Reactor)
    // 16 = Radioactive Generator - (Moving to Reactor + Depositing)

    // 17 = Radioactive Waste - (Searching for Waste)
    // 18 = Radioactive Waste - (Moving to Bin + Depositing)

    // 19 = Searching for deactivated drones
    // 20 = Giving power to a deactivated drone

    // 21 = Searching for a nearby station
    // 22 = Delivering to station

    public float battery;
    public float maximum_battery;
    public float low_power_threshold;

    public float dirty_meter; // Has to reach 40

    public float normal_sense_range;
    public float low_power_sense_range;

    public DroneScanner my_scanner;

    public NavMeshAgent my_agent;
    public Transform self;

    public GameObject orb_object;
    public Transform my_orb;

    public Vector3 home;

    public BuildingIdentity my_identity;

    public float distance_to_destination;

    public string item_in_hand = "EMPTY";
    public GameObject open_hand;
    public GameObject close_hand;
    public GameObject[] items;
    // 0 = Coal
    // 1 = Radioactive Ore
    // 2 = Radioactive Waste

    // Start is called before the first frame update
    void Start()
    {
        Mind.drones_decommissioned_battery = 0;
        home = self.position;
        battery = Random.Range(15f,maximum_battery);
        ChangeItem("EMPTY");
        orb_object.SetActive(false);
    }

    void ChangeItem(string new_item)
    {
        item_in_hand = new_item;
        
        if (new_item == "EMPTY")
        {
            open_hand.SetActive(true);
            close_hand.SetActive(false);

        } else
        {
            open_hand.SetActive(false);
            close_hand.SetActive(true);
        }

        if (new_item == "COAL") {items[0].SetActive(true);} else {items[0].SetActive(false);}
        if (new_item == "RADIOACTIVEORE") {items[1].SetActive(true);} else {items[1].SetActive(false);}
        if (new_item == "WATER") {items[2].SetActive(true);} else {items[2].SetActive(false);}

    }

    // Update is called once per frame
    void Update()
    {

        if (battery > 0f)
        {

            battery -= Time.deltaTime / 4f;

            if (state == 0)
            {
                my_agent.SetDestination(self.position);

                if (battery < low_power_threshold)
                {
                    my_scanner.BeginSearch("Charger", low_power_sense_range, false);
                    state = 1;
                    // Debug.Log("Scanning for charger");
                    
                } else if (dirty_meter > 80f)
                {
                    state = 3;

                } else if (item_in_hand == "COAL")
                {
                    my_scanner.BeginSearch("CoalGenerator", normal_sense_range, false);
                    state = 6;

                } else if (item_in_hand == "WATER")
                {
                    my_scanner.BeginSearch("NuclearReactor", normal_sense_range, false);
                    state = 11;

                } else if (battery > (maximum_battery * 0.8f) && Mind.drones_decommissioned_battery > 0)
                {
                    my_scanner.BeginSearch("BatteryDeadDrone", normal_sense_range, true);
                    state = 19;

                } else if (item_in_hand == "EMPTY")
                {

                    if (Random.Range(1,6) == 1)
                    {
                        my_scanner.BeginSearch("NuclearReactor", normal_sense_range, false);
                        state = 8;

                    } else
                    {
                        my_scanner.BeginSearch("Coal", normal_sense_range, true);
                        state = 4;
                    }

                }

            }

            if (state == 1)
            {
                my_agent.SetDestination(self.position);

                if (!my_scanner.activated)
                {
                    if (my_scanner.found_object == null)
                    {
                        my_scanner.BeginSearch("Charger", low_power_sense_range, false);
                        state = 1;
                    } else
                    {
                        state = 2;
                    }
                }
            }

            if (state == 2)
            {
                my_agent.SetDestination(my_scanner.found_object.transform.position);
                distance_to_destination = Vector3.Distance(self.position, my_scanner.found_object.transform.position);

                if (distance_to_destination < 2f)
                {
                    orb_object.SetActive(true);
                } else
                {
                    orb_object.SetActive(false);
                    dirty_meter += Time.deltaTime;
                }

                if (battery > (maximum_battery * 0.9f))
                {
                    orb_object.SetActive(false);
                    state = 0;
                }   
            }

            if (state == 3)
            {
                dirty_meter -= Time.deltaTime * 10f;

                if (dirty_meter < 0f)
                {
                    state = 0;
                }
            }

            if (state == 4)
            {
                my_agent.SetDestination(self.position);

                if (!my_scanner.activated)
                {
                    if (my_scanner.found_object == null)
                    {
                        state = 0;
                    } else
                    {
                        state = 5;
                    }
                }
            }

            if (state == 5)
            {
                my_agent.SetDestination(my_scanner.found_object.transform.position);
                distance_to_destination = Vector3.Distance(self.position, my_scanner.found_object.transform.position);

                if (battery < low_power_threshold) {state = 0;} // Quits if Low Power

                dirty_meter += Time.deltaTime;

                if (distance_to_destination < 0.7f)
                {
                    Destroy(my_scanner.found_object);
                    ChangeItem("COAL");
                    state = 0;
                }   
            }

            if (state == 6)
            {
                my_agent.SetDestination(self.position);

                if (!my_scanner.activated)
                {
                    if (my_scanner.found_object == null)
                    {
                        //state = 21;
                        state = 0;
                    } else
                    {
                        state = 7;
                    }
                }
            }

            if (state == 7)
            {
                my_agent.SetDestination(my_scanner.found_object.transform.position);
                distance_to_destination = Vector3.Distance(self.position, my_scanner.found_object.transform.position);

                if (battery < low_power_threshold) {state = 0;} // Quits if Low Power

                dirty_meter += Time.deltaTime;

                if (distance_to_destination < 1f)
                {
                    my_scanner.found_object.GetComponent<CoalGenerator>().remaining_fuel += 1f;
                    ChangeItem("EMPTY");
                    state = 0;
                }   
            }

            if (state == 8)
            {
                my_agent.SetDestination(self.position);

                if (!my_scanner.activated)
                {
                    if (my_scanner.found_object == null)
                    {
                        state = 0;
                    } else
                    {
                        if (my_scanner.found_object.GetComponent<NuclearReactor>().power_stored > 250f)
                        {
                            state = 0;
                        }

                        if (my_scanner.found_object.GetComponent<NuclearReactor>().remaining_fuel > (my_scanner.found_object.GetComponent<NuclearReactor>().remaining_water * 4.5f))
                        {
                            my_scanner.BeginSearch("Well", normal_sense_range, true);
                            state = 9;
                        } else
                        {
                            my_scanner.BeginSearch("RadioactiveOre", normal_sense_range, true);
                            state = 13;
                        }
                    }
                }
            }

            if (state == 9)
            {
                if (!my_scanner.activated)
                {
                    if (my_scanner.found_object == null)
                    {
                        state = 0;
                        //my_scanner.BeginSearch("StationLoader", normal_sense_range, false);
                        //state = 21;
                    } else
                    {
                        state = 10;
                    }
                }
            }

            if (state == 10)
            {
                my_agent.SetDestination(my_scanner.found_object.transform.position);
                distance_to_destination = Vector3.Distance(self.position, my_scanner.found_object.transform.position);

                dirty_meter += Time.deltaTime;

                if (distance_to_destination < 0.3f)
                {
                    my_scanner.found_object.GetComponent<Well>().free_well = true;
                    ChangeItem("WATER");
                    my_scanner.BeginSearch("NuclearReactor", normal_sense_range, false);
                    state = 11;
                }   
            }

            if (state == 11)
            {
                if (!my_scanner.activated)
                {
                    if (my_scanner.found_object == null)
                    {
                        state = 11;
                        my_scanner.BeginSearch("NuclearReactor", normal_sense_range, false);
                    } else
                    {
                        state = 12;
                    }
                }
            }

            if (state == 12)
            {
                my_agent.SetDestination(my_scanner.found_object.transform.position);
                distance_to_destination = Vector3.Distance(self.position, my_scanner.found_object.transform.position);

                dirty_meter += Time.deltaTime;

                if (distance_to_destination < 1f)
                {
                    my_scanner.found_object.GetComponent<NuclearReactor>().remaining_water += 1;
                    ChangeItem("EMPTY");
                    state = 0;
                }      
            }

            if (state == 13)
            {
                if (!my_scanner.activated)
                {
                    if (my_scanner.found_object == null)
                    {
                        state = 0;
                    } else
                    {
                        state = 14;
                    }
                }
            }

            if (state == 14)
            {
                my_agent.SetDestination(my_scanner.found_object.transform.position);
                distance_to_destination = Vector3.Distance(self.position, my_scanner.found_object.transform.position);

                dirty_meter += Time.deltaTime;

                if (distance_to_destination < 0.3f)
                {
                    Destroy(my_scanner.found_object);
                    ChangeItem("RADIOACTIVEORE");
                    my_scanner.BeginSearch("NuclearReactor", normal_sense_range, false);
                    state = 15;
                }   
            }

            if (state == 15)
            {
                if (!my_scanner.activated)
                {
                    if (my_scanner.found_object == null)
                    {
                        state = 15;
                        my_scanner.BeginSearch("NuclearReactor", normal_sense_range, false);
                    } else
                    {
                        state = 16;
                    }
                }
            }

            if (state == 16)
            {
                my_agent.SetDestination(my_scanner.found_object.transform.position);
                distance_to_destination = Vector3.Distance(self.position, my_scanner.found_object.transform.position);

                dirty_meter += Time.deltaTime;

                if (distance_to_destination < 1f)
                {
                    my_scanner.found_object.GetComponent<NuclearReactor>().remaining_fuel += 1;
                    ChangeItem("EMPTY");
                    state = 0;
                }      
            }

            if (state == 19)
            {
                if (!my_scanner.activated)
                {
                    if (my_scanner.found_object == null)
                    {
                        state = 0;
                    } else
                    {
                        state = 20;
                        Debug.Log("Going to reactivate a drone   " + gameObject);
                    }
                }
            }

            if (state == 20)
            {
                my_agent.SetDestination(my_scanner.found_object.transform.position);
                distance_to_destination = Vector3.Distance(self.position, my_scanner.found_object.transform.position);

                dirty_meter += Time.deltaTime;

                if (distance_to_destination < 1f)
                {
                    my_scanner.found_object.GetComponent<Drone>().battery += (battery / 2f) + 5f;
                    my_scanner.found_object.GetComponent<Drone>().my_agent.enabled = true;
                    my_scanner.found_object.GetComponent<Drone>().my_identity.my_identity = "Drone";
                    battery = (battery / 2f) + 5f;
                    state = 0;
                    Mind.drones_decommissioned_battery -= 1;
                    my_scanner.found_object.GetComponent<Drone>().enabled = true;
                }  
            }

            if (state == 21)
            {
                my_scanner.BeginSearch("StationLoader", normal_sense_range, false);
                state = 22;
            }

            if (state == 22)
            {
                my_agent.SetDestination(self.position);

                Debug.Log("State 22");

                if (!my_scanner.activated)
                {
                    Debug.Log("Scanner inactive");
                    Debug.Log(my_scanner.found_object);
                    if (my_scanner.found_object == null)
                    {
                        Debug.Log("Is Null");
                        state = 0;
                    } else
                    {
                        Debug.Log("Is Else");
                        state = 22;
                    }
                }
            }

            if (state == 23)
            {
                my_agent.SetDestination(my_scanner.found_object.transform.position);
                distance_to_destination = Vector3.Distance(self.position, my_scanner.found_object.transform.position);

                // if (battery < low_power_threshold) {state = 0;} // Quits if Low Power

                dirty_meter += Time.deltaTime;

                if (distance_to_destination < 1f)
                {
                    if (item_in_hand == "COAL")
                    {
                        my_scanner.found_object.GetComponent<StationLoader>().items_coal += 1;
                    } else if (item_in_hand == "WATER")
                    {
                        my_scanner.found_object.GetComponent<StationLoader>().items_water += 1;
                    }

                    ChangeItem("EMPTY");
                    state = 0;
                }   
            }

            // Debug.Log(state + "  " + gameObject);

        } else
        {
            my_agent.enabled = false;
            my_identity.my_identity = "BatteryDeadDrone";
            Debug.Log("Ran Out Of Power   " + gameObject);
            Mind.drones_decommissioned_battery += 1;
            gameObject.GetComponent<Drone>().enabled = false;
        }
    }
}
*/
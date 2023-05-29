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

    public float objective_distance;
    public float operate_time;

    public string item_in_hand;
    public GameObject[] items;
    public GameObject open_hand;
    public GameObject close_hand;

    public bool RequestedOrder(string proposed_ordercode, GameObject proposed_primary, GameObject proposed_secondary)
    {

        if (proposed_primary == null)
        {
            return true;
        }
        if (proposed_secondary == null)
        {
            return true;
        }

        if (Vector3.Distance(proposed_primary.transform.position, self.position) > 40f)
        {
            return true;
        }

        if (Vector3.Distance(proposed_secondary.transform.position, self.position) > 40f)
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

        if (stage == -2)
        {
            my_dust += Time.deltaTime * 10f;
            if (my_dust > 100f)
            {
                my_dust = 100f;
                stage = -1;
            }
        }

        if (stage == -3)
        {
            my_battery += Time.deltaTime * 20f;
            if (my_battery > 100f)
            {
                my_battery = 100f;
                stage = -1;
            }
        }

        // --------- tasks --------- //

        if (mine_ordercode == "HAUL")
        {

            // 1 = Locate item and go to it. Collect it upon getting close enough.
            // 2 = Go to the dropoff point. Deposit it upon getting close enough.

            if (stage == 1)
            {
                objective_distance = Vector3.Distance(self.position, mine_primary.transform.position);
                agent.SetDestination(mine_primary.transform.position);
                if (0.5f > objective_distance)
                {
                    string identity = mine_primary.GetComponent<BuildingIdentity>().my_identity;

                    if (identity == "Water") {ChangeItem("Water");}
                    if (identity == "Coal") {ChangeItem("Coal");}
                    if (identity == "Waste") {ChangeItem("Waste");}
                    if (identity == "RadioactiveOre") {ChangeItem("RadioactiveOre");}

                    Destroy(mine_primary);
                    stage = 2;
                }
            }
            if (stage == 2)
            {
                objective_distance = Vector3.Distance(self.position, mine_secondary.transform.position);
                agent.SetDestination(mine_secondary.transform.position);
                if (0.5f > objective_distance)
                {

                    if (item_in_hand == "Coal" && mine_secondary.GetComponent<CoalBurner>()) 
                    {
                        mine_secondary.GetComponent<CoalBurner>().coal_enroute -= 1;
                        mine_secondary.GetComponent<CoalBurner>().coal_inside += 1;
                        ChangeItem("Empty");
                    }

                    if (item_in_hand == "Water" && mine_secondary.GetComponent<NuclearReactor>()) 
                    {
                        mine_secondary.GetComponent<NuclearReactor>().water_enroute -= 1;
                        mine_secondary.GetComponent<NuclearReactor>().water_stored += 1;
                        ChangeItem("Empty");
                    }

                    if (item_in_hand == "RadioactiveOre" && mine_secondary.GetComponent<NuclearReactor>()) 
                    {
                        mine_secondary.GetComponent<NuclearReactor>().fuel_enroute -= 1;
                        mine_secondary.GetComponent<NuclearReactor>().fuel_stored += 1;
                        ChangeItem("Empty");
                    }

                    if (item_in_hand == "Waste" && mine_secondary.GetComponent<RadiationCage>()) 
                    {
                        mine_secondary.GetComponent<RadiationCage>().waste_enroute -= 1;
                        mine_secondary.GetComponent<RadiationCage>().waste_inside += 1;
                        ChangeItem("Empty");
                    }
                    
                    if (item_in_hand == "Coal" && mine_secondary.GetComponent<StationLoader>()) 
                    {
                        mine_secondary.GetComponent<StationLoader>().coal_enroute -= 1;
                        mine_secondary.GetComponent<StationLoader>().items_coal += 1;
                        ChangeItem("Empty");
                    }

                    if (item_in_hand == "Water" && mine_secondary.GetComponent<StationLoader>()) 
                    {
                        mine_secondary.GetComponent<StationLoader>().water_enroute -= 1;
                        mine_secondary.GetComponent<StationLoader>().items_water += 1;
                        ChangeItem("Empty");
                    }

                    if (item_in_hand == "Waste" && mine_secondary.GetComponent<StationLoader>()) 
                    {
                        mine_secondary.GetComponent<StationLoader>().waste_enroute -= 1;
                        mine_secondary.GetComponent<StationLoader>().items_waste += 1;
                        ChangeItem("Empty");
                    }

                    if (item_in_hand == "RadioactiveOre" && mine_secondary.GetComponent<StationLoader>()) 
                    {
                        mine_secondary.GetComponent<StationLoader>().radioactiveore_enroute -= 1;
                        mine_secondary.GetComponent<StationLoader>().items_radioactive_ore += 1;
                        ChangeItem("Empty");
                    }

                    CompleteTask();
                }
            }
        }

        if (mine_ordercode == "OPERATE/10")
        {
            operate_time = 10f;
            mine_ordercode = "OPERATE";
        }
        if (mine_ordercode == "OPERATE/5")
        {
            operate_time = 5f;
            mine_ordercode = "OPERATE";
        }

        if (mine_ordercode == "OPERATE")
        {

            // 1 = Go to the space.
            // 2 = Once at the space, Wait for the timer to elapse. Then deem task as complete.

            if (stage == 1)
            {
                objective_distance = Vector3.Distance(self.position, mine_primary.transform.position);
                agent.SetDestination(mine_primary.transform.position);
                if (0.5f > objective_distance)
                {
                    stage = 2;
                }
            }
            if (stage == 2)
            {
                operate_time -= Time.deltaTime;
                agent.SetDestination(mine_primary.transform.position);
                if (0f > operate_time)
                {

                    if (mine_primary.GetComponent<RadiationCage>()) 
                    {
                        mine_secondary.GetComponent<RadiationCage>().Operated();
                    }

                    CompleteTask();
                }
            }
        }

    }
}

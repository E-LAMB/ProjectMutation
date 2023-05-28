using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{

    public bool able_to_select;
    public int my_place;

    public int stage;
    // 0 - Awaiting Order

    public Transform self;
    public NavMeshAgent agent;

    public float my_battery;
    // Low power mode is 40%. During this, A 20% speed reduction is applied.
    // At 0%, This drone becomes disfunctional.

    public DroneOrderer my_orderer;

    public string mine_ordercode;
    public GameObject mine_primary;
    public GameObject mine_secondary;
    public string mine_status;

    public float objective_distance;

    public string item_in_hand;
    public GameObject[] items;
    public GameObject open_hand;
    public GameObject close_hand;

    public bool RequestedOrder(string proposed_ordercode, GameObject proposed_primary, GameObject proposed_secondary, string proposed_status)
    {

        if (proposed_primary == null)
        {
            return true;
        }
        if (proposed_secondary == null)
        {
            return true;
        }

        if (Vector3.Distance(proposed_primary.transform.position, self.position) > 60f)
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
        mine_status = "PEND";
        able_to_select = false;
        stage = 1;
        agent.enabled = true; 

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        agent.enabled = false;
        my_place = Mind.drone_ID_startup;
        Mind.drone_ID_startup += 1;
        able_to_select = true;
        my_orderer.bot_list[my_place] = gameObject;
        my_orderer.avaliable_bots += 1;
        ChangeItem("Empty");
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
        mine_status = "";
        stage = 0;
        able_to_select = true;
        my_orderer.avaliable_bots += 1;
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mine_ordercode == "HAUL/RADO/REAC")
        {
            if (stage == 1)
            {
                if (mine_primary == null) 
                {
                    mine_secondary.GetComponent<BuildingReactor>().fuel_enroute -= 1;
                    ChangeItem("Empty");
                    CompleteTask();
                } else 
                {
                    objective_distance = Vector3.Distance(mine_primary.transform.position, self.position);
                    agent.SetDestination(mine_primary.transform.position);
                    if (0.25f > objective_distance)
                    {
                        stage = 2;
                        Destroy(mine_primary);
                        ChangeItem("RadioactiveOre");
                    }
                }

            }
            if (stage == 2)
            {
                objective_distance = Vector3.Distance(mine_secondary.GetComponent<BuildingReactor>().interaction_point.transform.position, self.position);
                agent.SetDestination(mine_secondary.GetComponent<BuildingReactor>().interaction_point.transform.position);
                if (0.25f > objective_distance)
                {
                    mine_secondary.GetComponent<BuildingReactor>().fuel_enroute -= 1;
                    mine_secondary.GetComponent<BuildingReactor>().fuel_inside += 1;
                    ChangeItem("Empty");
                    CompleteTask();
                }
            }
        }

        if (mine_ordercode == "HAUL/WATE/REAC")
        {
            if (stage == 1)
            {
                if (mine_primary == null) 
                {
                    mine_secondary.GetComponent<BuildingReactor>().water_enroute -= 1;
                    ChangeItem("Empty");
                    CompleteTask();
                } else 
                {
                    objective_distance = Vector3.Distance(mine_primary.transform.position, self.position);
                    agent.SetDestination(mine_primary.transform.position);
                    if (0.25f > objective_distance)
                    {
                        stage = 2;
                        Destroy(mine_primary);
                        ChangeItem("Water");
                    }
                }
            }
            if (stage == 2)
            {
                objective_distance = Vector3.Distance(mine_secondary.GetComponent<BuildingReactor>().interaction_point.transform.position, self.position);
                agent.SetDestination(mine_secondary.GetComponent<BuildingReactor>().interaction_point.transform.position);
                if (0.25f > objective_distance)
                {
                    mine_secondary.GetComponent<BuildingReactor>().water_enroute -= 1;
                    mine_secondary.GetComponent<BuildingReactor>().water_inside += 1;
                    ChangeItem("Empty");
                    CompleteTask();
                }
            }
        }

        if (mine_ordercode == "HAUL/WAST/CAGE")
        {
            if (stage == 1)
            {
                if (mine_primary == null) 
                {
                    mine_secondary.GetComponent<BuildingCage>().waste_enroute -= 1;
                    ChangeItem("Empty");
                    CompleteTask();
                } else 
                {
                    objective_distance = Vector3.Distance(mine_primary.transform.position, self.position);
                    agent.SetDestination(mine_primary.transform.position);
                    if (0.25f > objective_distance)
                    {
                        stage = 2;
                        Destroy(mine_primary);
                        ChangeItem("Waste");
                    }
                }
            }
            if (stage == 2)
            {
                objective_distance = Vector3.Distance(mine_secondary.GetComponent<BuildingCage>().interaction_point.transform.position, self.position);
                agent.SetDestination(mine_secondary.GetComponent<BuildingCage>().interaction_point.transform.position);
                if (0.25f > objective_distance)
                {
                    mine_secondary.GetComponent<BuildingCage>().waste_enroute -= 1;
                    mine_secondary.GetComponent<BuildingCage>().waste_inside += 1;
                    ChangeItem("Empty");
                    CompleteTask();
                }
            }
        }


        if (mine_ordercode == "OPER/CAGE")
        {
            if (stage == 1)
            {
                objective_distance = Vector3.Distance(mine_primary.GetComponent<BuildingCage>().interaction_point.transform.position, self.position);
                agent.SetDestination(mine_primary.GetComponent<BuildingCage>().interaction_point.transform.position);
                if (0.25f > objective_distance)
                {
                    stage = 2;
                    objective_distance = 0f;
                    agent.SetDestination(self.position);
                }
            }
            if (stage == 2)
            {
                objective_distance += Time.deltaTime;
                if (mine_primary.GetComponent<BuildingCage>().waste_to_remove > 0 && objective_distance > 2f)
                {
                    mine_primary.GetComponent<BuildingCage>().waste_to_remove -= 1;
                    mine_primary.GetComponent<BuildingCage>().waste_inside -= 1;
                    objective_distance = 0f;
                }
                
                if (3f <= objective_distance)
                {
                    CompleteTask();
                }
            }
        }
    }
}

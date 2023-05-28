using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class DroneOrderer : MonoBehaviour
{

    // Orders ranked by Priority (1 being most important)

    public string[] order1_ordercode;
    public GameObject[] order1_primary;
    public GameObject[] order1_secondary;
    public string[] order1_status;

    // ------------------------------------------------ //

    public OrderFormat list_used;

    public int order_item;

    public string current_ordercode;
    public GameObject current_primary;
    public GameObject current_secondary;
    public string current_status;
    
    public int avaliable_bots;
    public GameObject[] bot_list;
    public int selected_bot;

    public bool making_selection;

    public bool assigned_order;

    public OrderFormat order;

    int scroller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Check(string submit_ordercode, GameObject submit_primary, GameObject submit_secondary)
    {
        if (!assigned_order && order1_status[scroller] != "Pending") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
    }

    public bool AddOrder(string submit_ordercode, GameObject submit_primary, GameObject submit_secondary)
    {

        assigned_order = false;
        scroller = 0;

        Check(submit_ordercode, submit_primary, submit_secondary);
        Check(submit_ordercode, submit_primary, submit_secondary);  
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 

        Check(submit_ordercode, submit_primary, submit_secondary);
        Check(submit_ordercode, submit_primary, submit_secondary);  
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 

        Check(submit_ordercode, submit_primary, submit_secondary);
        Check(submit_ordercode, submit_primary, submit_secondary);  
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 

        Check(submit_ordercode, submit_primary, submit_secondary);
        Check(submit_ordercode, submit_primary, submit_secondary);  
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 

        Check(submit_ordercode, submit_primary, submit_secondary);
        Check(submit_ordercode, submit_primary, submit_secondary);  
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 
        Check(submit_ordercode, submit_primary, submit_secondary); 

        if (!assigned_order) {Debug.Log("Was not able to be assigned");}

        if (assigned_order)
        {
            order_item = 0; 
            return true;
            
        } else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (avaliable_bots > 0 && !making_selection)
        {

            if (order1_status[order_item] == "Pending")
            {



            } else 
            {
                order_item += 1;
                if (order_item > 99)
                {
                    order_item = 0;
                }
            }

        } else if (making_selection)
        {
            selected_bot = Random.Range(0, bot_list.Length);

            if (bot_list[selected_bot] != null)
            {
                making_selection = bot_list[selected_bot].GetComponent<Drone>().RequestedOrder(current_ordercode, current_primary, current_secondary, current_status);
            
                if (current_primary == null || current_secondary == null)
                {

                    order1_primary[order_item] = null;
                    order1_secondary[order_item] = null;
                    order1_status[order_item] = "";
                    order1_ordercode[order_item] = "";

                    order_item = 0;
                }
            }

            if (!making_selection)
            {
                avaliable_bots -= 1;
                current_status = "ASSI";

                order1_status[order_item] = "ASSI";

                order_item = 1; 


                making_selection = false;
            }

            if (current_primary == null || current_secondary == null)
            {
                making_selection = false;
            }
        }
    }
}
*/
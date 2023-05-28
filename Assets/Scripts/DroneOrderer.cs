using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneOrderer : MonoBehaviour
{

    // Orders ranked by Priority (1 being most important)

    public string[] order1_ordercode;
    public GameObject[] order1_primary;
    public GameObject[] order1_secondary;
    public string[] order1_status;

    public string[] order2_ordercode;
    public GameObject[] order2_primary;
    public GameObject[] order2_secondary;
    public string[] order2_status;

    public string[] order3_ordercode;
    public GameObject[] order3_primary;
    public GameObject[] order3_secondary;
    public string[] order3_status;

    // ------------------------------------------------ //

    public OrderFormat list_used;

    public int current_orderlist;

    public int selected_orderlist_1;
    public int selected_orderlist_2;
    public int selected_orderlist_3;

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

    public bool AddOrder(string submit_ordercode, GameObject submit_primary, GameObject submit_secondary, int priority)
    {

        assigned_order = false;
        scroller = 0;

        if (priority == 1)
        {
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order1_status[scroller] != "PEND") {assigned_order = true; order1_ordercode[scroller] = submit_ordercode; order1_status[scroller] = "PEND"; order1_primary[scroller] = submit_primary; order1_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order) {priority -= 1; scroller = 0;}
        }
        if (priority == 2)
        {
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order2_status[scroller] != "PEND") {assigned_order = true; order2_ordercode[scroller] = submit_ordercode; order2_status[scroller] = "PEND"; order2_primary[scroller] = submit_primary; order2_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order) {priority -= 1; scroller = 0;}
        }
        if (priority == 3)
        {
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order && order3_status[scroller] != "PEND") {assigned_order = true; order3_ordercode[scroller] = submit_ordercode; order3_status[scroller] = "PEND"; order3_primary[scroller] = submit_primary; order3_secondary[scroller] = submit_secondary;} else {scroller += 1;}
            if (!assigned_order) {Debug.Log("Was not able to be assigned");}
        }

        if (assigned_order)
        {
            current_orderlist = 1; 
            selected_orderlist_1 = 0;
            selected_orderlist_2 = 0;
            selected_orderlist_3 = 0;
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

            if (current_orderlist == 1)
            {
                if (order1_status[selected_orderlist_1] == "PEND")
                {

                    Debug.Log("Is it pending in slot 1");

                    if (order1_primary[selected_orderlist_1] == null || order1_secondary[selected_orderlist_1] == null)
                    {
                        Debug.Log("This is null");
                        order1_primary[selected_orderlist_1] = null;
                        order1_secondary[selected_orderlist_1] = null;
                        order1_status[selected_orderlist_1] = "";
                        order1_ordercode[selected_orderlist_1] = "";
                        current_orderlist = 1; 
                        selected_orderlist_1 = 0;
                        selected_orderlist_2 = 0;
                        selected_orderlist_3 = 0;
                    } else
                    {
                        Debug.Log("Found Order");
                        making_selection = true;
                        current_ordercode = order1_ordercode[selected_orderlist_1];
                        current_primary = order1_primary[selected_orderlist_1];
                        current_secondary = order1_secondary[selected_orderlist_1];
                        current_status = order1_status[selected_orderlist_1];
                    }

                } else
                {
                    selected_orderlist_1 += 1;
                }

                if (selected_orderlist_1 == 20)
                {
                    current_orderlist += 1;
                    selected_orderlist_1 = 0;
                    selected_orderlist_2 = 0;
                    selected_orderlist_3 = 0;
                }
            }

            if (current_orderlist == 2)
            {
                if (order2_status[selected_orderlist_2] == "PEND")
                {
                    if (order2_primary[selected_orderlist_2] == null || order2_secondary[selected_orderlist_2] == null)
                    {
                        order2_primary[selected_orderlist_2] = null;
                        order2_secondary[selected_orderlist_2] = null;
                        order2_status[selected_orderlist_2] = "";
                        order2_ordercode[selected_orderlist_2] = "";
                        current_orderlist = 1; 
                        selected_orderlist_1 = 0;
                        selected_orderlist_2 = 0;
                        selected_orderlist_3 = 0;
                    } else
                    {
                        Debug.Log("Found Order");
                        making_selection = true;
                        current_ordercode = order2_ordercode[selected_orderlist_2];
                        current_primary = order2_primary[selected_orderlist_2];
                        current_secondary = order2_secondary[selected_orderlist_2];
                        current_status = order2_status[selected_orderlist_2];
                    }

                } else
                {
                    selected_orderlist_2 += 1;
                }

                if (selected_orderlist_2 == 20)
                {
                    current_orderlist += 1;
                    selected_orderlist_1 = 0;
                    selected_orderlist_2 = 0;
                    selected_orderlist_3 = 0;
                }
            }

            if (current_orderlist == 3)
            {
                if (order3_status[selected_orderlist_3] == "PEND")
                {
                    if (order3_primary[selected_orderlist_3] == null || order3_secondary[selected_orderlist_3] == null)
                    {
                        order3_primary[selected_orderlist_3] = null;
                        order3_secondary[selected_orderlist_3] = null;
                        order3_status[selected_orderlist_3] = "";
                        order3_ordercode[selected_orderlist_3] = "";
                        current_orderlist = 1; 
                        selected_orderlist_1 = 0;
                        selected_orderlist_2 = 0;
                        selected_orderlist_3 = 0;
                    } else
                    {
                        Debug.Log("Found Order");
                        making_selection = true;
                        current_ordercode = order3_ordercode[selected_orderlist_3];
                        current_primary = order3_primary[selected_orderlist_3];
                        current_secondary = order3_secondary[selected_orderlist_3];
                        current_status = order3_status[selected_orderlist_3];
                    }

                } else
                {
                    selected_orderlist_3 += 1;
                }

                if (selected_orderlist_3 == 20)
                {
                    current_orderlist = 1; 
                    selected_orderlist_1 = 0;
                    selected_orderlist_2 = 0;
                    selected_orderlist_3 = 0;
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
                    if (current_orderlist == 1)
                    {
                        order1_primary[selected_orderlist_1] = null;
                        order1_secondary[selected_orderlist_1] = null;
                        order1_status[selected_orderlist_1] = "";
                        order1_ordercode[selected_orderlist_1] = "";
                    }
                    if (current_orderlist == 2)
                    {
                        order2_primary[selected_orderlist_2] = null;
                        order2_secondary[selected_orderlist_2] = null;
                        order2_status[selected_orderlist_2] = "";
                        order2_ordercode[selected_orderlist_2] = "";
                    }
                    if (current_orderlist == 3)
                    {
                        order3_primary[selected_orderlist_3] = null;
                        order3_secondary[selected_orderlist_3] = null;
                        order3_status[selected_orderlist_3] = "";
                        order3_ordercode[selected_orderlist_3] = "";
                    }
                    current_orderlist = 1; 
                    selected_orderlist_1 = 0;
                    selected_orderlist_2 = 0;
                    selected_orderlist_3 = 0;
                }
            }

            if (!making_selection)
            {
                avaliable_bots -= 1;
                current_status = "ASSI";

                if (current_orderlist == 1)
                {
                    order1_status[selected_orderlist_1] = "ASSI";
                }
                if (current_orderlist == 2)
                {
                    order2_status[selected_orderlist_2] = "ASSI";
                }
                if (current_orderlist == 3)
                {
                    order3_status[selected_orderlist_3] = "ASSI";
                }

                current_orderlist = 1; 
                selected_orderlist_1 = 0;
                selected_orderlist_2 = 0;
                selected_orderlist_3 = 0;

                making_selection = false;
            }

            if (current_primary == null || current_secondary == null)
            {
                making_selection = false;
            }
        }
    }
}

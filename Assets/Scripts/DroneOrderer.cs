using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneOrderer : MonoBehaviour
{

    // Orders ranked by Priority (1 being most important)
    public OrderFormat[] order_1;
    public OrderFormat[] order_2;
    public OrderFormat[] order_3;

    public OrderFormat list_used;

    public int current_orderlist;

    public int selected_orderlist_1;
    public int selected_orderlist_2;
    public int selected_orderlist_3;

    public OrderFormat current_order;
    
    public int avaliable_bots;
    public GameObject[] bot_list;
    public int selected_bot;

    public bool making_selection;

    public bool assigned_order;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddOrder(OrderFormat order, int priority)
    {
        current_orderlist = 1; 
        selected_orderlist_1 = 0;
        selected_orderlist_2 = 0;
        selected_orderlist_3 = 0;

        assigned_order = false;

        if (priority == 1)
        {
            if (!assigned_order && order_1[00].order_status != "PEND") {order_1[00] = order; assigned_order = true;}
            if (!assigned_order && order_1[01].order_status != "PEND") {order_1[01] = order; assigned_order = true;}
            if (!assigned_order && order_1[02].order_status != "PEND") {order_1[02] = order; assigned_order = true;}
            if (!assigned_order && order_1[03].order_status != "PEND") {order_1[03] = order; assigned_order = true;}
            if (!assigned_order && order_1[04].order_status != "PEND") {order_1[04] = order; assigned_order = true;}
            if (!assigned_order && order_1[05].order_status != "PEND") {order_1[05] = order; assigned_order = true;}
            if (!assigned_order && order_1[06].order_status != "PEND") {order_1[06] = order; assigned_order = true;}
            if (!assigned_order && order_1[07].order_status != "PEND") {order_1[07] = order; assigned_order = true;}
            if (!assigned_order && order_1[08].order_status != "PEND") {order_1[08] = order; assigned_order = true;}
            if (!assigned_order && order_1[09].order_status != "PEND") {order_1[09] = order; assigned_order = true;}
            if (!assigned_order && order_1[10].order_status != "PEND") {order_1[10] = order; assigned_order = true;}
            if (!assigned_order && order_1[11].order_status != "PEND") {order_1[11] = order; assigned_order = true;}
            if (!assigned_order && order_1[12].order_status != "PEND") {order_1[12] = order; assigned_order = true;}
            if (!assigned_order && order_1[13].order_status != "PEND") {order_1[13] = order; assigned_order = true;}
            if (!assigned_order && order_1[14].order_status != "PEND") {order_1[14] = order; assigned_order = true;}
            if (!assigned_order && order_1[15].order_status != "PEND") {order_1[15] = order; assigned_order = true;}
            if (!assigned_order && order_1[16].order_status != "PEND") {order_1[16] = order; assigned_order = true;}
            if (!assigned_order && order_1[17].order_status != "PEND") {order_1[17] = order; assigned_order = true;}
            if (!assigned_order && order_1[18].order_status != "PEND") {order_1[18] = order; assigned_order = true;}
            if (!assigned_order && order_1[19].order_status != "PEND") {order_1[19] = order; assigned_order = true;}
            if (!assigned_order) {priority -= 1;}
        }
        if (priority == 2)
        {
            if (!assigned_order && order_2[00].order_status != "PEND") {order_2[00] = order; assigned_order = true;}
            if (!assigned_order && order_2[01].order_status != "PEND") {order_2[01] = order; assigned_order = true;}
            if (!assigned_order && order_2[02].order_status != "PEND") {order_2[02] = order; assigned_order = true;}
            if (!assigned_order && order_2[03].order_status != "PEND") {order_2[03] = order; assigned_order = true;}
            if (!assigned_order && order_2[04].order_status != "PEND") {order_2[04] = order; assigned_order = true;}
            if (!assigned_order && order_2[05].order_status != "PEND") {order_2[05] = order; assigned_order = true;}
            if (!assigned_order && order_2[06].order_status != "PEND") {order_2[06] = order; assigned_order = true;}
            if (!assigned_order && order_2[07].order_status != "PEND") {order_2[07] = order; assigned_order = true;}
            if (!assigned_order && order_2[08].order_status != "PEND") {order_2[08] = order; assigned_order = true;}
            if (!assigned_order && order_2[09].order_status != "PEND") {order_2[09] = order; assigned_order = true;}
            if (!assigned_order && order_2[10].order_status != "PEND") {order_2[10] = order; assigned_order = true;}
            if (!assigned_order && order_2[11].order_status != "PEND") {order_2[11] = order; assigned_order = true;}
            if (!assigned_order && order_2[12].order_status != "PEND") {order_2[12] = order; assigned_order = true;}
            if (!assigned_order && order_2[13].order_status != "PEND") {order_2[13] = order; assigned_order = true;}
            if (!assigned_order && order_2[14].order_status != "PEND") {order_2[14] = order; assigned_order = true;}
            if (!assigned_order && order_2[15].order_status != "PEND") {order_2[15] = order; assigned_order = true;}
            if (!assigned_order && order_2[16].order_status != "PEND") {order_2[16] = order; assigned_order = true;}
            if (!assigned_order && order_2[17].order_status != "PEND") {order_2[17] = order; assigned_order = true;}
            if (!assigned_order && order_2[18].order_status != "PEND") {order_2[18] = order; assigned_order = true;}
            if (!assigned_order && order_2[19].order_status != "PEND") {order_2[19] = order; assigned_order = true;}
            if (!assigned_order) {priority -= 1;}
        }
        if (priority == 3)
        {
            if (!assigned_order && order_3[00].order_status != "PEND") {order_3[00] = order; assigned_order = true;}
            if (!assigned_order && order_3[01].order_status != "PEND") {order_3[01] = order; assigned_order = true;}
            if (!assigned_order && order_3[02].order_status != "PEND") {order_3[02] = order; assigned_order = true;}
            if (!assigned_order && order_3[03].order_status != "PEND") {order_3[03] = order; assigned_order = true;}
            if (!assigned_order && order_3[04].order_status != "PEND") {order_3[04] = order; assigned_order = true;}
            if (!assigned_order && order_3[05].order_status != "PEND") {order_3[05] = order; assigned_order = true;}
            if (!assigned_order && order_3[06].order_status != "PEND") {order_3[06] = order; assigned_order = true;}
            if (!assigned_order && order_3[07].order_status != "PEND") {order_3[07] = order; assigned_order = true;}
            if (!assigned_order && order_3[08].order_status != "PEND") {order_3[08] = order; assigned_order = true;}
            if (!assigned_order && order_3[09].order_status != "PEND") {order_3[09] = order; assigned_order = true;}
            if (!assigned_order && order_3[10].order_status != "PEND") {order_3[10] = order; assigned_order = true;}
            if (!assigned_order && order_3[11].order_status != "PEND") {order_3[11] = order; assigned_order = true;}
            if (!assigned_order && order_3[12].order_status != "PEND") {order_3[12] = order; assigned_order = true;}
            if (!assigned_order && order_3[13].order_status != "PEND") {order_3[13] = order; assigned_order = true;}
            if (!assigned_order && order_3[14].order_status != "PEND") {order_3[14] = order; assigned_order = true;}
            if (!assigned_order && order_3[15].order_status != "PEND") {order_3[15] = order; assigned_order = true;}
            if (!assigned_order && order_3[16].order_status != "PEND") {order_3[16] = order; assigned_order = true;}
            if (!assigned_order && order_3[17].order_status != "PEND") {order_3[17] = order; assigned_order = true;}
            if (!assigned_order && order_3[18].order_status != "PEND") {order_3[18] = order; assigned_order = true;}
            if (!assigned_order && order_3[19].order_status != "PEND") {order_3[19] = order; assigned_order = true;}
            if (!assigned_order) {Debug.Log("Was not able to be assigned");}
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (avaliable_bots > 0 && !making_selection)
        {

            if (current_orderlist == 1)
            {
                if (order_1[selected_orderlist_1].order_status == "PEND")
                {
                    Debug.Log("Found Order");
                    making_selection = true;
                    current_order = order_1[selected_orderlist_1];

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
                if (order_2[selected_orderlist_2].order_status == "PEND")
                {
                    Debug.Log("Found Order");
                    making_selection = true;
                    current_order = order_2[selected_orderlist_2];

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
                if (order_3[selected_orderlist_3].order_status == "PEND")
                {
                    Debug.Log("Found Order");
                    making_selection = true;
                    current_order = order_3[selected_orderlist_3];

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
                making_selection = bot_list[selected_bot].GetComponent<Drone>().RequestedOrder(current_order);
            }

            if (!making_selection)
            {
                avaliable_bots -= 1;
                current_order.order_status = "ASSI";

                current_orderlist = 1; 
                selected_orderlist_1 = 0;
                selected_orderlist_2 = 0;
                selected_orderlist_3 = 0;

                if (current_orderlist == 1)
                {
                    order_1[selected_orderlist_1].order_status = "ASSI";
                }
                if (current_orderlist == 2)
                {
                    order_2[selected_orderlist_2].order_status = "ASSI";
                }
                if (current_orderlist == 3)
                {
                    order_3[selected_orderlist_3].order_status = "ASSI";
                }
            }
        }
    }
}

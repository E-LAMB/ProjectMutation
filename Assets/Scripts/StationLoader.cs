using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationLoader : MonoBehaviour
{

    public int items_coal;
    public int items_water;

    public float time_back;

    public Train my_train;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (items_coal == 0 && items_water == 0)
        {
            my_train.loader_empty = true;
        } else
        {
            my_train.loader_empty = false;
        }

        time_back += Time.deltaTime;
        if (time_back > 0.25f && my_train.accepting_items)
        {
            time_back = 0f;
            if (items_coal > 0)
            {
                my_train.LoadedItem();
                items_coal -= 1;
                my_train.items_coal += 1;
            } else if (items_water > 0)
            {
                my_train.LoadedItem();
                items_water -= 1;
                my_train.items_water += 1;
            }
        }   
    }
}

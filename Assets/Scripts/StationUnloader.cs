using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationUnloader : MonoBehaviour
{
    
    public Transform the_spawn;

    public GameObject item_coal;
    public GameObject item_water;

    public void Unloader(string the_item)
    {
        if (the_item == "COAL") {Instantiate(item_coal, the_spawn.position, the_spawn.localRotation);}
        if (the_item == "WATER") {Instantiate(item_water, the_spawn.position, the_spawn.localRotation);}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

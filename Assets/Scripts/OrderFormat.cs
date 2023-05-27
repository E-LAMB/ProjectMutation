using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OrderFormat 
{
    
    public string order_code;

    // OPER/MINE/5f             Operate a Mine (takes five seconds)
    // OPER/CAGE/15f            Operate a Cage (takes sixteen seconds)
    // OPER/WELL/5f             Operate a Well (takes five seconds)
    // OPER/KITCH/10f           Operate a Kitchen (takes ten seconds)

    // MAIN/PANE                Maintain a Solar Panel
    // MAIN/HARV                Maintain a Harvester
    // MAIN/PWEL                Maintain a Power Well

    // HAUL/COAL/STAT           Haul Coal to a Station Loader
    // HAUL/COAL/CBUR           Haul Coal to a Coal Burner
    // HAUL/COAL/KITCH          Haul Coal to a Kitchen

    // HAUL/WATE/STAT           Haul Water to a Station Loader
    // HAUL/WATE/REAC           Haul Water to a Nuclear Reactor
    // HAUL/WATE/IRRI           Haul Water to a Incinerator
    // HAUL/WATE/HOSP           Haul Water to a Clone Hospital

    // HAUL/GROW/KITCH          Haul Grown Plants to a Kitchen

    // HAUL/FOOD/STAT           Haul Food to a Station Loader
    // HAUL/FOOD/HOUS           Haul Food to a House

    // HAUL/RADO/STAT           Haul Radioactive Ore to a Station Loader

    // HAUL/WAST/CAGE           Haul Nuclear Waste to a Cage

    // HAUL/FECA/INCI           Haul Fecal Matter to an Incinerator

    // HAUL/BODY/ANAL           Haul Body to Analyser

    // HAUL/DATA/STAT           Haul Data to a Station Loader
    // HAUL/DATA/SOLV           Haul Data to a Solver

    // The object where the order originated from
    public GameObject order_origin;

    // The other object associated with this action (if any)
    public GameObject secondary_object;

    public string order_status;
    // PEND        - Pending
    // ASSI        - Assigned
    // COMP        - Completed
    // INPR        - In Progress

}

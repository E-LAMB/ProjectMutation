using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mind 
{
    
    // The maximum power capacity of a Power Pylon
    public static float max_pylon_capacity = 5f;

    // The maximum power transferred by a Power Pylon
    public static float max_pylon_transfer = 2.5f;

    // The power lost when Power Pylons transfer energy between each other (1/x)
    public static float pylon_power_loss = 40f;

    // The speed of which the drone scans the surrounding area
    public static float drone_scanning_speed = 8f;

    // How many drones are currently decommissioned (because of a dead battery)
    public static int drones_decommissioned_battery = 0;

}

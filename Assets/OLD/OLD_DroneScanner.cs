using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class OLD_DroneScanner : MonoBehaviour
{

    public bool activated;

    public float maximum_range;
    public float current_range;

    public bool target_out_of_range;

    public string target = "none";
    public string instructions;

    public bool disable_once_got;

    public GameObject found_object;
    public Transform search_radius;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Proc");
        //Debug.Log(other.name);

        // Debug.Log(other.gameObject);
        Debug.Log(other.gameObject.GetComponent<BuildingIdentity>().my_identity);

        if (instructions == "CoalGenerator")
        {

            if (other.gameObject.GetComponent<BuildingIdentity>() && activated)
            {
                if (!other.gameObject.GetComponent<BuildingIdentity>().should_be_ignored && other.gameObject.GetComponent<BuildingIdentity>().my_identity == target)
                {
                    if (other.gameObject.GetComponent<CoalGenerator>().remaining_fuel < 15f)
                    {
                        found_object = other.gameObject;
                        activated = false;
                        if (disable_once_got)
                        {
                            other.gameObject.GetComponent<BuildingIdentity>().should_be_ignored = true;
                        }
                    }
                }
            }

        } else // NORMAL
        {
            if (other.gameObject.GetComponent<BuildingIdentity>() && activated)
            {
                if (!other.gameObject.GetComponent<BuildingIdentity>().should_be_ignored && other.gameObject.GetComponent<BuildingIdentity>().my_identity == target)
                {
                    found_object = other.gameObject;
                    activated = false;
                    if (disable_once_got)
                    {
                        other.gameObject.GetComponent<BuildingIdentity>().should_be_ignored = true;
                    }
                }
            }
        }

    }

    public void BeginSearch(string new_target, float new_range, bool ignore_after)
    {
        disable_once_got = ignore_after;
        instructions = new_target;
        maximum_range = new_range;
        target = new_target;
        found_object = null;
        activated = true;
        target_out_of_range = false;
    }

    void Update()
    {

        if (activated)
        {
            current_range += Mind.drone_scanning_speed * Time.deltaTime;
            if (current_range > maximum_range)
            {
                activated = false;
                target_out_of_range = true;
            }

        } else
        {
            current_range = 0f;
        }

        search_radius.localScale = new Vector3(current_range, current_range, current_range);

    }

}
*/
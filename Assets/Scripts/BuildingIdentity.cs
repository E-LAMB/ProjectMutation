using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingIdentity : MonoBehaviour
{
    
    public string my_identity;
    public bool should_be_ignored;

    public bool can_be_chosen(string requested_item, Transform other_location)
    {
        if (my_identity == requested_item && !should_be_ignored && 40f > Vector3.Distance(gameObject.transform.position, other_location.position))
        {
            should_be_ignored = true;
            return true;
        } else
        {
            return false;
        }
    }

}

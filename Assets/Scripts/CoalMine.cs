using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalMine : MonoBehaviour
{

    public PylonNode my_pylon;

    public float internal_power_supply;
    
    public GameObject coal_block;
    public Transform spawn_point;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void DrawPower()
    {
        if (my_pylon != null)
        {

            float needed_power = 30f - internal_power_supply;
            needed_power = needed_power / 4f;
            needed_power = needed_power * Time.deltaTime;
            if (needed_power > Mind.max_pylon_transfer)
            {
                needed_power = Mind.max_pylon_transfer;
            }

            if (my_pylon.internal_power_supply >= 0f)
            {
                if (needed_power > my_pylon.internal_power_supply)
                {
                    needed_power = my_pylon.internal_power_supply;
                }

                my_pylon.internal_power_supply -= needed_power;
                internal_power_supply += needed_power - (needed_power * (1f / Mind.pylon_power_loss));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        DrawPower();

        internal_power_supply += Time.deltaTime / 5f;

        if (internal_power_supply > 20f)
        {
            internal_power_supply -= 20f;
            Instantiate(coal_block, spawn_point.position, spawn_point.localRotation);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapMeter : MonoBehaviour
{
    [SerializeField] private GameObject stopper;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            //Debug.DrawRay(stopper.transform.position, new Vector3(0, 0, 20), Color.white, 1f);

            if (Physics.Raycast(stopper.transform.position, new Vector3(0, 0, 1), out var hit)) 
            {
                Debug.Log(hit.transform.gameObject);
            }
        }
    }

    
}

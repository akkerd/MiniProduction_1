using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCollision : MonoBehaviour {

    public GameObject Table;

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject== Table)
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Invoke("CloseDown", 5);
        }

   
    }

    public void CloseDown()
    {
        GetComponent<SlimeSpawn>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = Table.transform;
        Table.GetComponent<TableScript>().Moving = true;
        GetComponent<TableCollision>().enabled = false;
    }
}

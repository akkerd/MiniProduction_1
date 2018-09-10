using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCollision : MonoBehaviour {

    public GameObject Table;
    

    void OnCollisionEnter(Collision collision)
    {
     
        if (collision.gameObject== Table)
        {
            
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

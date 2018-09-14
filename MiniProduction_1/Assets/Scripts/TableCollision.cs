using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCollision : MonoBehaviour {

    public GameObject Table;
    

    void OnCollisionEnter(Collision collision)
    {
     
        if (collision.gameObject== Table)
        {

            Invoke("PChange", 2f);
            Invoke("CloseDown", 4);
        }

   
    }

    public void PChange()
    {
        GetComponent<SlimeSpawn>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = Table.transform;
        Table.GetComponent<TableScript>().ChangeParent();
    }

    public void CloseDown()
    {
        
       
        Table.GetComponent<TableScript>().Moving = true;
        GetComponent<TableCollision>().enabled = false;
    }
}

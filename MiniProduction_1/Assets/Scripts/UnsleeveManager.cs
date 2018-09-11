using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnsleeveManager : Manager<UnsleeveManager> {
    [SerializeField]
    GameObject brick;
    int count=0;
    [SerializeField]
    Transform[] EndPosistions = new Transform[5];

    GameObject Unsleeving;
    GameObject Stacks;

    // Use this for initialization
    void Start () {
       // CreateBodybag();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void CreateBodybag()
    {

       Unsleeving = Instantiate(brick, new Vector3(-3.88f, 0.78f, 4.54f), Quaternion.identity);
        Unsleeving.GetComponent<EndPosReceiver>().EndTransform = EndPosistions[count];
    
        count += 1;
    }

    public void DestroyPrefab()
    {
        Destroy(Unsleeving);

        if (UnsleeveManager.Instance.count == ContractController.Instance.GetCurrentContract().GetNumberOfStacks())
        {
            StackDeliveryController.Instance.ShowStacks();   
        }
    }
    
}

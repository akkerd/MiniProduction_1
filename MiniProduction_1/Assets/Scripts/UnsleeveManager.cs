using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnsleeveManager : Manager<UnsleeveManager> {
    [SerializeField]
    GameObject brick;
    public int count=0;
    [SerializeField]
    Transform[] EndPosistions = new Transform[5];

    GameObject Unsleeving;
    GameObject Stacks;

    public bool isCurrentlyUnsleeving = false;

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
        Unsleeving.GetComponent<EndPosReceiver>().Setpos( EndPosistions[count]);
    
        count += 1;
        isCurrentlyUnsleeving = true;
    }

    public void DestroyPrefab()
    {
        //Destroy(Unsleeving);
        Unsleeving.SetActive(false);
        MoveSleeveForwardScript.Instance.MoveSleeveBackwards();
        isCurrentlyUnsleeving = false;
        //Might have to call convayorController.RemoveCenterSleeveFromShell()
        SleeveController.Instance.GetActiveSleeves()[ConveyorController.Instance.currentCenterOfLevelSleeves].isEmpty = true;
        if (count == ContractController.Instance.GetCurrentContract().GetNumberOfStacks() && !StackDeliveryController.Instance.stacksCreated)
        {
            StackDeliveryController.Instance.ShowStacks();   
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDeliveryController : Manager<StackDeliveryController> {
    [SerializeField]
    GameObject Stacks;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowStacks()
    {
        for (int i = 0; i < ContractController.Instance.GetCurrentContract().GetNumberOfStacks(); i++)
        {
            //GameObject stack = Instantiate((GameObject)Resources.Load("Stack"));
            GameObject stack = (GameObject)Instantiate(Resources.Load("Stack"));
            stack.name = "Stack";
            stack.transform.SetParent(Stacks.transform);
            stack.transform.position = new Vector3(Stacks.transform.position.x, Stacks.transform.position.y+(i*0.05f), Stacks.transform.position.z);


        }
    }
}

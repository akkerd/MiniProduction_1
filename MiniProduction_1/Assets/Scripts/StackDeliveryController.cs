using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDeliveryController : Manager<StackDeliveryController> {
    [SerializeField]
    GameObject Stacks;
    int[] stackCombinations;
    int stackHomesFound = 0;
    [SerializeField]
	GameObject[] colliders;
    public void CombinedStackWithSleeve(int stackNumber, int sleeveNumber)
    {
        stackCombinations[stackNumber] = sleeveNumber;
        stackHomesFound++;
        if (stackHomesFound == stackCombinations.Length)
        {
            AllStackCombined();
        }
    }
    void AllStackCombined()
    {
        ScoringController.Instance.CalculateReport(stackCombinations);
    }

    public void ShowStacks()
    {
        stackCombinations = new int[ContractController.Instance.GetCurrentContract().GetNumberOfStacks()];
        int stackHomesFound = 0;

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].SetActive(false);
        }

        for (int i = 0; i < ContractController.Instance.GetCurrentContract().GetNumberOfStacks(); i++)
        {
            //GameObject stack = Instantiate((GameObject)Resources.Load("Stack"));
            GameObject stack = (GameObject)Instantiate(Resources.Load("Stack"));
            stack.name = "Stack";
            stack.transform.SetParent(Stacks.transform);
            stack.transform.position = new Vector3(Stacks.transform.position.x, Stacks.transform.position.y+(i*0.05f), Stacks.transform.position.z);
            stack.GetComponent<StackObject>().stackNumber = i;
            colliders[i].SetActive(true);
        }
    }
}

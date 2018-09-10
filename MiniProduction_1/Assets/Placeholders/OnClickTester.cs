using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickTester : MonoBehaviour,IPointerClickHandler {

	public int numberToRespond;
	public void OnPointerClick(PointerEventData eventData)
    {
        ContractSelectionUIController.Instance.InteractionWithContract(numberToRespond);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

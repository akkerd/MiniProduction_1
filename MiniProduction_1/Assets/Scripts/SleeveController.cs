using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleeveController : Manager<SleeveController> {

	List<Sleeve> sleevesAvaliable;
	

	protected override void onAwake()
	{
		base.onAwake();
		sleevesAvaliable = new List<Sleeve>();
		//AddSleeves(12);
	}
	
		

	public void AddSleeves(int numberOfNewSleeves)
	{
		for (int i = 0; i < numberOfNewSleeves; i++)
		{
			AddSleeve();
		}
	}
	public void AddSleeve(Sleeve addedSleeve)
	{	
		sleevesAvaliable.Add(addedSleeve);
	}

	void AddSleeve()
	{
		sleevesAvaliable.Add(SleeveGenerator.Instance.GenerateSleeve());
	}

	public void UpdateSleevesInConveyor()
	{
		ConveyorController.Instance.SetupConveyor(sleevesAvaliable.ToArray());
	}
	public Sleeve[] GetActiveSleeves()
	{
		return sleevesAvaliable.ToArray();
	}
	public void UseSleeve(int positionInAvaliableSleeves)
	{
		SaveLoadController.Instance.UseSleeve(sleevesAvaliable[positionInAvaliableSleeves].id);
	}
}

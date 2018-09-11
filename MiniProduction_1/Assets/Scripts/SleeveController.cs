using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleeveController : Manager<SleeveController> {

	List<Sleeve> sleevesAvaliable;

	void Start()
	{
		sleevesAvaliable = new List<Sleeve>();
		AddSleeves(12);
		UpdateSleevesInConveyor();
	}

	public void AddSleeves(int numberOfNewSleeves)
	{
		for (int i = 0; i < numberOfNewSleeves; i++)
		{
			AddSleeve();
		}
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleeveGenerator : Manager<SleeveGenerator> {

	float value = 0.0f;
	public Sleeve GenerateSleeve()
	{
		Sleeve tempSleeve = new Sleeve();
		tempSleeve.isEmpty = false;
		tempSleeve.ColorOfSleeve = new Color(value,value,value,1);
		value +=0.05f;
		return tempSleeve;
	}
}

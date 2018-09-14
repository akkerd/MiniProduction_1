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
	public Sleeve GenerateSleeve(bool isRandom)
	{
		if (!isRandom)
		{
			return GenerateSleeve();
		}
		Sleeve tempSleeve = new Sleeve();
		tempSleeve.isEmpty = false;
		tempSleeve.ColorOfSleeve = new Color(value,value,value,1);
		value +=0.05f;
		int[] tempStatsArray = GenerateRandomStats();
		bool tempSexBool = GenerateRandomBool();
		tempSleeve.SetStats(tempStatsArray[0],tempStatsArray[1],tempStatsArray[2],tempStatsArray[3],tempStatsArray[4],tempSexBool);
		float age,height,weight,bodyFatRatio,neuronCapacity;
		GenerateVisibleStats(tempSleeve,out age,out height,out weight,out bodyFatRatio,out neuronCapacity);
		tempSleeve.SetVisibleStats(age,height,weight,bodyFatRatio,neuronCapacity);
		return tempSleeve;
	}
	int[] GenerateRandomStats()
	{
		int[] tempArray = new int[5];
		for (int i = 0; i < tempArray.Length; i++)
		{
			tempArray[i] = Random.Range(0,100);
		}
		return tempArray;
	}
	bool GenerateRandomBool()
	{
		float randomNumber = Random.Range(0.0f,1.0f);
		if (randomNumber > 0.5f)
		{
			return true;
		}
		return false;
	}
	public void GenerateVisibleStats(Sleeve sleeveToGenerateStatsFrom, out float age, out float height, out float weight, out float bodyFatRatio,out float neuronCapacity)
	{
		int[] stats;
		sleeveToGenerateStatsFrom.GetStats(out stats);
		//float tempCal = (200-stats[0]-stats[1]+stats[3]) / 300.0f;
		age = Mathf.Pow(((200.0f-(float)stats[0]-(float)stats[1]+(float)stats[3])/300.0f)*2-1,3.0f)/2 +0.5f;
		height = Mathf.Pow((((float)stats[0]+(float)stats[4])/200.0f)*2-1,3.0f)/2 +0.5f;
		weight = Mathf.Pow(((200.0f-(float)stats[1]-(float)stats[4])/200.0f)*2-1,3.0f)/2 +0.5f;
		bodyFatRatio = Mathf.Pow(((200.0f-(float)stats[0]-(float)stats[4])/200.0f)*2-1,3.0f)/2 +0.5f;
		neuronCapacity = Mathf.Pow((((float)stats[2]+(float)stats[3])/200.0f)*2-1,3.0f)/2 +0.5f;

	}
}

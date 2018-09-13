using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve {

    Color colorOfSleeve;
    public bool isEmpty;

    //Behind the scenes stats
    int strength;
	int agility;
	int intelligence;
	int knowledge;
	int beauty;
	bool isFemale;

    //Presentable Stats
    float age;
    float height;
    float weight;
    float bodyFatRatio;
    float neuronCapacity;
    public int id;

    int agemin = 18;
    int agemax = 76;
    int heightMin = 160;
    int heightMax = 210;
    int weightmin = 60;
    int weightmax = 160;
    int bodyFatRatiomin = 5;
    int bodyFatRatiomax = 22;
    int neuronCapicitymin = 60;
    int neuronCapicitymax = 150;


    public Sleeve()
    {

    }
    public Sleeve(bool makeEmpty)
    {
        isEmpty = true;
    }
    public Sleeve(int newId, int[] stats, bool isMale)
    {
        SetStats(stats[0],stats[1],stats[2],stats[3],stats[4],isMale);
        id = newId;
    }
    public void SetStats(int newStrenght, int newAgility, int newIntelligence, int newKnowledge, int newBeauty, bool isMale)
    {
        strength = newStrenght;
        agility = newAgility;
        intelligence = newIntelligence;
        knowledge = newKnowledge;
        beauty = newBeauty;
        isFemale = !isMale;
        GenerateVisibleStats(this,out age, out height,out weight, out bodyFatRatio, out neuronCapacity);
    }
    public void SetVisibleStats(float newAge, float newHeight, float newWeight,float newBodyFatRatio,float newNeuronCapacity)
    {
        age = newAge;
        height = newHeight;
        weight = newWeight;
        bodyFatRatio = newBodyFatRatio;
        neuronCapacity = newNeuronCapacity;
    }
    public void GetStats(out int[] stats)
    {
        stats = new int[]{strength,agility,intelligence,knowledge,beauty};
    }
    public void GetVisibleStats(out float[] visibleStats, out bool isMale)
    {
        visibleStats = new float[] {age,height,weight,bodyFatRatio,neuronCapacity};
        isMale = !isFemale;
    }
    
    public Color ColorOfSleeve
    {
        get
        {
            return colorOfSleeve;
        }

        set
        {
            colorOfSleeve = value;
        }
    }
    public bool GetIsFemale()
    {
        return isFemale;
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

        age = Mathf.Lerp(agemin,agemax,age);
        height = Mathf.Lerp(heightMin,heightMax,height);
        //weight = Mathf.Lerp(weightmin,weightmax,weight);
        //bodyFatRatio = Mathf.Lerp(bodyFatRatiomin,bodyFatRatiomax,bodyFatRatio);
        //neuronCapacity = Mathf.Lerp(neuronCapicitymin,neuronCapicitymax,neuronCapacity);
	}
}

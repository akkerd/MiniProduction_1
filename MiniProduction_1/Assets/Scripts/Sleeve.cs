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
    }
    public void SetVisibleStats(float newAge, float newHeight, float newWeight,float newBodyFatRatio,float newNeuronCapacity)
    {
        age = newAge;
        height = newHeight;
        weight = newWeight;
        bodyFatRatio = newBodyFatRatio;
        neuronCapacity = newNeuronCapacity;
    }
    public void GetStats(out int[] stats, out bool isMale)
    {
        stats = new int[]{strength,agility,intelligence,knowledge,beauty};
        isMale = !isFemale;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack {
	public string stackName;
	public string description;
	int lStrength;
	int uStrength;
	int lagility;
	int uagility;
	int lintelligence;
	int uintelligence;
	int lknowledge;
	int uknowledge;
	int lbeauty;
	int ubeauty;
	bool isFemale;
	public Stack(string newName)
	{
		stackName = newName;
	}
	public Stack(int[] LowerAndUpperStats,bool isMale, string newDescription)
	{
		lStrength = LowerAndUpperStats[0];
		uStrength = LowerAndUpperStats[1];
		lagility = LowerAndUpperStats[2];
		lagility = LowerAndUpperStats[3];
		lintelligence = LowerAndUpperStats[4];
		uintelligence = LowerAndUpperStats[5];
		lknowledge = LowerAndUpperStats[6];
		uknowledge = LowerAndUpperStats[7];
		lbeauty = LowerAndUpperStats[8];
		ubeauty = LowerAndUpperStats[9];
		isFemale = !isMale;
		description = newDescription;
		Debug.Log(description);
	}

	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerContracts : MonoBehaviour {

	//string description; lStrength; uStrength; lagility; uagility; lintelligence; uintelligence; lknowledge; uknowledge; lbeauty; int ubeauty; bool isFemale;
	public int[] numberOfStacksInContract;
	public int[] numberOfSleevesInContract;
	public Contract[] contracts;

	List<Sleeve> allSleeves;

	int currentFileNumber = 0;
	int currentSleeveIdNumber = -1;
	public void Setup()
	{
		ReadList(FindAllFiles().ToArray());
		
	}
	
	List<string[]> FindAllFiles()
	{
		List<string[]> files = new List<string[]>();
		int timesRan = 0;
		do{
			//string fileName = "Assets/Resources/Contracts/Contract" + currentFileNumber +".txt";
			//string[] tempArray = CSVUtilities.Reader(fileName);
			TextAsset filename = (TextAsset)Resources.Load("Contracts/Contract" + currentFileNumber);
			if (filename == null)
			{
				break;
			}
			string[] tempArray = CSVUtilities.fileToArr(filename.text);
			if (tempArray == null)
			{
				break;
			}
			currentFileNumber++;
			timesRan++;
			files.Add(tempArray);
		} while(timesRan < 50);
		SetupAllMainArrays(currentFileNumber);
		return files;
	}
	void ReadList(string[][] listOfStrings)
	{
		for (int i = 0; i < listOfStrings.Length; i++)
		{
			int.TryParse(listOfStrings[i][0],out numberOfStacksInContract[i]);
			int.TryParse(listOfStrings[i][1],out numberOfSleevesInContract[i]);
			contracts[i] = CenerateContract(listOfStrings[i],numberOfStacksInContract[i], numberOfSleevesInContract[i],i);
		}
	}
	void SetupAllMainArrays(int numberOfContracts)
	{
		numberOfStacksInContract = new int[numberOfContracts];
		numberOfSleevesInContract = new int[numberOfContracts];
		contracts = new Contract[numberOfContracts];
		allSleeves = new List<Sleeve>();

	}

	Contract CenerateContract(string[] stringToLookThrough, int numberOfStacks, int numberOfSleeves, int contractId)
	{
		
		List<Stack> stacksInContract = new List<Stack>();
		List<Sleeve> sleeveInContract = new List<Sleeve>();

		int currentStringNumber = 3;
		//FindingStacks
		for (int i = 0; i < numberOfStacks; i++)
		{
			stacksInContract.Add(ReadStack(stringToLookThrough[currentStringNumber]));
			currentStringNumber++;
		}
		for (int i = 0; i < numberOfSleeves; i++)
		{
			allSleeves.Add(ReadSleeve(stringToLookThrough[currentStringNumber]));
			sleeveInContract.Add(allSleeves[allSleeves.Count - 1]);
			currentStringNumber++;
		}
		return new Contract(contractId,stringToLookThrough[2],stacksInContract.ToArray(), sleeveInContract.ToArray());
	}

	Stack ReadStack(string line)
	{
		//Seperate string with , put the things in the correct place when creating a new stack
		string[] seperatedLine = CSVUtilities.stringToArr(line);
		int[] stackStats = new int[10];
		int.TryParse(seperatedLine[0],out stackStats[0]);
		int.TryParse(seperatedLine[1],out stackStats[1]);
		int.TryParse(seperatedLine[2],out stackStats[2]);
		int.TryParse(seperatedLine[3],out stackStats[3]);
		int.TryParse(seperatedLine[4],out stackStats[4]);
		int.TryParse(seperatedLine[5],out stackStats[5]);
		int.TryParse(seperatedLine[6],out stackStats[6]);
		int.TryParse(seperatedLine[7],out stackStats[7]);
		int.TryParse(seperatedLine[8],out stackStats[8]);
		int.TryParse(seperatedLine[9],out stackStats[9]);


		bool isMale = false;
		int tempInt;
		int.TryParse(seperatedLine[10],out tempInt);
		if (tempInt == 1)
		{
			isMale = true;
		}

		return new Stack(stackStats,isMale,seperatedLine[11]);
	}
	Sleeve ReadSleeve(string line)
	{
		string[] seperatedLine = CSVUtilities.stringToArr(line);
		int[] sleeveStats = new int[10];
		int.TryParse(seperatedLine[0],out sleeveStats[0]);
		int.TryParse(seperatedLine[1],out sleeveStats[1]);
		int.TryParse(seperatedLine[2],out sleeveStats[2]);
		int.TryParse(seperatedLine[3],out sleeveStats[3]);
		int.TryParse(seperatedLine[4],out sleeveStats[4]);

		bool isMale = false;
		int tempInt;
		int.TryParse(seperatedLine[5],out tempInt);
		if (tempInt == 1)
		{
			isMale = true;
		}
		currentSleeveIdNumber++;
		return new Sleeve(currentSleeveIdNumber,sleeveStats,isMale);
	}

	

}

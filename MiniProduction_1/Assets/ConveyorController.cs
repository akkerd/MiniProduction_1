using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : Manager<ConveyorController> {

    int sleevesFromCenter = 4;
    Vector3 startPositionOfConveyor;
    Vector3 endPositionOfConveyor;

    Sleeve[] sleevesInLevel;
    ConveyorSleeve[] conveyorSleves;

    //Used to get the correct sleeve in to the teleported body
    public int currentCenterOfConveyor;
    public int conveyorSleevesOnEachSide;

    //Used as a meassure for when to teleport
    public float movedFromCenter = 0;
    float movedFromCenterMax = 0.7f;

    // Use this for initialization
    void Start()
    {
        //Setup
        sleevesInLevel = LevelSleeves.Instance.GetLevelSleeves();
        conveyorSleves = new ConveyorSleeve[transform.childCount];
        if (sleevesInLevel.Length < conveyorSleves.Length)
        {
            AddEmptySleeves();
        }
        currentCenterOfConveyor = Mathf.CeilToInt(conveyorSleves.Length /2);
        conveyorSleevesOnEachSide = currentCenterOfConveyor;

        //Setup position of Conveyor
        float xPosition = 0;

        for (int i = 0; i < conveyorSleves.Length; i++)
        {
            Vector3 newPosition = transform.GetChild(i).position;
            newPosition.x += xPosition;
            transform.GetChild(i).position = newPosition;
            xPosition += 1.4f;
            conveyorSleves[i] = transform.GetChild(i).GetComponent<ConveyorSleeve>();
        }

        //Setup sleeves in conveyor
        for (int i = 0; i < Mathf.Min(conveyorSleves.Length, sleevesInLevel.Length); i++)
        {
            conveyorSleves[i].AddSleeve(sleevesInLevel[i]);
        }

        //Setup nessesary variables for teleportation of sleeves;
        startPositionOfConveyor = conveyorSleves[0].transform.position;
        endPositionOfConveyor = conveyorSleves[conveyorSleves.Length-1].transform.position;


    }

    void AddEmptySleeves()
    {
        //Implemente function that adds empty sleeves to the conveyor belt in there is less than 9 sleeves in a level
    }
    
    // Update is called once per frame
	void Update () {
        
        CheckForTeleportation();
	}

    public void MoveConveyorBelt(float signDirection)
    {
        movedFromCenter += signDirection;
    }

    
    //Check for distance in both direction, reset movedfromcenter with offset from movedfromcentermax added. Teleport a sleeve with the same offset relevant to the end or start position
    void CheckForTeleportation()
    {
        bool hasChanged = false;
        if (movedFromCenter > movedFromCenterMax)
        {
            if(FindCorrectSleeve(conveyorSleevesOnEachSide) == 3)
            {
                Debug.Log("");
            }
            int sleeveToTransport = FindCorrectSleeve(conveyorSleevesOnEachSide);
            TeleportConveyorSleeve(startPositionOfConveyor, conveyorSleves[sleeveToTransport]);
            currentCenterOfConveyor--;
            hasChanged = true;

        }
        else if (movedFromCenter < -movedFromCenterMax)
        {
            int sleeveToTransport = FindCorrectSleeve(-conveyorSleevesOnEachSide);
            TeleportConveyorSleeve(endPositionOfConveyor, conveyorSleves[sleeveToTransport]);
            currentCenterOfConveyor++;
            hasChanged = true;
        }

        if (hasChanged)
        {
            ResetMovedFromCenter();
            CheckIfCenterIsBelowOrAbove();
        }
    }

    //Checks if currentcenter is among the conveyorSleeves
    void CheckIfCenterIsBelowOrAbove()
    {
        int min = 0;
        int max = conveyorSleves.Length - 1;
        if (currentCenterOfConveyor < min)
        {
            currentCenterOfConveyor = max;
        } else if (currentCenterOfConveyor > max)
        {
            currentCenterOfConveyor = min;

        }
    }

    //Check to see if the desired sleeve goes outside of the number of conveyorsleeves in the scene. And returns the correct sleeve in the other end if it does.
    //Also updates the current center of the sleeves
    int FindCorrectSleeve(int numberFromCenter)
    {
        int numberToCheck = currentCenterOfConveyor + numberFromCenter;
        int numberToReturn = numberToCheck;
        if (numberToCheck < 0)
        {
            numberToReturn = conveyorSleves.Length + numberToCheck;
        } else if (numberToCheck > (conveyorSleves.Length -1))
        {
            numberToReturn = (numberToCheck - 1) - currentCenterOfConveyor;
            
        }
        //Debug.Log("I'll return number: " + numberToReturn);
        return numberToReturn;
        
    }

    void TeleportConveyorSleeve(Vector3 originalPosition,ConveyorSleeve conveyorSleeveToTeleport)
    {
        //Finds the slight offset the frame went over the max limit, and adds that to the original end positions of the conveyor belt. The moveds the corrent conveyor sleeve to its new position.
        float offset = movedFromCenterMax - movedFromCenter;
        Vector3 newPosition = originalPosition;
        newPosition.x += offset;
        conveyorSleeveToTeleport.transform.position = newPosition;
    }
    void ResetMovedFromCenter()
    {
        movedFromCenter = movedFromCenter + (-Mathf.Sign(movedFromCenter) * movedFromCenterMax * 2);   
    }

}

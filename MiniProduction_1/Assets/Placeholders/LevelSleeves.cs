using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSleeves : Manager<LevelSleeves> {

    Sleeve[] sleevesInLevel;

    protected override void onAwake()
    {
        base.onAwake();
    
        sleevesInLevel = new Sleeve[12];
        for (int i = 0; i < sleevesInLevel.Length;i++)
        {
            sleevesInLevel[i] = new Sleeve();
        }
        sleevesInLevel[0].ColorOfSleeve = Color.black;
        sleevesInLevel[1].ColorOfSleeve = Color.blue;
        sleevesInLevel[2].ColorOfSleeve = Color.cyan;
        sleevesInLevel[3].ColorOfSleeve = Color.gray;
        sleevesInLevel[4].ColorOfSleeve = Color.green;
        sleevesInLevel[5].ColorOfSleeve = Color.magenta;
        sleevesInLevel[6].ColorOfSleeve = Color.red;
        sleevesInLevel[7].ColorOfSleeve = Color.white;
        sleevesInLevel[8].ColorOfSleeve = Color.yellow;
        sleevesInLevel[9].ColorOfSleeve = new Color(100,100,0);
        sleevesInLevel[10].ColorOfSleeve = new Color(0, 100, 100);
        sleevesInLevel[11].ColorOfSleeve = new Color(100, 0, 100);
    }

    public Sleeve[] GetLevelSleeves()
    {
        return sleevesInLevel;
    }
}

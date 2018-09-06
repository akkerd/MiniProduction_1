using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSleeves : Manager<LevelSleeves> {

    Sleeve[] sleevesInLevel;

    protected override void onAwake()
    {
        base.onAwake();
        int value = 0;
        sleevesInLevel = new Sleeve[12];
        for (int i = 0; i < sleevesInLevel.Length;i++)
        {
            sleevesInLevel[i] = new Sleeve();
            sleevesInLevel[i].ColorOfSleeve = new Color(value,value,value,255) ;
            value +=20;
        }
        /*
        sleevesInLevel[0].ColorOfSleeve = new Color(10,10,10);
        sleevesInLevel[1].ColorOfSleeve = new Color(30,30,30);
        sleevesInLevel[2].ColorOfSleeve = new Color(50,50,50);
        sleevesInLevel[3].ColorOfSleeve = new Color(80,80,80);
        sleevesInLevel[4].ColorOfSleeve = new Color(100,100,100);
        sleevesInLevel[5].ColorOfSleeve = new Color(130,130,130);
        sleevesInLevel[6].ColorOfSleeve = new Color(150,150,150);
        sleevesInLevel[7].ColorOfSleeve = new Color(170,170,170);
        sleevesInLevel[8].ColorOfSleeve = new Color(190,190,190);
        sleevesInLevel[9].ColorOfSleeve = new Color(210,210,210);
        sleevesInLevel[10].ColorOfSleeve = new Color(230, 230, 230);
        sleevesInLevel[11].ColorOfSleeve = new Color(250, 250, 250);
         */
    }

    public Sleeve[] GetLevelSleeves()
    {
        return sleevesInLevel;
    }
}

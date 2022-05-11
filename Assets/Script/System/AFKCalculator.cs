using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AFKCalculator : MonoBehaviour
{

    public enum Rarity { Common, RarePVP, RarePVE, Legend }
    public enum Level { one, two, three }

    

    //monster1
    public Rarity monster1rarity;
    public Level monster1level;
    [Range(0, 9)]
    public int monster1item1 = 0;
    [Range(0, 9)]
    public int monster1item2 = 0;
    [Range(0, 9)]
    public int monster1item3 = 0;
    [Range(0, 5)]
    public int monster1food = 0;

    //monster2
    public Rarity monster2rarity;
    public Level monster2level;
    [Range(0, 9)]
    public int monster2item1 = 0;
    [Range(0, 9)]
    public int monster2item2 = 0;
    [Range(0, 9)]
    public int monster2item3 = 0;
    [Range(0, 5)]
    public int monster2food = 0;

    //monster3
    public Rarity monster3rarity;
    public Level monster3level;
    [Range(0, 9)]
    public int monster3item1 = 0;
    [Range(0, 9)]
    public int monster3item2 = 0;
    [Range(0, 9)]
    public int monster3item3 = 0;
    [Range(0, 5)]
    public int monster3food = 0;

    //Island
    [Range(1, 100)]
    public int islandQI = 1;

    //Boss
    public bool bossMonster = false;

    private int monster1totalSP = 0;
    private int monster2totalSP = 0;
    private int monster3totalSP = 0;
    private int partySP = 0;


    void Start()
    {
       
}

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            {
            print("TotalMonster1SP = " + CalculateSP(monster1rarity, monster1level, monster1item1, monster1item2, monster1item3, monster1food));
            print("TotalMonster2SP = " + CalculateSP(monster2rarity, monster2level, monster2item1, monster2item2, monster2item3, monster2food));
            print("TotalMonster3SP = " + CalculateSP(monster3rarity, monster3level, monster3item1, monster3item2, monster3item3, monster3food));

            monster1totalSP = CalculateSP(monster1rarity, monster1level, monster1item1, monster1item2, monster1item3, monster1food);
            monster2totalSP = CalculateSP(monster2rarity, monster2level, monster2item1, monster2item2, monster2item3, monster2food);
            monster3totalSP = CalculateSP(monster3rarity, monster3level, monster3item1, monster3item2, monster3item3, monster3food);
            partySP = monster1totalSP + monster2totalSP + monster3totalSP;

            print("PartySP = " + partySP);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {

        }

        if (Input.GetKeyDown(KeyCode.B))
        {

        }
    }

    void IsLandCal()
    {

    }


    int CalculateSP(Rarity rare,Level level,int item1,int item2,int item3,int food)
    {
        int monsterRNL=0;

        switch(rare)
        {
            case Rarity.Common:
                switch (level)
                {
                    case Level.one:
                        monsterRNL = 10;
                        break;
                    case Level.two:
                        monsterRNL = 30;
                        break;
                    case Level.three:
                        monsterRNL = 60;
                        break;
                }
                break;
            case Rarity.RarePVP:
                switch (level)
                {
                    case Level.one:
                        monsterRNL = 10;
                        break;
                    case Level.two:
                        monsterRNL = 30;
                        break;
                    case Level.three:
                        monsterRNL = 60;
                        break;
                }
                break;
            case Rarity.RarePVE:
                switch (level)
                {
                    case Level.one:
                        monsterRNL = 20;
                        break;
                    case Level.two:
                        monsterRNL = 40;
                        break;
                    case Level.three:
                        monsterRNL = 80;
                        break;
                }
                break;
            case Rarity.Legend:
                switch (level)
                {
                    case Level.one:
                        monsterRNL = 22;
                        break;
                    case Level.two:
                        monsterRNL = 42;
                        break;
                    case Level.three:
                        monsterRNL = 82;
                        break;
                }
                break;

        }
        
        int monsterTotalSP = monsterRNL + item1 + item2 + item3 + food;
        return monsterTotalSP;
        
    }


}

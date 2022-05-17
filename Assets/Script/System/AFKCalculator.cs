using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Random = UnityEngine.Random;

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
    int bossValue;

    //QI data in CSV
    //can see in inspector
    public TextAsset textAssetData; 

    [System.Serializable]
    public class QI
    {
        public int QiOrder;
        public int OpMax;
        public int OpMin;
    }

    [System.Serializable]
    public class QIList
    {
        public QI[] Island;
    }

    //create instance
    public QIList myQIList = new QIList();

    void Start()
    {
        ReadCSV();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            {
            print(" TotalMonster1SP = " + CalculateSP(monster1rarity, monster1level, monster1item1, monster1item2, monster1item3, monster1food)
                + " TotalMonster2SP = " + CalculateSP(monster2rarity, monster2level, monster2item1, monster2item2, monster2item3, monster2food)
                + " TotalMonster3SP = " + CalculateSP(monster3rarity, monster3level, monster3item1, monster3item2, monster3item3, monster3food));

            monster1totalSP = CalculateSP(monster1rarity, monster1level, monster1item1, monster1item2, monster1item3, monster1food);
            monster2totalSP = CalculateSP(monster2rarity, monster2level, monster2item1, monster2item2, monster2item3, monster2food);
            monster3totalSP = CalculateSP(monster3rarity, monster3level, monster3item1, monster3item2, monster3item3, monster3food);
            partySP = monster1totalSP + monster2totalSP + monster3totalSP;

            print("PartySP = " + partySP);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            LandCal();
        }

        

    }

    void LandCal()
    {
        if(islandQI<=10)
        {
            LandCal1to10(monster1totalSP, monster2totalSP, monster3totalSP);
        }
        if(islandQI>10)
        {
            LandCal11to100(monster1totalSP, monster2totalSP, monster3totalSP, islandQI);
      
            if(islandQI>=75)
            BossCalculator(partySP);
        }
    }

    void LandCal1to10(int mon1,int mon2, int mon3)
    {
        int i = 0;

        int islandIndex1 = Random.Range(5, 11);
        int islandIndex2 = Random.Range(5, 11);
        int islandIndex3 = Random.Range(5, 11);

        if (mon1 >= islandIndex1)
        {
            i++;
        }
        if (mon2 >= islandIndex2)
        {
            i++;
        }
        if (mon3 >= islandIndex3)
        {
            i++;
        }
        if(i>=2)
        {
            print("Island : You WIN!!! IslandQI = " + islandQI);
        }
        if(i<2)
        {
            print("Island : You LOST??? IslandQI = " + islandQI);
        }


    }

    void LandCal11to100(int mon1, int mon2, int mon3,int QIvalue)
    {
        int qiindex = QIvalue - 1;

        int min = myQIList.Island[qiindex].OpMin;
        int max = myQIList.Island[qiindex].OpMax;  
        int n = max - min + 1; 
        //value at 10%
        int v10 = min + (10 * (n + 1) / 100);
        //value at 50%
        int v50 = min + (50 * (n + 1) / 100);

        //  min < v10 < v50 < max 

        int islandIndex1 = 0;
        int islandIndex2 = 0;
        int islandIndex3 = 0;
        int victoryIndex = 0;

        //pick range 
        int ran1 = Random.Range(1, 100);
        if(ran1<=10)
        {
            islandIndex1 = Random.Range(min, v10+1);
        }
        if(ran1>10 && ran1 <=50)
        {
            islandIndex1 = Random.Range(v10 + 1, v50+1);
        }
        if(ran1>50)
        {
            islandIndex1 = Random.Range(v50 + 1, max);
        }

        int ran2 = Random.Range(1, 100);
        if (ran2 <= 10)
        {
            islandIndex2 = Random.Range(min, v10 + 1);
        }
        if (ran2 > 10 && ran2 <= 50)
        {
            islandIndex2 = Random.Range(v10 + 1, v50 + 1);
        }
        if (ran2 > 50)
        {
            islandIndex2 = Random.Range(v50 + 1, max);
        }

        int ran3 = Random.Range(1, 100);
        if (ran3 <= 10)
        {
            islandIndex3 = Random.Range(min, v10 + 1);
        }
        if (ran3 > 10 && ran3 <= 50)
        {
            islandIndex3 = Random.Range(v10 + 1, v50 + 1);
        }
        if (ran3 > 50)
        {
            islandIndex3 = Random.Range(v50 + 1, max);
        }

        if (mon1 >= islandIndex1)
            victoryIndex++;
        if (mon2 >= islandIndex2)
            victoryIndex++;
        if (mon3 >= islandIndex3)
            victoryIndex++;

        print(mon1 + "VS" + islandIndex1 +"___"+ mon2 + "VS" + islandIndex2+"___"+ mon3 + "VS" + islandIndex3);

        if(victoryIndex>=2)
            print("Island : You WIN!!! IslandQI = " + islandQI);
        if(victoryIndex<2)
            print("Island : You LOST!!! IslandQI = " + islandQI);

    }



    void BossCalculator(int party)
    {
        int bossIndex = Random.Range(1, 101);
        bossValue = 0;

        if (bossIndex<=50)
        {
            bossValue = Random.Range(295, 314);
        }
        if(bossIndex>50 && bossIndex<=80)
        {
            bossValue = Random.Range(314, 333);
        }
        if(bossIndex>80)
        {
            bossValue = Random.Range(333, 351);
        }


        print("PartySP:" + party + " VS " + "BossSP:" + bossValue);



        if(party>= bossValue)
        {
            print("You WIN Boss Fight!!!");
        }
        if(party<bossValue)
        {
            print("You LOST Boss Fight???");
        }

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

    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 3 -1;
        myQIList.Island = new QI[tableSize];

        for(int i =0; i<tableSize; i++)
        {
            myQIList.Island[i] = new QI();
            myQIList.Island[i].QiOrder = int.Parse(data[3 * (i  +1) ]);
            myQIList.Island[i].OpMax = int.Parse(data[3 * (i +1) + 1]);
            myQIList.Island[i].OpMin = int.Parse(data[3 * (i  +1) + 2]);
        }

    }
    

}

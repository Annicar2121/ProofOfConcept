using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Card> cardList = new List<Card>();
    public Player player;
    public Audience audience;


    void Awake()
    {
        cardList.Add(new Card(0, "Pull a Rabbit from a Hat", 3, 25, "IfWearing:TOPHAT AFN * 2", 80));
        cardList.Add(new Card(1, "Cup and Balls", 2, 10, "Gain 10 Audience Affection", 99));
        cardList.Add(new Card(2, "Sawing a Person in half", 5, 50, "Gain 50 Audience Affection", 70));
        cardList.Add(new Card(3, "Linking Rings", 2, 20, "Gain 20 Affection, if Audience is distracted gain 40 affection", 70));
        cardList.Add(new Card(4, "Levitation", 2, 10, "Gain 10 Affection +10 for each time used to a max of 40.", 75));
        cardList.Add(new Card(5, "Is this your card?", 3, 25, "Gain 25 Affection, if holding packOfCards affection gain 45 Affection", 80));
        cardList.Add(new Card(6, "Balloon Tie", 3, 30, "Gain 30 Affection, if wearing clown shoes gain 50 Affection", 80));
        cardList.Add(new Card(7, "Bad Pun", 1, 5, "Gain 5 Affection, if audience is primed gain 35 affection", 80));
        cardList.Add(new Card(8, "Stuck in a box", 2, 20, "Gain 20 Affection", 80));
        cardList.Add(new Card(9, "Set Up", 1, 0, "Prime The Audience", 80));
        cardList.Add(new Card(10, "Juggle", 2, 20, "Gain 20 Affection, if audience is primed gain 30 affection",80));
        cardList.Add(new Card(11, "Hammer the Fruit", 3, 20, "Gain 20 - 50 affection randomly depending on the fruit", 80));
        cardList.Add(new Card(12, "Puppeteer", 3, 30, "Gain 30 affection, if holding a Puppet gain 50 affection", 80));
        cardList.Add(new Card(13, "Distraction", 1, 0, "Distract the audience", 80));
        cardList.Add(new Card(14, "Razzle Dazzle", 1, 0, "Primes the audience", 80));
        cardList.Add(new Card(15, "Look over there!", 1 , 0, "Distract the audience", 80));
        cardList.Add(new Card(16, "Sabotage!", 2, 0, "Lower Enemy Energy by 2", 80));
        cardList.Add(new Card(17, "Outshine", 3, 0, "lower enemy affection by 20", 80));
        cardList.Add(new Card(18, "Enthrall", 4, 0, "Distract and Prime the audience", 80));
        cardList.Add(new Card(19, "Brew", 3, 20, "Gain 20 affection, hamper the opponent",100));
        cardList.Add(new Card(20, "Cackle", 2, 30, "Gain 30 affection", 100));
        cardList.Add(new Card(21, "Commune", 5, 40, "Gain 40 Affection", 100));
        cardList.Add(new Card(21, "Illuminate", 3, 25, "Gain 25 Affection", 100));
        cardList.Add(new Card(22, "Conjure firework dragon", 5, 40, "Gain 50 Affection", 100));
        cardList.Add(new Card(23, "Wand Waggle", 2, 40, "Gain 20 Affection", 100));
        cardList.Add(new Card(24, "Smoke Pipe Weed", 4, 40, "Gain 40 Affection", 100));
        cardList.Add(new Card(25, "Create Illusion", 2, 20, "Gain 20 Affection", 100));
    }

    public int effect(int id)
    {
        
        switch (id)
        {
            case 0:
                //Pulling a Rabbit from a Hat
                 if (player.getWornItem().CompareTo("tophat") == 1){
                     return cardList[id].affection * 2;
                  }
                  else
                  {
                return cardList[id].affection;
              }
            case 1:
                //Cup and Balls
                return cardList[id].affection;
            case 2:
                //Sawing a Woman in Half
                return cardList[id].affection;

            case 3:
                //Linking Rings
                if (audience.distracted)
                {
                    audience.distracted = false;
                    return cardList[id].affection * 2;
                }
                else
                {
                    return cardList[id].affection;
                }

            case 4:
                //Levitation
                if (cardList[id].timesUsed > 3)
                {
                    return cardList[id].affection + 30;
                }
                else
                {
                    return cardList[id].affection + (10 * cardList[id].timesUsed);
                }
            case 5:
                //Is this your card?
                if (player.getHeldItem().CompareTo("packOfCards") == 1)
                {
                    return cardList[id].affection + 20;
                }
                else
                {
                    return cardList[id].affection;
                }

            case 6:
                //Balloon Tie
                if (player.getWornItem().CompareTo("ClownShoes") == 1)
                {
                    return cardList[id].affection  + 20;
                }
                else
                {
                    return cardList[id].affection;
                }

            case 7:
                //Bad Pun
                if (audience.primed)
                {
                    audience.primed = false;
                    return cardList[id].affection + 30;
                }
                else
                {
                    return cardList[id].affection;
                }
                

            case 8:
                //Stuck in a box
                return cardList[id].affection;
            case 9:
                //Set up Joke
                audience.primed = true;
                return 0;
            case 10:
                //juggle
                if (audience.primed)
                {
                    audience.primed = false;
                    return cardList[id].affection + 10;
                }
                return cardList[id].affection;
            case 11:
                //Hammer the fruit
                int temp = Random.Range(0, 3);
                if(temp == 0)
                {
                   return cardList[id].affection;
                }
                if (temp == 1)
                {
                    return cardList[id].affection + 5;
                }
                if (temp == 2)
                {
                    return cardList[id].affection + 10;
                }
                if (temp == 3)
                {
                    return cardList[id].affection + 15;
                }
                return cardList[id].affection;
            case 12:
                //Puppeteer
                if (player.getHeldItem().CompareTo("puppet") == 1)
                {
                    return cardList[id].affection + 20;
                }
                else
                {
                    return cardList[id].affection;
                }
            case 13:
                //Distraction
                audience.distracted = true;
                return cardList[id].affection;
            case 14:
                //Razzle Dazzle
                audience.primed = true;
                return cardList[id].affection;
            case 15:
                //Look Over There
                audience.distracted = true;
                return cardList[id].affection;
            case 16:
                //sabotage
                Enemy1 enemy = FindObjectOfType<Enemy1>();
                enemy.energy -= 2;
                return cardList[id].affection;
            case 17:
                //outshine
                audience.changeEnemyAffection(-20);
                return cardList[id].affection;
            case 18:
                //enthrall
                audience.primed = true;
                audience.distracted = true;
                return cardList[id].affection;
            default:
                return cardList[id].affection;
        }

    }

    public List<Card> getList()
    {
        return cardList;
    }
}

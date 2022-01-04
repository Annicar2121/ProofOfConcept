using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card 
{
    public int id;
    public string cardName;
    public int energyCost;
    public int affection;
    public string cardDescription;
    public int successRate;
    public int timesUsed;
    

     

    public Card()
    {
      
    }

    public Card(int ID, string Name, int EnergyCost, int Affection, string CardDescription, int SuccessRate)
    {
        this.id = ID;
        this.cardName = Name;
        this.energyCost = EnergyCost;
        this.affection = Affection;
        this.cardDescription = CardDescription;
        this.successRate = SuccessRate;
        this.timesUsed = 0;
        
    }

    public int effect()
    {
        
        switch (id)
        {
            case 0:
                //Pulling a Rabbit from a Hat
               // if (player.getWornItem().CompareTo("tophat") == 1){
              //      return affection * 2;
              //  }
              //  else
              //  {
                    return affection;
              //  }
            case 1:
                //Cup and Balls
                return affection;
            case 2:
                //Sawing a Woman in Half
                return affection;
             
            case 3:
                //Linking Rings
                return affection;
               
            case 4:
                //Levitation
                return affection;
               
            case 5:
                //Is this your card?
                return affection;
              
            case 6:
                //Balloon Tie
                return affection;
                
            case 7:
                //Bad Pun
                return affection;
                
            case 8:
                //Stuck in a box
                return affection;
                
            default:
                return affection;
        }

    }

}

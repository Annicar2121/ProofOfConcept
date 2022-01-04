using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private string wornItem;
    private string heldItem;
    public int energy; 
    public static List<Card> myDeck = new List<Card>();
    public static List<Card> discardPile = new List<Card>();
    public GameLoop game;
    public Audience audience;
    public CardDatabase cd;
    //public Text text;
    public Text card1Name;
    public Text card1Description;
    public Text card1Energy;
    public Text card2Name;
    public Text card2description;
    public Text card2Energy;
    public Text card3Name;
    public Text card3Description;
    public Text card3Energy;
    public Text card4Name;
    public Text card4Description;
    public Text card4Energy;
    public Text moveText;
    public GameObject[] cards;
    public Animator anim;
    private PersistentPlayer pp;
    // Start is called before the first frame update
    void Start()
    {
        pp = Object.FindObjectOfType<PersistentPlayer>();
      
        cards = GameObject.FindGameObjectsWithTag("card");
     
            wornItem = pp.getWornItem();
            heldItem = pp.getHeldItem();
            myDeck = pp.getDeck();
        
        shuffle();
        changeText();
        

    }

    // Update is called once per frame
    void Update()
    {

        
        //changeText();
    }
    
    public void playCard(int index)
    {
        if(index == 99)
        {
            energy++;
            moveText.text = "You are preparing";
            game.Whosturn = 1;
            return;
        }
        if (energy >= myDeck[index].energyCost)
        {
            if (game.Whosturn == 0)
            {
                //text.text = myDeck[index].effect().ToString();
                audience.changePlayerAffection(cd.effect(myDeck[index].id));
                energy = energy - myDeck[index].energyCost;
                anim.ResetTrigger("IsAttacking");
                anim.SetTrigger("IsAttacking");
                moveText.text = "You used " + myDeck[index].cardName;
                //shuffle();

                
                discardPile.Add(myDeck[index]);
                myDeck.Remove(myDeck[index]);
                //shuffle();
                if(myDeck.Count == 0)
                {
                    myDeck = discardPile;
                    discardPile = new List<Card>();
                    shuffle();

                }
                game.Whosturn = 1;
            }
            else{
                Debug.Log("else statement reached");
            }
            changeText();
        }
    }

    
    public string getWornItem()
    {
        return wornItem;
    }
    public string getHeldItem()
    {
        return heldItem;
    }

    private void shuffle()
    {
        for (int i = 0; i < myDeck.Count; i++)
        {
            Card temp = myDeck[i];
            int randomIndex = Random.Range(i, myDeck.Count);
            myDeck[i] = myDeck[randomIndex];
            myDeck[randomIndex] = temp;
        }
    }

    private void changeText()
    {
        
            if (myDeck.Count >= 1)
            {
                cards[0].SetActive(true);
                card1Name.text = myDeck[0].cardName;
                card1Description.text = myDeck[0].cardDescription;
                card1Energy.text = myDeck[0].energyCost.ToString();
            }
            else
            {
                cards[0].SetActive(false);
            }
            if (myDeck.Count >= 2)
            {
                cards[1].SetActive(true);
                card2Name.text = myDeck[1].cardName;
                card2description.text = myDeck[1].cardDescription;
                card2Energy.text = myDeck[1].energyCost.ToString();
            }
            else
            {
                cards[1].SetActive(false);
            }
            if (myDeck.Count >= 3)
            {
                cards[2].SetActive(true);
                card3Name.text = myDeck[2].cardName;
                card3Description.text = myDeck[2].cardDescription;
                card3Energy.text = myDeck[2].energyCost.ToString();
            }
            else
            {
                cards[2].SetActive(false);
            }
            if (myDeck.Count >= 4)
            {
                cards[3].SetActive(true);
                card4Name.text = myDeck[3].cardName;
                card4Description.text = myDeck[3].cardDescription;
                card4Energy.text = myDeck[3].energyCost.ToString();
            }
            else
            {
                cards[3].SetActive(false); 
            }
        
    }
}

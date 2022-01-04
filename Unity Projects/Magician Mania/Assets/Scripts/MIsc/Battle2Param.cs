using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle2Param : MonoBehaviour
{
    public Player player;
    public Enemy1 enemy;
    public Audience audience;
    public GameLoop gl;
    private int moneyPot;
    private float PAtoWin;
    private float EAtoWin;
    private int PEnergystart;
    private int EEnergystart;
    private List<Card> myDeck = new List<Card>();
    private List<string> dialog = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        moneyPot = 40;
        PAtoWin = 100;
        EAtoWin = 120;
        PEnergystart = 5;
        EEnergystart = 5;
        myDeck.Add(new Card(0, "Pull a Rabbit from a Hat", 3, 25, "Gain 25 Affection IfWearing:TOPHAT Gain 50 instead", 80));
       // myDeck.Add(new Card(1, "Cup and Balls", 2, 10, "Gain 10 Audience Affection", 99));
        myDeck.Add(new Card(2, "Sawing a Person in half", 5, 50, "Gain 50 Audience Affection", 70));
       // myDeck.Add(new Card(3, "Linking Rings", 2, 20, "Gain 20 Affection, if Audience is distracted gain 40 affection", 70));
        myDeck.Add(new Card(4, "Levitation", 2, 10, "Gain 10 Affection", 75));
       // myDeck.Add(new Card(5, "Is this your card?", 3, 25, "Gain 25 Affection, if holding packOfCards affection gain 45 Affection", 80));
       // myDeck.Add(new Card(6, "Balloon Tie", 3, 30, "Gain 30 Affection, if wearing clown shoes gain 50 Affection", 80));
        myDeck.Add(new Card(7, "Bad Pun", 1, 5, "Gain 5 Affection, if audience is primed gain 35 affection", 80));
        //  myDeck.Add(new Card(8, "Stuck in a box", 2, 20, "Gain 20 Affection, if audience is primed gain 40 affection", 80));
        myDeck.Add(new Card(19, "Brew", 3, 20, "Gain 20 affection, hamper the opponent", 100));
        myDeck.Add(new Card(20, "Cackle", 2, 30, "Gain 30 affection",100));
        myDeck.Add(new Card(21, "Commune", 5, 40, "Gain 30 Affection",100));
        dialog.Add("Are you ready to be beWITCHED by my tricks.");
        dialog.Add("My sisters taught me how to do this.");
        dialog.Add("Follow the crumbs my dear");
        dialog.Add("Where did I leave my cauldron");
        dialog.Add("I must meet with my Commune");
        dialog.Add("Do you want to know where my wand is from?");
        dialog.Add("Do you like my hat?");
        dialog.Add("Who said witches aren't real?");
        dialog.Add("Back for more?");
        dialog.Add("Didn't I already beat you?");
        SetParams();
    }


    void SetParams()
    {
        enemy.setDeck(myDeck);
        enemy.setDialog(dialog);
        audience.paffectionSlider.maxValue = PAtoWin;
        audience.eaffectionSlider.maxValue = EAtoWin;
        player.energy = PEnergystart;
        enemy.energy = EEnergystart;
        audience.moneyPot = moneyPot;

    }
}

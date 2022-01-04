using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy1 : MonoBehaviour
{

    private string wornItem;
    private string heldItem;
    public int energy;
    public List<Card> myDeck = new List<Card>();
    public Audience audience;
    public Text moveText;
    public GameObject dbox;
    public GameObject adbox;
    public int counter;
    public bool hampered;
    public Animator anim;
    private List<string> dialog = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        energy = 5;
        counter = 0;
       

        for (int i = 0; i < myDeck.Count; i++)
        {
            Card temp = myDeck[i];
            int randomIndex = Random.Range(i, myDeck.Count);
            myDeck[i] = myDeck[randomIndex];
            myDeck[randomIndex] = temp;
        }
        dialog.Add("You only adopted magic. I was born by it. Molded by it....");
        StartCoroutine(TalkABit(0));
    }

 

    IEnumerator TalkABit(int index)
    {
        adbox.SetActive(true);
        dbox.GetComponent<TextMeshPro>().SetText(dialog[index]);
        yield return new WaitForSeconds(2f);
        adbox.SetActive(false);
    }


    public void playTurn()
    {

        int rand = Random.Range(0,4);
        if (energy > myDeck[rand].energyCost)
        {
            energy = energy - myDeck[rand].energyCost;
            audience.changeEnemyAffection(myDeck[rand].effect());
            moveText.text = "Enemy1 used " + myDeck[rand].cardName;
            anim.ResetTrigger("IsAttacking");
            anim.SetTrigger("IsAttacking");
        }
        else
        {
            moveText.text = "Enemy1 Skipped their Turn";
        }
        counter++;
        rand = Random.Range(1, 7);
        if((counter % 3) == 0)
        {
            StartCoroutine(TalkABit(rand));
        }
        energy += 2;
    }

    public void setDeck(List<Card> list)
    {
        myDeck = list;
    }
    public void setDialog(List<string> list)
    {
        dialog = list;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public int Whosturn;
    public Enemy1 enemy;
    public Player player;
    public Text petext;
    public Text eetext;
    public GameObject canvas;
    public Text moneypotText;
    public Text winnerText;
    private bool Turn;
    private bool NotOver;
    private PersistentPlayer pp;
    private GameObject[] AM; 
    
    public GameObject mainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        AM = GameObject.FindGameObjectsWithTag("audienceMembers");
        pp = Object.FindObjectOfType<PersistentPlayer>();
        if (pp != null)
        {
            pp.addItemEffects();
        }
        Whosturn = 0;
        Turn = true;
        NotOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Whosturn == 1)
        {
            if (Turn)
            {
                StartCoroutine(waitseconds());
                
                Turn = false;
            }
        }
    }


    IEnumerator waitseconds()
    {
        //Print the time of when the function is first called.
        // Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        foreach (GameObject member in AM)
        {
            member.GetComponent<AudienceMember>().setSpeed(Random.Range(7f, 10f));
        }
        yield return new WaitForSeconds(2f);
        foreach (GameObject member in AM)
        {
            member.GetComponent<AudienceMember>().setSpeed(Random.Range(3f, 5f));
        }
        enemyturn();

        //After we have waited 5 seconds print the time again.
        // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    void enemyturn()
    {
        
        enemy.playTurn();
        player.energy += 2;
        Debug.Log("player " + player.energy);
        Debug.Log("enemy " + enemy.energy);
        petext.text = player.energy.ToString();
        eetext.text = enemy.energy.ToString();
        Whosturn = 0;
        Turn = true; 

    }

    public void End(int money, int winner)
    {
        if (NotOver)
        {
            NotOver = false;
            mainCanvas.SetActive(false);
            canvas.SetActive(true);
            if (winner == 0) {
                winnerText.text = "You Lost... Try Again!";
                    }
           
            moneypotText.text = "You Won $" + money.ToString();
            pp.addMoney(money);
            if (winner == 1)
            {
                pp.whichBattle += 1;
            }
        }
    }
    public void ToLobby()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

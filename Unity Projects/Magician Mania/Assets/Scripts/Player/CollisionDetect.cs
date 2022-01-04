using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public UIManager manager;
    public GameObject foodText;
    public GameObject clothesText;

    public int isFood;

    private void Start()
    {
        foodText.SetActive(false);
        clothesText.SetActive(false);
        if(this.gameObject.name == "FoodShop_Trigger")
        {
            isFood = 1;
        }
        else
        {
            isFood = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detected some Collision");
        //Check for a match with the specified name 
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Detected Player Collision");
            manager.setTrigger(true, isFood);

            if(isFood == 1)
            {
                foodText.SetActive(true);
            }else if(isFood== 0)
            {
                clothesText.SetActive(true);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Detected some Collision EXIT");
        manager.setTrigger(false, -1);
        foodText.SetActive(false);
        clothesText.SetActive(false);
    }
}

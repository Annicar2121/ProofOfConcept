using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsTextUI : MonoBehaviour
{
    public Text partsText;
    private Player script;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("PlayerCharacter");
        script = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        partsText.text = "Parts Available: " + script.allParts.Length;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int index;
   // public string tag;
    public string description;
    public Sprite icon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item(int id, string tag, string description, Dictionary<string,int> stats)
    {
        this.index = id;
     //   this.tag = tag;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + tag);
        this.stats = stats;

    }
    public Item(Item item)
    {
        this.index = item.index;
       // this.tag = item.tag;
        this.description = item.description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.tag);
        this.stats = item.stats;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

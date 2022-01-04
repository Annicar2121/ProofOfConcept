using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RadiationTiles : MonoBehaviour
{

    public Tilemap tilemap;
    public Grid grid;

    List<TileBase> getRadTiles() {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        List<TileBase> radTiles = new List<TileBase>();
        for (int x = 0; x < allTiles.Length; x++)
        {
            TileBase tile = allTiles[x];
            if (tile != null)
            {
                radTiles.Add(tile);
            }
        }
        return radTiles;
    }
    // Start is called before the first frame update
    void Start()
        
    {
        grid = GetComponent<Grid>();
        tilemap = GetComponent<Tilemap>();
        tilemap.CompressBounds();
        print("There are: " + getRadTiles().Count + "rad tiles");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g")) {
            Debug.Log("Norp");
            FunctionToGetRidOfTile();
        }
        
    }

    void FunctionToGetRidOfTile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int position = grid.WorldToCell(mousePos);
        tilemap.SetTile(position, null);
    }
}

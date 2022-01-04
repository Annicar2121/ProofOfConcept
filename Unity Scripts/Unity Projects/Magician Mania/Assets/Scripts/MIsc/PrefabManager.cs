using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{

    public GameObject[] prefabs;
    private GameObject prefab;
    private GameObject spawnedPrefab;
    // Start is called before the first frame update
    void Start()
    {
        int prefIndex = Random.Range(0, prefabs.Length);
        Debug.Log(prefIndex);

        prefab = prefabs[prefIndex];
        Vector3 spawnLoc = new Vector3(-16, 4, -4) + prefab.transform.position;
        spawnedPrefab = Instantiate(prefab, spawnLoc, prefab.transform.rotation) as GameObject;
        Debug.Log(spawnedPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

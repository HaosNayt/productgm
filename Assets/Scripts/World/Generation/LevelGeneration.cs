using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] assets;
    private bool isStartCreated = false;
    private GameObject currentTile;

    // Start is called before the first frame update
    void Start()
    {
        if (!isStartCreated)
        {
            currentTile = Instantiate(assets[0]);
            isStartCreated = true;
            Generation();
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) Generation();
    }

    void Generation()
    {
        List<GameObject> connectors = new List<GameObject>();
        connectors.AddRange(GameObject.FindGameObjectsWithTag("Level connection"));
        Debug.Log(connectors.Count);
        List<int> path = new List<int>();
        while (path.Count != 10)
        {
            int randomNumber = Random.Range(1, 4);
            if (path.Count == 0 || randomNumber != path[path.Count - 1])
            {
                path.Add(randomNumber);
            }
        }


        InstantiateAtConnector(connectors[0], assets[0]);
        // foreach (var item in path)
        // {
        //     switch (item)
        //     {
        //         case 1:
        //             currentTile = InstantiateAtConnector(connectors[0], assets[0]);
        //             break;
        //         case 2:
        //             currentTile = InstantiateAtConnector(connectors[0], assets[0]);
        //             break;
        //         case 3:
        //             currentTile = InstantiateAtConnector(connectors[0], assets[0]);
        //             break;
        //         case 4:
        //             currentTile = InstantiateAtConnector(connectors[0], assets[0]);
        //             break;
        //     }
        // }






        // creating array of integers 

        // GameObject[] connections = GameObject.FindGameObjectsWithTag("Level connection");

        // for (int i = 0; i <= connections.Length; i++)
        // {
        //     Debug.Log(connections[i].name);
        //     float random = Random.Range(0, 4);
        //     if (random == 0)
        //     {
        //         GameObject newRoom = Instantiate(assets[0], connections[i].transform.position, Quaternion.identity);
        //         connections[i].SetActive(false);
        //     }
        // }
    }

    GameObject InstantiateAtConnector(GameObject connector, GameObject objToInstantiate)
    {
        GameObject createdObj = Instantiate(objToInstantiate);

        float x = createdObj.GetComponent<MeshFilter>().mesh.bounds.size.x / 2;
        createdObj.transform.position = connector.transform.position + new Vector3(x, 0, 0);
        return createdObj;

        // Transform t = originalObj.transform;
        // Mesh m = originalObj.GetComponent<MeshFilter>().mesh;
        // float x = m.bounds.size.x * t.localScale.x;
        // return Instantiate(objToInstantiate, t.position + new Vector3(x, 0, 0), Quaternion.identity);
    }
}
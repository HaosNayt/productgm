using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGeneration : MonoBehaviour
{
    public List<GameObject> assets = new List<GameObject>();
    private bool isStartCreated = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!isStartCreated)
        {
            Instantiate(assets[0]);
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
        GameObject[] connections = GameObject.FindGameObjectsWithTag("Level connection");

        for (int i = 0; i <= connections.Length; i++)
        {
            float random = Random.Range(0, 4);
            if (random == 0)
            {
                Debug.Log("proc");
                GameObject newRoom = Instantiate(assets[0], connections[i].transform.position, Quaternion.identity);
                connections[i].SetActive(false);
            }

        }
    }
}

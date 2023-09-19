using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] Spawners;

    public GameObject[] Ships;

    public GameObject Player1, Player2;




    private void Awake()
    {
        Player1 = Instantiate(Ships[Random.Range(0, Ships.Length)]);
        Player1.transform.position = Spawners[1].transform.position;
        Player1.GetComponent<ShipMovement>().m_PlayerNumber = 1;
        Player2 = Instantiate(Ships[Random.Range(0, Ships.Length)]);
        Player2.transform.position = Spawners[0].transform.position;
        Player2.GetComponent<ShipMovement>().m_PlayerNumber = 2;
    }
}

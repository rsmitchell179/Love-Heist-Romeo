using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject p_move;
    public GameObject[] doors;
    public int which_door;

    void Awake()
    {
        p_move = GameObject.FindWithTag("Player");

        which_door = GlobalVars.which_door;
        p_move.transform.position = doors[which_door].transform.GetChild(0).position;
    }
}

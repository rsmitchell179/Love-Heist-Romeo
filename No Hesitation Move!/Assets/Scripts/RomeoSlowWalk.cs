using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomeoSlowWalk : MonoBehaviour
{
    playerMovement p_move;

    // Start is called before the first frame update
    void Start()
    {
        p_move = GameObject.FindWithTag("Player").GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        p_move.moveSpeed = 2f;
    }
}

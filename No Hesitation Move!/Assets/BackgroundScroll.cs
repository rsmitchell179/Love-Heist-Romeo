using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    GameObject player;
    playerMovement p_move;
    public GameObject bkgr;
    Vector3 bkgr_pos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        p_move = player.GetComponent<playerMovement>();
        bkgr_pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(p_move.movement.x < 0.0f)
        {
            bkgr_pos.x += 0.0009f;
            bkgr.gameObject.transform.position = bkgr_pos;
        }
        else if(p_move.movement.x > 0.0f)
        {
            bkgr_pos.x -= 0.0009f;
            bkgr.gameObject.transform.position = bkgr_pos;
        }

        if(p_move.movement.y < 0.0f)
        {
            bkgr_pos.y += 0.0009f;
            bkgr.gameObject.transform.position = bkgr_pos;
        }
        else if(p_move.movement.y > 0.0f)
        {
            bkgr_pos.y -= 0.0009f;
            bkgr.gameObject.transform.position = bkgr_pos;
        }
    }
}

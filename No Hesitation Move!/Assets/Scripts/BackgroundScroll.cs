using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // GameObject player;
    // playerMovement p_move;
    // GameObject bkgr;
    // Vector3 bkgr_pos;
    public Transform cam;
    public float relativeMove = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindWithTag("Player");
        // p_move = player.GetComponent<playerMovement>();
        // bkgr = this.gameObject;
        // bkgr_pos = bkgr.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(cam.position.x * relativeMove, cam.position.y * relativeMove);

        // if(p_move.movement.x < 0.0f)
        // {
        //     bkgr_pos.x += 0.003f;
        //     bkgr.gameObject.transform.position = bkgr_pos;
        // }
        // else if(p_move.movement.x > 0.0f)
        // {
        //     bkgr_pos.x -= 0.003f;
        //     bkgr.gameObject.transform.position = bkgr_pos;
        // }

        // if(p_move.movement.y < 0.0f)
        // {
        //     bkgr_pos.y += 0.003f;
        //     bkgr.gameObject.transform.position = bkgr_pos;
        // }
        // else if(p_move.movement.y > 0.0f)
        // {
        //     bkgr_pos.y -= 0.003f;
        //     bkgr.gameObject.transform.position = bkgr_pos;
        // }

        // if(p_move.movement.x != 0.0f && p_move.movement.y == 0.0f)
        // {
        //     if(p_move.movement.x < 0.0f)
        //     {
        //         bkgr_pos.x += 0.003f;
        //         bkgr.gameObject.transform.position = bkgr_pos;
        //     }
        //     else
        //     {
        //         bkgr_pos.x -= 0.003f;
        //         bkgr.gameObject.transform.position = bkgr_pos;
        //     }
        // }
        // else if(p_move.movement.x == 0.0f && p_move.movement.y != 0.0f)
        // {
        //     if(p_move.movement.y < 0.0f)
        //     {
        //         bkgr_pos.y += 0.003f;
        //         bkgr.gameObject.transform.position = bkgr_pos;
        //     }
        //     else
        //     {
        //         bkgr_pos.y -= 0.003f;
        //         bkgr.gameObject.transform.position = bkgr_pos;
        //     }
        // }
        // else
        // {
        //     if(p_move.movement.x < 0.0f && p_move.movement.y < 0.0f)
        //     {
        //         bkgr_pos.x -= 0.002f;
        //         bkgr_pos.y -= 0.002f;
        //         bkgr.gameObject.transform.position = bkgr_pos;
        //     }
        //     else if(p_move.movement.x > 0.0f && p_move.movement.y < 0.0f)
        //     {
        //         bkgr_pos.x += 0.002f;
        //         bkgr_pos.y -= 0.002f;
        //         bkgr.gameObject.transform.position = bkgr_pos;
        //     }
        //     else if(p_move.movement.x < 0.0f && p_move.movement.y > 0.0f)
        //     {
        //         bkgr_pos.x -= 0.002f;
        //         bkgr_pos.y += 0.002f;
        //         bkgr.gameObject.transform.position = bkgr_pos;
        //     }
        //     else if(p_move.movement.x > 0.0f && p_move.movement.y > 0.0f)
        //     {
        //         bkgr_pos.x += 0.002f;
        //         bkgr_pos.y += 0.002f;
        //         bkgr.gameObject.transform.position = bkgr_pos;
        //     }
        // }
    }
}

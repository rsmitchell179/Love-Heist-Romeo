using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class playerMovement : MonoBehaviour
{
    public static bool hasJSorb;
    public static bool hasFTorb;
    public static bool hasRCorb;

    public float moveSpeed = 5f;

    // rigidbody for motion and collisions
    public Rigidbody2D body;

    // vector of current movement direction + speed
    Vector2 movement;

    // for linking player motion to animations in animation editor
    public Animator anim;
    public float interactionRadius = 2.0f;

    private DialogueRunner diaRun = null;

    void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;

            // Flatten the sphere into a disk, which looks nicer in 2D games
            Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1,1,0));

            // Need to draw at position zero because we set position in the line above
            Gizmos.DrawWireSphere(Vector3.zero, interactionRadius);
    }

    void Start(){
        diaRun = FindObjectOfType<DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {

        if(diaRun.IsDialogueRunning == true)
        {
            anim.enabled = false;
            // anim.PlayInFixedTime("playerWalkLeft", 1, 0.0f);
            movement.x = 0;
            movement.y = 0;
            // anim.SetFloat("Horizontal", movement.x);
            // anim.SetFloat("Vertical", movement.y);
            return;
        }else{
            anim.enabled = true;
        }

        // Get input
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Set animation vars
        // make sure we don't set them if the player is standing still, to prevent weird flipping
        if (movement.x != 0)
        {
            anim.SetFloat("Horizontal", movement.x);
        }

        if (movement.y != 0)
        {
            anim.SetFloat("Vertical", movement.y);
        }

        anim.SetFloat("Speed", movement.sqrMagnitude); //some sort of wild magic variable that pulls the squared length of the vector

        if (Input.GetKeyDown(KeyCode.Space)) {
                CheckForNearbyNPC ();
        }
    }

    void FixedUpdate()
    {

        body.MovePosition(body.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }

    public void CheckForNearbyNPC ()
    {
        var allParticipants = new List<NPC> (FindObjectsOfType<NPC> ());
        var target = allParticipants.Find (delegate (NPC p) {
            return string.IsNullOrEmpty (p.talkToNode) == false && // has a conversation node?
            (p.transform.position - this.transform.position)// is in range?
            .magnitude <= interactionRadius;
        });
        Debug.Log(target);
        if (target != null) {
            // Kick off the dialogue at this node.
            FindObjectOfType<DialogueRunner>().StartDialogue (target.talkToNode);
        }
    }

}

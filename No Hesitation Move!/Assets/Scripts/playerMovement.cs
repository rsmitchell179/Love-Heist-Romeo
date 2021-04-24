using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;
using System.IO;

public class playerMovement : MonoBehaviour
{
    // public static bool hasJSorb;
    // public static bool hasFTorb;
    // public static bool hasRCorb;

    public float moveSpeed;

    // rigidbody for motion and collisions
    public Rigidbody2D body;

    // vector of current movement direction + speed
    public Vector2 movement;

    // for linking player motion to animations in animation editor
    public Animator anim;
    public float interactionRadius = 2.0f;

    private DialogueRunner diaRun = null;

    public string file_path;

    // public bool letter_open = false;

    // public LetterPopUp letterpp;

    void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;

            // Flatten the sphere into a disk, which looks nicer in 2D games
            Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1,1,0));

            // Need to draw at position zero because we set position in the line above
            Gizmos.DrawWireSphere(Vector3.zero, interactionRadius);
    }

    void Awake(){
        // starting the globalvars
        GlobalVars.curr_scene = SceneManager.GetActiveScene().name;

        file_path = Application.persistentDataPath + "/player.lhr";
        if(File.Exists(file_path)){
        	SaveData load_pos_data = SaveSys.load_data();
        	Vector3 load_position = new Vector3(load_pos_data.position[0], load_pos_data.position[1], load_pos_data.position[2]);
        	transform.position = load_position;
        }
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
            movement.x = 0;
            movement.y = 0;
            // anim.PlayInFixedTime("playerWalkLeft", 1, 0.0f);
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

        // DEV RUN - GET RID OF WHEN FINAL VERSION IS REALEASED 
        if(Input.GetKey(KeyCode.LeftShift)) {
            moveSpeed = 6f;
        } else {
            moveSpeed = 3.14f;
        }

        // charles bless up
        // if(letter_open == true){
        //     anim.enabled = false;
        //     movement.x = 0;
        //     movement.y = 0;
        //     if(Input.GetKeyDown(KeyCode.Space)){
        //         letterpp.letter.enabled = false;
        //         letter_open = false;
        //     }
        // }

        // if(Input.GetKeyDown(KeyCode.P)){

        //     Save_Data();
            
        // }

        // if(Input.GetKeyDown(KeyCode.O)){
        //     Load_Data();
        // }

        
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

    public void save_position()
    {
    	GlobalVars.position[0] = transform.position.x;
        GlobalVars.position[1] = transform.position.y;
        GlobalVars.position[2] = transform.position.z;
    }

    public void Save_Data()
    {
        Debug.Log("SAVING DATA...");
        save_position();
        SaveSys.save_data();
        // GlobalVars.print_array();
    }

    public void Load_Data()
    {

        Debug.Log("LOADING DATA...");
        SaveData new_data = SaveSys.load_data();
        // GlobalVars.print_array();

        GlobalVars.bool_array[0] = new_data.bool_array[0];
        GlobalVars.bool_array[1] = new_data.bool_array[1];
        GlobalVars.bool_array[2] = new_data.bool_array[2];
        GlobalVars.bool_array[3] = new_data.bool_array[3];
        GlobalVars.bool_array[4] = new_data.bool_array[4];
        GlobalVars.bool_array[5] = new_data.bool_array[5];

        SceneManager.LoadScene(new_data.scene);

        // Vector3 load_position = new Vector3(new_data.position[0], new_data.position[1], new_data.position[2]);
        // transform.position = load_position;

        // GlobalVars.bool_array.Add(new_data.bool_array[0]);
        // GlobalVars.bool_array.Add(new_data.bool_array[1]);
        // GlobalVars.bool_array.Add(new_data.bool_array[2]);
        // GlobalVars.bool_array.Add(new_data.bool_array[3]);
        // GlobalVars.bool_array.Add(new_data.bool_array[4]);
        // GlobalVars.bool_array.Add(new_data.bool_array[5]);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSBoatLadderScript : MonoBehaviour
{
    public GameObject decor_transparency;
    public DecorScript decor_script;
    public Collider2D invis_wall;
    public GameObject back_bath;
    public GameObject roof_edge;
    public Collider2D boat_colliders;
    public GameObject backpath_db;

    void Start()
    {
        roof_edge.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // Debug.Log("before check is " + decor_transparency.activeInHierarchy);
            decor_transparency.SetActive(false);
            decor_script.enabled = false;
            invis_wall.enabled = false;
            back_bath.SetActive(false);
            roof_edge.SetActive(true);
            boat_colliders.enabled = false;
            backpath_db.SetActive(false);
            // Debug.Log("after check is " + decor_transparency.activeInHierarchy);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            decor_transparency.SetActive(true);
            decor_script.enabled = true;
            invis_wall.enabled = true;
            back_bath.SetActive(true);
            roof_edge.SetActive(false);
            boat_colliders.enabled = true;
            backpath_db.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField] private GameObject[] walls;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < walls.Length; i++){
             Physics2D.IgnoreCollision(walls[i].GetComponent<Collider2D>(), this.GetComponent<Collider2D>(), true);
        }
    }

}

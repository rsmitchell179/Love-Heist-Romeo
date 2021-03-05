using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    private int Spot;
    public float startWaitTime;
    public float waitTime;
    [SerializeField] private FieldOfView fieldOfView;
    private Vector3 lastMoveDir;
    private float viewDistance;
    private float fov;
    private GameObject player;
    AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>(); 
        player = GameObject.FindGameObjectWithTag("Player");
        fov = fieldOfView.fov;
        viewDistance = fieldOfView.viewDistance;
        waitTime = startWaitTime;
        Spot = 0;
        lastMoveDir = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0);
    }

    void FixedUpdate(){
        FindTargetPlayer();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        fieldOfView.SetOrigin(transform.position);
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[Spot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[Spot].position) < 0.2f){
            if(waitTime <= 0){
                lastMoveDir = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0);
                if (Spot != moveSpots.Length -1){
                    Spot ++;
                } else {
                    Spot = 0;
                }
                waitTime = startWaitTime;
                fieldOfView.SetAimDirection(lastMoveDir);
            } else {
                waitTime -= Time.deltaTime;
            }
        }


    }

   private void FindTargetPlayer(){
        if (Vector3.Distance(GetPosition(), player.transform.position) < viewDistance) {
            // Player inside viewDistance
            Vector3 dirToPlayer = (player.transform.position - GetPosition()).normalized;
            if (Vector3.Angle(GetAimDir(), dirToPlayer) < fov / 2f) {
                //Debug.Log("Player inside Field of View");
                RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToPlayer, viewDistance, LayerMask.GetMask("Player"));
                Debug.DrawRay(GetPosition(), dirToPlayer, Color.white, 0.5f);
                if (raycastHit2D.collider != null) {
                    // Hit something
                    if (raycastHit2D.collider.gameObject.GetComponent<playerMovement>() != null) {
                        // Hit Player
                        AttackingPlayer();
                    } else {
                        Debug.Log(raycastHit2D.collider.gameObject);
                        // Hit something else
                    }
                }
            }
        }
    }

    public void AttackingPlayer() {
        source.Play();
        player.transform.position =  new Vector3(-14f, 4.5f, 0f);    
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public Vector3 GetAimDir() {
        return lastMoveDir;
    }

}

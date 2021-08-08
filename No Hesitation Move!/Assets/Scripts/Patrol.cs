using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    public Animator anim;
    public Image img_fade;

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
        img_fade.CrossFadeAlpha(0, 0.0f, true);
    }

    void FixedUpdate()
    {
        FindTargetPlayer();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 aimDir = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20));
        //Debug.Log(Time.deltaTime);
        fieldOfView.SetOrigin(transform.position);
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[Spot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[Spot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                if (Spot != moveSpots.Length - 1)
                {
                    Spot++;
                }
                else
                {
                    Spot = 0;
                }
                waitTime = startWaitTime;

                //Use this to have a rotation in the direction of the next spot
                
                fieldOfView.SetAimFromDirection(moveSpots[Spot].position - transform.position);
                
                //Use this to have a random rotation in a certain range
                //fieldOfView.SetRandomAimDirection(-90,90);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }


    }

    private void FindTargetPlayer()
    {
        if (Vector3.Distance(GetPosition(), player.transform.position) < viewDistance)
        {
            //Debug.Log("Player inside viewDistance");
            Vector3 dirToPlayer = (player.transform.position - GetPosition()).normalized;
            Debug.DrawRay(GetPosition(), dirToPlayer, Color.white, 0.5f);
            Debug.DrawRay(GetPosition(), lastMoveDir, Color.red, 0.5f);
            if (Vector3.Angle(GetAimDir(), dirToPlayer) < fov / 2f)
            {
                Debug.Log("Player inside Field of View");
                RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToPlayer, viewDistance, LayerMask.GetMask("Player", "BehindMask"));
                if (raycastHit2D.collider != null)
                {
                    // Hit something
                    //Debug.Log("Hit something");
                    if (raycastHit2D.collider.gameObject.GetComponent<playerMovement>() != null)
                    {
                        // Hit Player
                        //Debug.Log("Hit Player");
                        AttackingPlayer();
                    }
                    else
                    {
                        Debug.Log(raycastHit2D.collider.gameObject);
                        // Hit something else
                    }
                }
            }
        }
    }

    public void AttackingPlayer()
    {
        source.Play();
        // anim.SetTrigger("FadeOut");
        waitTime = 1;
        StartCoroutine(delay_player());
        source.Play();
    }

    IEnumerator delay_player()
    {
        player.GetComponent<playerMovement>().anim.SetFloat("Speed", 0.0f);
        player.GetComponent<playerMovement>().enabled = false;
        img_fade.CrossFadeAlpha(1, 0.5f, false);

        yield return new WaitForSecondsRealtime(1.5f);

        player.transform.position = new Vector3(-14f, 4.5f, 0f);
        img_fade.CrossFadeAlpha(0, 1.0f, false);

        yield return new WaitForSecondsRealtime(1.5f);
        // anim.SetTrigger("FadeIn");
        player.GetComponent<playerMovement>().enabled = true;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetAimDir()
    {
        float deg = fieldOfView.startingAngle - fov / 2f;
        float rad = deg * Mathf.Deg2Rad;
        lastMoveDir.x = Mathf.Cos(rad);
        lastMoveDir.y = Mathf.Sin(rad);
        return lastMoveDir;
    }

}

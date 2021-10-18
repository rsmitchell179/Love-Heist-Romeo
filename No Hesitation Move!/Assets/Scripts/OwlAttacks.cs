using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlAttacks : MonoBehaviour
{
    public AudioSource tornado_sound;
    public AudioSource pushback_sound;
    [SerializeField] private float _timeBetweenAttacks = 2.5f;
    [SerializeField] private float _timeUntilDestroyingObstacles = 2f;
    [SerializeField] private Rigidbody2D _target;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private PicturePuzzlePiece[] _puzzlePieces;
    [Header("Owl Components")]
    public Animator owl_anim;
    [SerializeField] bool is_flapping;
    [SerializeField] bool continue_attacking;
    public PicturePuzzle picture_puzzle_script;
    // Start is called before the first frame update
    void Start()
    {
        _puzzlePieces = FindObjectsOfType<PicturePuzzlePiece>();
        continue_attacking = picture_puzzle_script.puzzle_not_complete;
        StartCoroutine(AttacksCoroutine());
    }

    void Update()
    {
        if(is_flapping == true)
        {
            owl_anim.SetBool("is_flapping", true);
        }
        else
        {
            owl_anim.SetBool("is_flapping", false);
        }

        continue_attacking = picture_puzzle_script.puzzle_not_complete;
    }

    IEnumerator AttacksCoroutine()
    {
        while (continue_attacking)
        {
            yield return new WaitForSeconds(_timeBetweenAttacks);
            if (Random.Range(0f,1f)<.5f)
            {
                // is_flapping = true;
                // StartCoroutine(play_flap_animation());
                yield return SpawnObstacleCoroutine();
            }
            else
            {
                is_flapping = true;
                StartCoroutine(play_flap_animation());
                yield return BlowBackPlayerCoroutine();
            }
        }
    }

    IEnumerator SpawnObstacleCoroutine()
    {   
        int count = 7;
        GameObject[] go = new GameObject[7];
        tornado_sound.Play();
        System.Random rng = new System.Random();
        _puzzlePieces = Shuffle(rng, _puzzlePieces);
        for (int i = 0; i < count; i++)
        {
            go[i] = Instantiate(_obstacle, transform.position, Quaternion.identity);
            Vector3 nextPosition = _puzzlePieces[i].transform.position + (Vector3)Random.insideUnitCircle;
            while (Vector2.Distance(go[i].transform.position, nextPosition) >0)
            {
                go[i].transform.position = Vector2.MoveTowards(go[i].transform.position, nextPosition, Time.deltaTime * 10f);
                yield return null;
            }
        }
        yield return new WaitForSeconds(_timeUntilDestroyingObstacles);
        for (int i = 0; i < count; i++)
        {
            Destroy(go[i]);
            yield return new WaitForSeconds(.1f);
        }

        /* for video testing */
        // yield return null;
    }
    IEnumerator BlowBackPlayerCoroutine()
    {

        yield return new WaitForSecondsRealtime(0.3f);

        Vector3 velocity;
        pushback_sound.Play();
        velocity = Vector3.down;
        print(velocity);
        float timer = 0;

        Debug.Log("is_flapping is " + is_flapping);

        while (timer<1f)
        {
            _target.transform.position += velocity * Time.deltaTime * 4.5f;
            timer += Time.deltaTime;
            Debug.Log(timer);
            yield return null;
        }

        /* for video testing */
        // yield return null;
    }

    IEnumerator play_flap_animation()
    {
        yield return new WaitForSecondsRealtime(1.0f);

        is_flapping = false;
    }

    public static PicturePuzzlePiece[] Shuffle(System.Random rng, PicturePuzzlePiece[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            PicturePuzzlePiece temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
        return array;
    }
}

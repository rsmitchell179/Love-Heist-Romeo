using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlAttacks : MonoBehaviour
{
    AudioSource source;
    [SerializeField] private float _timeBetweenAttacks = 2.5f;
    [SerializeField] private float _timeUntilDestroyingObstacles = 2f;
    [SerializeField] private Rigidbody2D _target;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private PicturePuzzlePiece[] _puzzlePieces;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        _puzzlePieces = FindObjectsOfType<PicturePuzzlePiece>();
        StartCoroutine(AttacksCoroutine());
    }

    IEnumerator AttacksCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenAttacks);
            if (Random.Range(0f,1f)<.5f)
            {
                yield return SpawnObstacleCoroutine();
            }
            else
            {
                yield return BlowBackPlayerCoroutine();
            }
        }
    }

    IEnumerator SpawnObstacleCoroutine()
    {
        int count = 7;
        GameObject[] go = new GameObject[7];
        source.Play();
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
    }
    IEnumerator BlowBackPlayerCoroutine()
    {
        Vector3 velocity;
        source.Play();
        velocity = Vector3.down;
        print(velocity);
        float timer = 0;

        while (timer<1f)
        {
            timer += Time.deltaTime;
            _target.transform.position += velocity * Time.deltaTime * 5f;
            yield return null;
        }

        yield return null;
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

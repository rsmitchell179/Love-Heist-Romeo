using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PicturePuzzle : MonoBehaviour
{

    public Transform[] puzzlepieces;
    public Image img_fade;
    [SerializeField]
    int[] zRoatations;
    private bool _active = false;
    public OwlAttacks owl_attacks;

    void Awake()
    {
        img_fade.CrossFadeAlpha(0, 0.0f, true);

    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }


    void Setup()
    {
        foreach(Transform piece in puzzlepieces)
        {
            piece.Rotate(new Vector3(0, 0, zRoatations[Random.Range(0, zRoatations.Length)]));
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RotatePiece();
        }
    }

    void RotatePiece()
    {
        if (_active) return;
        _active = true;
        StartCoroutine(RotatePieceCoroutine());
    }

    private IEnumerator RotatePieceCoroutine()
    {
        foreach (Transform piece in puzzlepieces)
        {
            if (piece.GetComponent<PicturePuzzlePiece>().activated) {
                yield return RotateCoroutine(piece);
            }
        }


        /*foreach (Transform piece in puzzlepieces)
        {
            if (piece.GetComponent<PicturePuzzlePiece>().activated)
                piece.Rotate(new Vector3(0, 0, 90));
            if (piece.eulerAngles.z > 270)
                piece.eulerAngles = Vector3.zero;
        }*/
        yield return null;
        CheckPuzzleComplete();
        _active = false;
    }

    IEnumerator RotateCoroutine(Transform piece)
    {
        Vector3 eulerAngles = piece.eulerAngles;
        Vector3 nextEulerAngle = piece.eulerAngles + new Vector3(0,0,90f);
        while (eulerAngles.z< nextEulerAngle.z)
        {
            eulerAngles.z += Time.deltaTime * 180f;
            piece.eulerAngles = eulerAngles;
            yield return null;
        }
        piece.eulerAngles = nextEulerAngle;
    }

    void CheckPuzzleComplete()
    {
        int i = 0;
        foreach(Transform piece in puzzlepieces)
        {
            if (piece.eulerAngles.z<90)
            {
                i++;
            }
        }
        Debug.Log(i);
        if (i == puzzlepieces.Length)
        {
            owl_attacks.enabled = false;
            Debug.Log("PuzzleComplete");
            GlobalVars.rc_hasCollect = true;

            var puzzle_script = Object.FindObjectsOfType<PicturePuzzlePiece>();
            foreach(var puzzle in puzzle_script)
            {
                puzzle.is_not_finished = false;
                Debug.Log("in here");
                // puzzle.enabled = false;
            }
            StartCoroutine(next_scene());

            // SceneManager.LoadScene("RC TheArtGallery");
        }

    }

    IEnumerator next_scene()
    {
        yield return new WaitForSecondsRealtime(2.0f);

        img_fade.CrossFadeAlpha(1, 2.0f, false);

        yield return new WaitForSecondsRealtime(4.0f);

        SceneManager.LoadScene("RC TheArtGallery");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePuzzle : MonoBehaviour
{

    public Transform[] puzzlepieces;
    [SerializeField]
    int[] zRoatations;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            RotatePiece();
        }
    }

    void RotatePiece()
    {
        foreach (Transform piece in puzzlepieces)
        {
            if (piece.GetComponent<PicturePuzzlePiece>().activated)
                piece.Rotate(new Vector3(0, 0, 90));
            if (piece.eulerAngles.z > 270)
                piece.eulerAngles = Vector3.zero;
        }
        CheckPuzzleComplete();
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
            Debug.Log("PuzzleComplete");
        }
    }
}

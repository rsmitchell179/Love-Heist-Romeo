using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Row : MonoBehaviour
{

    [SerializeField] private float _ySpacing = 50f;
    [SerializeField] private float _maxMoveSpeed = 1500f;
    [SerializeField] private float _timeToStop = 5f;

    private float _maxY;
    private float _size;
    private GameObject[] _tiles;

    private bool _startSpinning;

    float _delayTimer = 0;
    float _moveSpeed;

    float _stopTimer;

    public void Init(GameObject[] tiles)
    {
        _tiles = new GameObject[tiles.Length];
        Vector2 position = transform.position;
        position.x = 0;
        _size = tiles[0].GetComponent<RectTransform>().rect.height + _ySpacing;
        _maxY = (tiles.Length / 2) * _size;
        position.y = _maxY / 2f + _size +  ((tiles.Length%4 == 0 || tiles.Length % 4 == 1) ?_size:_size / 2f);
        for (int i = 0; i < tiles.Length; i++)
        {
            position.y -= _size;
            _tiles[i] = Instantiate(tiles[i], transform);
            _tiles[i].transform.localPosition = position;
        }
    }

    public void StartSpinning(float delay)
    {
        _delayTimer = delay;
        _stopTimer = _timeToStop;
        _moveSpeed = _maxMoveSpeed + Random.Range(.5f, 1f) * 1000f;
        SpinIt(delay);
    }


    private void Update()
    {
        if (!_startSpinning)
        {
            return;
        }
        if (_delayTimer>=0)
        {
            _delayTimer -= Time.deltaTime;
            return;
        }

        if (_moveSpeed<100f)
        {
            EndSpinning();
        }
        else
        {
            NormalSpinning();
        }

    }

    private void EndSpinning()
    {
        int closestIndex = 0;
        float smallestDistance = float.MaxValue;

        for (int i = 0; i < _tiles.Length; i++)
        {
            if (Mathf.Abs(_tiles[i].transform.localPosition.y) < smallestDistance)
            {
                smallestDistance = Mathf.Abs(_tiles[i].transform.localPosition.y);
                closestIndex = i;
            }
            if (Mathf.Abs(_tiles[i].transform.localPosition.y) < 100f)
            {
                smallestDistance = 100f * Mathf.Sign(_tiles[i].transform.localPosition.y);
            }
        }

        for (int i = 0; i < _tiles.Length; i++)
        {
            _tiles[i].transform.localPosition -= Vector3.up * Time.deltaTime * ((Mathf.Abs(smallestDistance) < 5f) ? _tiles[closestIndex].transform.localPosition.y : smallestDistance);
        }

        Loop();

        if (Mathf.Abs(_tiles[closestIndex].transform.localPosition.y) < 2f)
        {
            _startSpinning = false;
            SlotMachine.OnFinishedSpinningTrigger(transform.GetSiblingIndex(), _tiles[closestIndex].GetComponent<SlotTile>());
        }
    }

    private void Loop()
    {
        for (int i = 0; i < _tiles.Length; i++)
        {
            if (_tiles[i].transform.localPosition.y <= -_maxY)
            {
                int nextIndex = (i + 1) % _tiles.Length;
                Vector3 newPosition = _tiles[nextIndex].transform.localPosition;
                newPosition.y += _size;
                _tiles[i].transform.localPosition = newPosition;
            }
        }
    }

    private void NormalSpinning()
    {
        for (int i = 0; i < _tiles.Length; i++)
        {
            _tiles[i].transform.localPosition -= Vector3.up * Time.deltaTime * _moveSpeed;
        }

        if (_stopTimer > 0)
        {
            _stopTimer -= Time.deltaTime;
        }
        else
        {
            _moveSpeed *= .99f;
        }
        Loop();
    }

    public void SpinIt(float delay)
    {
        _delayTimer = delay;
        _startSpinning = true;
    }
}
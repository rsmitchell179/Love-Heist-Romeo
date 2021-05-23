using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlotMachine : MonoBehaviour
{
     AudioSource[] source;
     AudioSource lever;
     AudioSource slot;
     AudioSource lose;
     AudioSource win;

    public static event Action<int, SlotTile> OnFinishedSpinning;
    public UnityEvent OnAllValuesAreTheSame;
    private SlotTile[] _slotTile = new SlotTile[3];
    private int _numberOfRowsFinished = 0;

    private bool _canSpin = true;
    private int _timesSpinned = 0;

    [SerializeField] private KeyCode _spinButton = KeyCode.Space;
    [SerializeField] private KeyCode _spinButton2 = KeyCode.Space;
    [SerializeField] private GameObject[] _tiles;
    [SerializeField] private Row[] _row;

    private void Awake()
    {
        source = GetComponents<AudioSource>(); 
        lever = source[1];
        slot  = source[2];
        lose  = source[3];
        win   = source[0];

        OnFinishedSpinning += FinishingSpinning;
        for (int i = 0; i < _row.Length; i++)
        {
            _row[i].Init(_tiles);
        }

    }

    private void Update()
    {   
        if(win.time >= win.clip.length){    //Wait for Win Sound then have Dialogue 
                  OnAllValuesAreTheSame?.Invoke();
                }
        if (Input.GetKeyDown(_spinButton))
        {
            StartSpinning();
        }

        if (Input.GetKeyDown(_spinButton2))
        {
            StartSpinning();
        }
    }

    public void StartSpinning()
    {   
        lever.Play();
        slot.Play();
        if (!_canSpin)
        {

            return;
            
        }
        if (Between(_timesSpinned, 1, _tiles.Length-1))
        {
            for (int i = 0; i < _row.Length; i++)
            {
                _row[i].Remove();
            }
        }
        
        _canSpin = false;
        _numberOfRowsFinished = 0;
        for (int i = 0; i < _row.Length; i++)
        {
            _row[i].StartSpinning(i * .5f);
        }
        _timesSpinned++;
    }

    public bool Between(int value,int min,int max)
    {
        return value <= max && value >= min;
    }


    public void FinishingSpinning(int index, SlotTile slotTile)
    {
        _slotTile[index] = slotTile;
        _numberOfRowsFinished++;
        if (_numberOfRowsFinished == 3)
        {   
            slot.Stop();
            int count = 0;
            for (int i = 0; i < _slotTile.Length; i++)
            {
                print(_slotTile[i] + " " + _slotTile[i].Value);
                if (_slotTile[i].Value == _slotTile[0].Value)
                {
                    count++;
                }
            }
            print("count : " + count);
            if (count == 3)
            {   
                win.Play();
                if(win.time == win.clip.length){
                  OnAllValuesAreTheSame?.Invoke();
                }
                
                
            }else{
              lose.Play();
            }
            _canSpin = true;
        }
    }

    private void OnDestroy()
    {
        OnFinishedSpinning += FinishingSpinning;
    }

    public static void OnFinishedSpinningTrigger(int index, SlotTile tile)
    {
        OnFinishedSpinning?.Invoke(index, tile);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int RouletteHoldNumberNumber => _rouletteHoldNumber;
    
    [FormerlySerializedAs("_holdImage")]
    [SerializeField]
    [Header("ホールドイメージ")]
    private List<Image> _holdImageList;

    private int _rouletteHoldNumber;

    private void Start()
    {
        _holdImageList.ForEach(x => x.gameObject.SetActive(false));
        _rouletteHoldNumber = -1;
    }

    public void RouletteHold()
    {
        _rouletteHoldNumber++;
        Debug.Log(_rouletteHoldNumber);

        if (_rouletteHoldNumber >= _holdImageList.Count)
        {
            return;
        }
        
        _holdImageList[_rouletteHoldNumber].gameObject.SetActive(true);
    }

    public void RouletteHoldConsumption()
    {
        _rouletteHoldNumber--;
        
        if (_rouletteHoldNumber <= 0)
        {
            Debug.Log("0以下");
            _holdImageList.ForEach(x => x.gameObject.SetActive(false));
        }
    }
}

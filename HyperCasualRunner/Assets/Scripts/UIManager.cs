using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Transform battleEntrance;
    [SerializeField] Transform playerPos;
    [SerializeField] Slider _slider;

    bool _sliderOff;
    public bool SliderOff { get => _sliderOff; set => _sliderOff = value; }

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _slider.maxValue = Vector3.Distance(playerPos.position, battleEntrance.position);
    }


    void Update()
    {
        if (!_sliderOff)
        {
            _slider.value = Vector3.Distance(playerPos.position, battleEntrance.position);
        }
        else
        {
            _slider.gameObject.SetActive(false);
        }
        
    }
}


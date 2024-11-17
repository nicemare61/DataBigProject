using System.Collections;
using System.Collections.Generic;
using Searching;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : OOPMapGenerator
{
    private OOPMapGenerator mapGenerator;

    [SerializeField] private Text waveText;
    
    // Start is called before the first frame update
    void Awake()
    {
        UpdateWaveCount();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateWaveCount();
    }

    private void UpdateWaveCount()
    {
        waveText.text = $"Wave: {mapGenerator.waveCount}";
    }
}

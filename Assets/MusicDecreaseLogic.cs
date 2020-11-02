using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDecreaseLogic : MonoBehaviour
{
    public string[] musicToDecrease;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(string musicName in musicToDecrease)
        {
            AudioManager.instance.DecreaseVolume(musicName);
        }
        
    }
}

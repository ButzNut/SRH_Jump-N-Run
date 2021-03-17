using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlaybackSpeed : MonoBehaviour
{
    public float GameTime;
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = GameTime;
    }
}

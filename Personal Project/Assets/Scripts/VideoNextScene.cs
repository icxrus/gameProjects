using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoNextScene : MonoBehaviour
{
    VideoPlayer video;

    void Start()
    {

        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += OnMovieEnded;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
     
    }

    // Load scene after video end
    void OnMovieEnded(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Menu");
    }
}

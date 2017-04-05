using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroVideo : MonoBehaviour
{
    MovieTexture movie;
    Renderer r;

    private void Start()
    {
        r = GetComponent<Renderer>();
        movie = (MovieTexture)r.material.mainTexture;
        movie.Play();
    }

    private void Update()
    {
        if(movie.isPlaying != true)
        {
            GameObject.Find("SceneController").GetComponent<SceneController>().MenuScene();
        }
    }


}

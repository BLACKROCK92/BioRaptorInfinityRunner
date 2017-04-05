using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour {

	void Start () {
        DontDestroyOnLoad(this);
	}
    private void OnTriggerEnter(Collider other)
    {

    }
}

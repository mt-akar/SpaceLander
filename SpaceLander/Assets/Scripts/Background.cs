using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Background : MonoBehaviour {

    public GameObject cam;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(cam.transform.position.x / 2, cam.transform.position.y / 2, 10);
    }
}

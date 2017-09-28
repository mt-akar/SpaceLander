using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.layer == 8 || col.gameObject.layer == 9)
        {
            Debug.Log("asd");
        }
    }
}

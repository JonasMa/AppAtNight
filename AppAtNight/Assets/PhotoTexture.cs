using UnityEngine;
using System.Collections;

public class PhotoTexture : MonoBehaviour {

    public Texture picture;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.mainTexture = picture;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

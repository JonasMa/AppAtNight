using UnityEngine;
using System.Collections;

public class ShowTextInTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // change opacity to zero. this is a dirty hack do 'disable' text
        Color col = GetComponent<TextMesh>().color;
        col.a = 0f;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        // change opacity to zero. this is a dirty hack do 'disable' text
        Color col = GetComponent<TextMesh>().color;
        col.a = 1f;
        GetComponent<TextMesh>().color = col;
    }

    private void OnTriggerExit(Collider other)
    {
        // change opacity back to one. this is a dirty hack do 'enable' text
        Color col = GetComponent<TextMesh>().color;
        col.a = 0f;
        GetComponent<TextMesh>().color = col;
    }
}

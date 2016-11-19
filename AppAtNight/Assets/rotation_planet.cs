using UnityEngine;
using System.Collections;

public class rotation_planet : MonoBehaviour {

    public float rotationSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(0, rotationSpeed * 0.1f, 0);
	}
}

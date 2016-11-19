using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

    public Transform lookAtObj;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.LookAt(lookAtObj);
        //transform.rotation = Quaternion.Euler(transform.rotation.x,
            //transform.rotation.y, transform.rotation.z);

    }
}

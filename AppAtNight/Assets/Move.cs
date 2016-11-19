using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    public float range = 1f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float h = Input.GetAxisRaw("Horizontal");
        float xPos = h * range;

        transform.position = new Vector3(xPos, 2f, 0);

        float i = Input.GetAxisRaw("Vertical");
        float yPos = i * range;

        transform.position = new Vector3(yPos, 2f, 0);


    }
}

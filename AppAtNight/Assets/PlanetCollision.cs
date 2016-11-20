using UnityEngine;
using System.Collections;

public class PlanetCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("Plane").GetComponent<MeshRenderer>().enabled = true;
        collision.gameObject.GetComponent<MoveAuto>().OnCollideWithPlanet();
    }

}

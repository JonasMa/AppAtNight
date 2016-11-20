using UnityEngine;
using System.Collections;

public class PlanetCollision : MonoBehaviour {

    public Transform insideSphere;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<MoveAuto>().OnCollideWithPlanet();
        insideSphere.gameObject.GetComponent<SphereManager>().OpenCloseSphere(true);
    }

    private void OnTriggerExit(Collider other)
    {
        insideSphere.gameObject.GetComponent<SphereManager>().OpenCloseSphere(false);
    }

}

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
        Debug.Log("onplanetenter");
        insideSphere.gameObject.GetComponent<SphereManager>().OpenCloseSphere(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("onplanetexit");
        insideSphere.gameObject.GetComponent<SphereManager>().OpenCloseSphere(false);
    }

}

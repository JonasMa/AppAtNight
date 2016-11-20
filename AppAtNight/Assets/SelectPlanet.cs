using UnityEngine;
using System.Collections;

public class SelectPlanet : MonoBehaviour {


    public GameObject cameraMoveObject;
    bool mouseControls = true;

    bool[] visitedPlanets = { false, false, false, false };

    static readonly string[] PLANET_CENTER_NAMES = { "planet1_center", "planet2_center", "planet3_center", "planet4_center" };
    static readonly string[] PLANET_NAMES = { "Planet1", "Planet2" };


    Transform[] planetCenters;
    Transform moveTo;

    bool isGoingIntoPlanet = false; // is getting inversed on (first) click

    // Use this for initialization
    void Start ()
    {

#if UNITY_ANDROID
        mouseControls = false;
#endif
        OVRTouchpad.Create();
        OVRTouchpad.TouchHandler += HandleTouchHandler;
        planetCenters = new Transform[]{ GameObject.Find(PLANET_CENTER_NAMES[0]).transform, 
            GameObject.Find(PLANET_CENTER_NAMES[1]).transform,
            GameObject.Find(PLANET_CENTER_NAMES[2]).transform,
            GameObject.Find(PLANET_CENTER_NAMES[3]).transform};
    }
	
    void HandleTouchHandler (object sender, System.EventArgs e)
    {
        OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;

        if(touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap
            && ! mouseControls)
        {
            GetToNearestPlanetOrAway();
        }
        
    }

	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonUp("Fire1")
            && mouseControls)
        {
            GetToNearestPlanetOrAway();
        }
	}

    void ContinueMoveRoute ()
    {
        GetComponent<MoveAuto>().ContinueAutoMove();

    }

    void GetToNearestPlanetOrAway()
    {
        isGoingIntoPlanet = !isGoingIntoPlanet;
        //Debug.Log("isGoingIntoPlanet: " + isGoingIntoPlanet);

        if (isGoingIntoPlanet)
        {
            GetNearestPlanet();
        }
        else
        {
            ContinueMoveRoute();
        }
        
        // FIXME dead code yo
        /*
        Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward);
        

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 50))
        {
            
            OnRayHit(hit.collider);
        }
        */
    }

    void GetNearestPlanet()
    {
        float[] distances = new float[planetCenters.Length];
        for (int i = 0; i < planetCenters.Length; i++)
        {
            if (planetCenters[i] != null)
            {
                distances[i] = Vector3.Distance(transform.position, planetCenters[i].position);
            }
            else distances[i] = 1000f;
        }

        float min = Mathf.Min(distances);

        for(int i=0; i<distances.Length; i++)
        {
            if(distances[i] == min
                && visitedPlanets[i] == false)
            {
                MoveAuto move = GetComponent<MoveAuto>();
                move.MoveToPlanet(planetCenters[i]);
                visitedPlanets[i] = true; // this may be obsolete because of HACK below
                planetCenters[i] = null; // HACK for never visiting planet again
                return;
            }
        }
    }

    void OnRayHit (Collider coll)
    {
        string name = coll.gameObject.name;
        foreach(string s in PLANET_NAMES)
        {
            if (s.Equals(name))
            {
                MoveAuto move = GetComponent<MoveAuto>();
                move.MoveToPlanet(GameObject.Find(s).transform);
            }
        }
    }
}

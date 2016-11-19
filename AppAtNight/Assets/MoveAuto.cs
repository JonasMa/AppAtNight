using UnityEngine;
using System.Collections;

public class MoveAuto : MonoBehaviour {

    public Transform[] stops;
    public float moveSpeed = 1f;

    Vector3 currentStop;
    int currentStopNum = 0;
    bool isMoving = true;


    // Use this for initialization
    void Start () {
        if (stops.Length != 0)
        {
            currentStop = stops[currentStopNum].position;
        }
 

    }
    

    // Update is called once per frame
    void Update () {



        if (isMoving)
        {
            Quaternion lookRotation = Quaternion.LookRotation((currentStop - transform.position).normalized);
            transform.position += lookRotation * Vector3.forward * Time.deltaTime * moveSpeed;

            if (Vector3.Distance( transform.position, currentStop) < 0.02f)
            {
                currentStopNum++;
                if (stops.Length > currentStopNum)
                {
                    currentStop = stops[currentStopNum].position;
                }
                else
                {
                    isMoving = false;
                }
            }
        }
    }
}

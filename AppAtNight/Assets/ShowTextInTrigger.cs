using UnityEngine;
using System.Collections;

public class ShowTextInTrigger : MonoBehaviour {

    float _from;
    float _to;
    bool _isTransition = false;
    bool _isCountUp = false;
    int _transCounter = 0;
    const int COUNTER_MAX = 25;

    TextMesh textMesh;


    // Use this for initialization
    void Start () {
        textMesh = GetComponent<TextMesh>();

        // change opacity to zero. this is a dirty hack do 'disable' text
        Color col = textMesh.color;
        col.a = 0f;
    }
	
	void FixedUpdate () {
        if (_isTransition)
        {
            DoAlphaTransition();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        // change opacity to zero. this is a dirty hack do 'disable' text
        Color col = textMesh.color;
        col.a = 1f;
        textMesh.color = col;
    }

    private void OnTriggerExit(Collider other)
    {
        // change opacity back to one. this is a dirty hack do 'enable' text
       // Color col = textMesh.color;
       // col.a = 0f;
       // textMesh.color = col;

        AlphaTransition(false);
    }

    private void AlphaTransition (bool isCountUp)
    {
        _isTransition = true;
        _isCountUp = isCountUp;
        if (isCountUp)
        {
            _transCounter = 0;
        }
        else
        {
            _transCounter = COUNTER_MAX;
        }
    }

    void DoAlphaTransition()
    {
        if(_transCounter > COUNTER_MAX
            || _transCounter < 0)
        {
            _isTransition = false;
            _transCounter = 0;
            return;
        }

        Color col = textMesh.color;
        col.a = 1 - (COUNTER_MAX - _transCounter) / COUNTER_MAX;
        textMesh.color = col;

        if (_isCountUp)
        {
            _transCounter++;
        }
        else
        {
            _transCounter--;
        }

        
    }
}

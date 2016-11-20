using UnityEngine;
using System.Collections;

public class SphereManager : MonoBehaviour {

    public Texture[] pics;
    public Transform[] parts;
    public Transform topBottomParts;
    public Transform center;
    public float rotationSpeed = 1.5f;

    int FRAME_DURATION = 50;
    float lerp = 0f;
    bool isLerping = false;
    bool isRotating = false;
    bool isOpening = true;

    Vector3[] newPositions;
    Vector3[] oldPositions;
    Vector3 newLocalScale;
    Vector3 oldLocalScale;

    // Use this for initialization
    void Start () {
        
        for (int i = 0; i< parts.Length; i++) {

            parts[i].GetComponent<MeshRenderer>().material.mainTexture = pics[i];

            /*
            if (meshRend.materials.Length > i) {
                if (!meshRend.materials[i].name.Contains("cinder"))
                {
                    Material m = meshRend.materials[i];
                    m.mainTexture = pics[i];
                }
            }
            */
        }
        oldPositions = new Vector3[parts.Length];
        newPositions = new Vector3[parts.Length];
        newLocalScale = new Vector3();
        oldLocalScale = new Vector3();
        Explode();


    }

    void Explode()
    {
    
        for (int i = 0; i < parts.Length; i++)
        {
            Vector3 newPos = parts[i].GetComponent<Renderer>().bounds.center - center.position;
            //parts[i].position += newPos/2;
            oldPositions[i] = parts[i].position;
            newPositions[i] = parts[i].position + newPos / 2;
        }
        oldLocalScale = topBottomParts.localScale;
        newLocalScale = new Vector3(topBottomParts.localScale.x, topBottomParts.localScale.y, topBottomParts.localScale.z * 1.5f);
        //topBottomParts.localScale

        isLerping = true;
        isRotating = true;
    }

    void LerpExplosion()
    {
        if (isLerping)
        {
            if (isOpening)
            {
                lerp += 1f / FRAME_DURATION;
            }
            else
            {
                lerp -= 1f / FRAME_DURATION;
            }

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].position = Vector3.Lerp(oldPositions[i], newPositions[i], lerp);

            }
            topBottomParts.localScale = Vector3.Lerp(oldLocalScale, newLocalScale, lerp);

            if(lerp > 1f)
            {
                isLerping = false;
                lerp = 0f;
            }
        }

        
    }

    void RotateParts()
    {
        if (isRotating) {
            transform.Rotate(0, rotationSpeed * 0.1f, 0);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        LerpExplosion();
        RotateParts();

    }

    public void OpenCloseSphere (bool isOpening)
    {
        this.isOpening = isOpening;

        if (isOpening)
        {
            lerp = 0f;
            isRotating = true;
            Explode();
        }
        else
        {
            lerp = 1f;
            isRotating = false;
        }

        isLerping = true;
    }
}

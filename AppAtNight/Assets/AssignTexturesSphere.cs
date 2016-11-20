using UnityEngine;
using System.Collections;

public class InnerSphereManager : MonoBehaviour {

    public Texture[] pics;
    public Transform[] parts;
    public Transform topBottomParts;
    public Transform center;
    public float rotationSpeed = 1.5f;

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

        Explode();


    }

    void Explode()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            Vector3 newPos = parts[i].GetComponent<Renderer>().bounds.center - center.position;
            parts[i].position += newPos/2;
        }

        topBottomParts.localScale = new Vector3(topBottomParts.localScale.x, topBottomParts.localScale.y, topBottomParts.localScale.z *1.5f);
        

    }

    void RotateParts()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].Rotate(0, rotationSpeed * 1f, 0);
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        RotateParts();

    }
}

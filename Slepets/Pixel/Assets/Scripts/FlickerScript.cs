using UnityEngine;
using System.Collections;

public class FlickerScript : MonoBehaviour {

	// Pulse light's intensity over time	
	public float duration = 1.0f;
	float phi;
	float amplitude;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// argument for cosine
        phi = Time.time / duration * 2f * Mathf.PI;
        // get cosine and transform from -1..1 to 0..1 range
        amplitude = Mathf.Cos( phi ) * 0.5f + 0.5f;
        // set light color
        light.intensity = amplitude;
	}
}

	
	

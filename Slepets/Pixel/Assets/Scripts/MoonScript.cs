using UnityEngine;
using System.Collections;

public class MoonScript : MonoBehaviour {
	public float startX, startY, startZ;
	// Use this for initialization
	void Start () {
		startX = transform.position.x;
		startY = transform.position.y;
		startZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(
				GameObject.Find("First Person Controller").transform.position.x+startX, 
				GameObject.Find("First Person Controller").transform.position.y+startY, 
				GameObject.Find("First Person Controller").transform.position.z+startZ
		);


	}
}

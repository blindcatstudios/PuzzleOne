using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	float speed = 0.001f;
	// Update is called once per frame
	void Update () 
	{
		transform.localRotation = new Quaternion(0,0,transform.localRotation.z + speed, transform.localRotation.w);

	}
}

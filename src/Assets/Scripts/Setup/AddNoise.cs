using UnityEngine;
using System.Collections;

public class AddNoise : MonoBehaviour {

	public Vector3 Strength = new Vector3(0.1f, 0.1f, 0.1f);
	public float Freq = 0.25f;

	void Start () 
	{
		gameObject.AddComponent(typeof(MegaNoise));
		var noise = (MegaNoise)gameObject.GetComponent(typeof(MegaNoise));
		noise.Strength = Strength;
		noise.Animate = true;
		noise.Freq = Freq;
		noise.Phase = Random.Range(0f,100f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Change rippleBehavior to be an event listener that takes in 
 * ripple source location (x,y,z) 
 * Everytime we hit the cain against something, we emit an event 
 * 
 * TODO: Set cutoff distances where the ripples stop
 * TODO: 
 */


//[ExecuteInEditMode]
public class rippleBehavior: MonoBehaviour {
	public Transform origin;
	public Renderer rend;
	float radius = 0.0f;
	Material mat;
	float upperBound = 10.0f;
	public Color wireColor;
	public Color baseColor;
	public float thickness = 10.0f;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.material.shader = Shader.Find("Custom/Echolocation");
		Vector3 origin_position = new Vector3 (origin.position.x, origin.position.y, origin.position.z);
		rend.material.SetVector ("_Center",origin_position );
		rend.material.SetColor ("_WireColor", wireColor);
		rend.material.SetColor ("_BaseColor", baseColor);
		rend.material.SetFloat ("_WireThickness", thickness);
	}

	void Update () {
        /*Debug.Log("-----------");
        
		if (radius < upperBound) {
			radius += 0.05f;
			//thickness = 0.0f;
		} else {

			radius = 0.0f;
			thickness = 10.0f;
		}
		*/
        rend.material.SetFloat ("_Radius", radius);
		rend.material.SetFloat ("_WireThickness", thickness);

	}
}

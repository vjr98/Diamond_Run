using UnityEngine;
using System.Collections;

public class RotateYScript : MonoBehaviour {

	public Vector3 rotationVector;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(0.0f, 0.0f, 0.15f);
	}
}
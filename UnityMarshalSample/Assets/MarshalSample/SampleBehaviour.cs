using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class SampleBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MarshalSample.Import.SetFloat(5.0f);
        Debug.Log(MarshalSample.Import.GetFloat());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

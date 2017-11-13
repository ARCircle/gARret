using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpornByEKey : MonoBehaviour {
	[SerializeField]GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    bool ispushed;
	void Update () {
		ispushed = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButton("Intractive");
	}
	void OnTriggerStay2D(Collider2D col)
	{ 
		if(ispushed && col.gameObject.tag== "Player")
		{
            target.GetComponent<Animator>().SetTrigger("clicked");
			target.active = true;
		}
	}
}

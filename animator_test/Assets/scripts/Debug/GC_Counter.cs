using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GC_Counter : MonoBehaviour {
int counter;
	// Use this for initialization
	void Start () 
	{
		counter = GC.CollectionCount(0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GC.CollectionCount(0)!=counter)
		{
			Debug.Log("GCCollect");
			counter = GC.CollectionCount(0);
		}
	}
}

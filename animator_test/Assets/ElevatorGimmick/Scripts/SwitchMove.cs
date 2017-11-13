using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMove : MonoBehaviour {
	private MoveFloor moveFloor;
	GameObject Points;


	public bool flag = false;

	// Use this for initialization
	void Start () {
		moveFloor = GetComponent<MoveFloor> ();
		Points = GameObject.Find ("points");
	}
	
	// Update is called once per frame
	void Update () {
		// Debug用
		if (flag)
			setRoute1_2();
	}

	void OnMouseDown(){
		moveFloor.count = 0;
		moveFloor.MoveStart ();
		moveFloor.Move ();
	}


	Transform getTransformFromID(int id){
		return Points.transform.Find ("p" + id);
	}

	void setRoute1_2(){
		List<Transform> pathList = new List<Transform> ();

		pathList.Add (getTransformFromID (1));
		pathList.Add (getTransformFromID (4));
		pathList.Add (getTransformFromID (9));
		pathList.Add (getTransformFromID (8));
		pathList.Add (getTransformFromID (10));

		moveFloor.pathpoint = pathList;
	}
}

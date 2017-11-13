using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roapwaymotor : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var joint = this.transform.parent.gameObject.GetComponent<HingeJoint2D>();
            joint.useMotor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var joint = this.transform.parent.gameObject.GetComponent<HingeJoint2D>();
            joint.useMotor = false;
        }
    }

}

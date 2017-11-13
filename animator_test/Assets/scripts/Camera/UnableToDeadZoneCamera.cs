using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnableToDeadZoneCamera : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
		Camera.main.gameObject.GetComponent<DeadzoneCamera> ().enabled = false;
    }
}

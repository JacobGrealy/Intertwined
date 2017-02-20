using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    void Start()
    {
        this.transform.position = GameObject.Find("Camera").transform.position;	
	}
	
}

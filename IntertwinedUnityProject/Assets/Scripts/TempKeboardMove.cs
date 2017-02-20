using UnityEngine;
using System.Collections;

public class TempKeboardMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 move = Vector3.zero;
        float factor = .2f;

	    if(Input.GetKey(KeyCode.UpArrow))
        {
            move.y += factor;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            move.y -= factor;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move.x -= factor;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move.x += factor;
        }
        this.gameObject.transform.Translate(move);
        if(Input.GetButtonDown("Fire1"))
        {
            this.GetComponent<ChangeDimensions>().ChangeDimension();
        }
	}
}

using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour
{

    private Tap tap;
    void Start()
    {
        tap = new Tap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            tap.Trigger(null);
        }

		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			tap.Trigger(null);
		}
    }
}

using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour
{

    private Tap tap;

    void Awake()
    {
        Input.multiTouchEnabled = false;
    }
    void Start()
    {
        tap = new Tap(this);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            SingleTouch();
        }
    }

    ///For single touch allowed only
    private void SingleTouch()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            tap.Trigger(null);
        }
    }
    ///For multiple fingers touching screen
    private void MultiTouch()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                tap.Trigger(null);
            }
        }
    }
}

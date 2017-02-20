using UnityEngine;
using System.Collections;

public class Tap
{
    private TouchController touch;
    private int times;
    private BallBehaviour ball;
    public Tap(TouchController touch)
    {
        this.touch = touch;
        ball = GameObject.Find("BallContainer").GetComponent<BallBehaviour>();
    }
    public Tap()
    {
        ball = GameObject.Find("BallContainer").GetComponent<BallBehaviour>();
    }
    public void Trigger(object data)
    {
        ball.Tap();
        ball.GetComponent<ChangeDimensions>().ChangeDimension();
        times++;
        Debug.Log("TAP TRIGGERED");
    }

}

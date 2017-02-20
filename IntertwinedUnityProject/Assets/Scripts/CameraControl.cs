using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public GameObject Ball;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = new Vector3(Ball.gameObject.transform.position.x, 0, -10);
    }
}

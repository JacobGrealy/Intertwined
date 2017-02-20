using UnityEngine;
using System.Collections;

public class SimpleGravity : MonoBehaviour {

    public bool GravityOn = true;
    public float Strength = 9.8f;
    public Vector3 Direction = Vector3.down;
    public Vector3 Velocity = Vector3.zero;
    public float Speed;
    public float MaxSpeed = 5;
    public GameObject GravityWell;

	// Use this for initialization
	void Start () {
        Speed = Velocity.magnitude;
	}
	
	// Update is called once per frame
	void Update () {
        Speed = Velocity.magnitude;
        if (GravityOn) AccelerateInDirOfGravity();
        if (GravityWell != null) GoTowardsObject();
        MoveInDirOfVelocity();
        Direction.Normalize();
	}

    void MoveInDirOfVelocity()
    {
        Vector3 normalizedVelocity = Speed * Time.deltaTime * Velocity;
        this.transform.Translate(normalizedVelocity.x, normalizedVelocity.y, 0);
    }

    void AccelerateInDirOfGravity()
    {
        float normalizedStrength = Strength * Time.deltaTime;
        Velocity += Direction * normalizedStrength;
        if(MaxSpeed >0) CapSpeed();
    }

    void CapSpeed()
    {
        Velocity = Velocity.magnitude <= MaxSpeed ? Velocity : Velocity.normalized * MaxSpeed;
    }

    void GoTowardsObject()
    {
        Direction = GravityWell.transform.position - this.transform.position;
        Direction = (new Vector3(Direction.x, Direction.y, 0)).normalized;
    }
}

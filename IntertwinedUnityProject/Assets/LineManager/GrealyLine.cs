using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrealyLine
{
	LineRenderer lineRenderer;
	//How fast the waves moves
	float speed = .3f;
	//The height of the wave
	float amplitude = 10f;

	//The points in the wave
	public IList<Vector3> points;

	//The t value of the wave (how far along the wave in time)
	private float time = 0;
	//The time since the last wave update
	private float dt = 0;
	//The position of the wave at time = 0
	private float phase;

	// Use this for initialization
	public GrealyLine(LineRenderer lineRenderer, float startPhase, float startingFreq, int lineResolution)
	{
		this.lineRenderer = lineRenderer;
		this.phase = startPhase;
		points = new List<Vector3> ();
	}

	// Update is called once per frame
	public void Update (float freq, float jitter, int lineResolution, float lineWidth) 
	{
		lineRenderer.SetVertexCount (lineResolution);
		points = new List<Vector3> ();
		time += (freq) * speed / Time.deltaTime;			
		//update eveypoint in the wave
		for (int i = 0; i < lineResolution; i++) 
		{
			float xPos = i * (lineWidth/lineResolution);
			points.Add(new Vector3 (xPos, (amplitude * Mathf.Sin ((2*Mathf.PI * (xPos+time) * freq) + phase)), 0));
			//Put point in the renderer and add jitter
			lineRenderer.SetPosition(i,points[i] + new Vector3(0,Random.Range(-jitter*amplitude,jitter*amplitude),0));
		}
	}
}
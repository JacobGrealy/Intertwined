using UnityEngine;
using System.Collections;

public class LineManager : MonoBehaviour 
{
	public bool line1Active;
	public Color line1ActiveColor;
	public Color line1NonActiveColor;
	public Color line2ActiveColor;
	public Color line2NonActiveColor;
	public float frequency1;
	public float frequency2;
	public float jitter1;
	public float jitter2;
	public int lineResolution;
	public float lineWidth;

    private float ScaledFrequency1;
    private float ScaledFrequency2;
    private float ScaledJitter1;
    private float ScaledJitter2;


	//public float
	public LineRenderer lineRend1;
	public LineRenderer lineRend2;

	public GrealyLine line1;
	public GrealyLine line2;
	//int Current line



	// Use this for initialization
	void Start ()
	{
		ScaleValues();
		//set linerenderer colors
		SwitchActiveLine ();		
		lineRend1.SetVertexCount (lineResolution);
		lineRend2.SetVertexCount (lineResolution);

		line1 = new GrealyLine (lineRend1,0,ScaledFrequency1,lineResolution);
		line2 = new GrealyLine (lineRend2,Mathf.PI,ScaledFrequency2,lineResolution);
	}


	// Update is called once per frame
	void Update () 
	{
        ScaleValues();
		line1.Update(ScaledFrequency1, ScaledJitter1,lineResolution, lineWidth);
		line2.Update(ScaledFrequency2, ScaledJitter2,lineResolution, lineWidth);

	}

	public void SwitchActiveLine()
	{
		line1Active = !line1Active;
		if(line1Active)
		{
			lineRend1.SetColors(line1ActiveColor,line1ActiveColor);
			lineRend2.SetColors(line2NonActiveColor,line2NonActiveColor);
		}
		else
		{
			lineRend1.SetColors(line1NonActiveColor,line1NonActiveColor);
			lineRend2.SetColors(line2ActiveColor,line2ActiveColor);
		}
	}

    private void ScaleValues()
    {
        float factor = 500;
        ScaledFrequency1 = frequency1 / factor;
        ScaledFrequency2 = frequency2 / factor;
        ScaledJitter1 = jitter1 / factor;
        ScaledJitter2 = jitter2 / factor;
    }
}

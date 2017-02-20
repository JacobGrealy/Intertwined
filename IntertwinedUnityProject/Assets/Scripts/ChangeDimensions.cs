using UnityEngine;
using System.Collections;

public class ChangeDimensions : MonoBehaviour {

    public GameObject greenBall, purpleBall;
    public bool isLayer1 = false;
    public Color Dim1Color = Color.red;
    public Color Dim2Color = Color.green;
    private const int FIRSTLAYER = 8;
    private const int SECONDLAYER = 9;
    private LineManager lineManager;

	// Use this for initialization
	void Start () {
        lineManager = GameObject.Find("LineManager").GetComponent<LineManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ChangeDimension()
    {
        lineManager.SwitchActiveLine();
        //renderer.material.SetColor("_Color", (isLayer1) ? Dim1Color : Dim2Color);
        this.gameObject.layer = isLayer1 ? FIRSTLAYER : SECONDLAYER;
        ChangeGravity();
        isLayer1 = !isLayer1;
        PlaySound();
        SwitchBall();
    }

    void ChangeGravity()
    {
        ArrayList listOfPoints = new ArrayList(FindObjectsOfType<GameObject>());
        ArrayList stuffToRemove = new ArrayList();
        foreach (GameObject gObject in listOfPoints)
        {
            if (gObject.layer != (isLayer1 ? FIRSTLAYER : SECONDLAYER)
                || gObject == this.gameObject) stuffToRemove.Add(gObject);
        }
        foreach (GameObject gObject in stuffToRemove)
        {
            listOfPoints.Remove(gObject);
        }
        //find closest object
        if (listOfPoints.Count == 0
            || this.gameObject.GetComponent<SimpleGravity>() == null) return;
        GameObject closestObject = (GameObject)listOfPoints[0];
        for (int i = 1; i < listOfPoints.Count; i++ )
        {
            if(Vector3.Distance(this.transform.position, closestObject.transform.position) > 
                Vector3.Distance(this.transform.position, ((GameObject)listOfPoints[i]).transform.position))
            {
                closestObject = (GameObject)listOfPoints[i];
            }
        }
        this.GetComponent<SimpleGravity>().GravityWell = closestObject;
    }

    void PlaySound()
    {
        float vol = .2f;
        string clip = isLayer1 ? "Sounds/Boop-Low" : "Sounds/Boop-High";
        AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>(clip), Camera.main.transform.position, vol);
    }

    void SwitchBall()
    {
        if (greenBall.active == true)
        {
            greenBall.SetActive(false);
            purpleBall.SetActive(true);
        }
        else
        {
            greenBall.SetActive(true);
            purpleBall.SetActive(false);
        }
    }
}

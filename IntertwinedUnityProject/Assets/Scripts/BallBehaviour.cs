using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour
{
    public LineManager lineManager;
    public Lines activeLine;

    public EndGUI endGUI;
    public GameplayGUI gameGUI;
	
    private int currentPosition, nextPosition;
    private float timer;
    public float ScoreTimer;
    public float XVelocity, YVelocity;
    public float scale;
	private Lines lastActiveLine;

    public enum Lines
    {
        REDLINE,
        BLUELINE
    }

	//Bool to keep track if the ball is riding a line, false to start
	private bool onLine = false;

    void Start()
    {
        ScoreTimer = 0;
    }

    void Update()
    {
		//set to correct x position
		transform.position = new Vector3 (lineManager.transform.position.x + lineManager.line1.points [lineManager.line1.points.Count / 3].x, transform.position.y, transform.position.z);
		timer += Time.deltaTime;
		ScoreTimer += Time.deltaTime;

		//if the ball wasn't on a line last update, or this is the first update, or the line has changed; then move towards active line
		if(onLine == false || lastActiveLine == null || activeLine != lastActiveLine)
		{
			Debug.Log("move towards active line");
			//Assume they are not on a line, correct if they are
			onLine = false;
			switch (activeLine)
	        {
	            case Lines.REDLINE:
		        {
		            if (transform.position.y > lineManager.line1.points[lineManager.line1.points.Count / 3].y)
		            {
		                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - YVelocity, 0), Time.deltaTime * 100.0f);
						if (transform.position.y < lineManager.line1.points[lineManager.line1.points.Count / 3].y)
		                {
		                    transform.position = new Vector3(transform.position.x, lineManager.line1.points[lineManager.line1.points.Count / 3].y, 0);
							onLine = true;
						}
		            }
		            else
		            {
		                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + YVelocity, 0), Time.deltaTime * 100.0f);
		                if (transform.position.y > lineManager.line1.points[lineManager.line1.points.Count / 3].y)
		                {
		                    transform.position = new Vector3(transform.position.x, lineManager.line1.points[lineManager.line1.points.Count / 3].y, 0);
							onLine = true;    
						}
		            }              
		        }
		        break;
	                
	            case Lines.BLUELINE:
		        {
		            if (transform.position.y > lineManager.line2.points[lineManager.line2.points.Count / 3].y)
		            {
		                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - YVelocity, 0), Time.deltaTime * 100.0f);
		                if (transform.position.y < lineManager.line2.points[lineManager.line2.points.Count / 3].y)
		                {
		                    transform.position = new Vector3(transform.position.x, lineManager.line2.points[lineManager.line2.points.Count / 3].y, 0);
							onLine = true;
		                }
		            }
		            else
		            {
		                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + YVelocity, 0), Time.deltaTime * 100.0f);
		                if (transform.position.y > lineManager.line2.points[lineManager.line2.points.Count / 3].y)
		                {
		                    transform.position = new Vector3(transform.position.x, lineManager.line2.points[lineManager.line2.points.Count / 3].y, 0);
							onLine = true;
						}
		            }
		        }
		    	break;
			}
        }
		//Otherwise we are riding the line, so set y to the actuve lines y
		else
		{
			if (activeLine == Lines.REDLINE) 
			{
				transform.position = new Vector3(transform.position.x, lineManager.line1.points[lineManager.line1.points.Count / 3].y, 0);
			}
			else
			{
				transform.position = new Vector3(transform.position.x, lineManager.line2.points[lineManager.line2.points.Count / 3].y, 0);
			}
		}

        if (!endGUI.enabled)
        {
            UserScore.Instance.score = ScoreTimer;
        }

		//Move the ball in front of everything else
		this.transform.position = new Vector3 (transform.position.x,transform.position.y,transform.position.z-1);
		//Set the last active line to the current line for next update;
		lastActiveLine = activeLine;
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        int good = 0;
        switch (other.tag)
        {
            case "RedObstacle":
                if (activeLine == Lines.BLUELINE)
                {
                    ScoreTimer -= 2;
                   
                    good = 1;
                }
                else if (activeLine == Lines.REDLINE)
                {
                    ScoreTimer += 10;
                    good = 0;
                }
                PlaySound(good);
                break;
            case "BlueObstacle":
                if (activeLine == Lines.REDLINE)
                {
                    ScoreTimer -= 2;
                   
                    good = 1;
                }
                else if (activeLine == Lines.BLUELINE)
                {
                    ScoreTimer += 10;
                   
                    good = 0;
                }
                PlaySound(good);
                break;
            case "Obstacle":
                if (activeLine == Lines.REDLINE )
                {
                    PlaySound(3);
                    GameObject obj = Instantiate(Resources.Load("BlueDie")) as GameObject;
                    obj.transform.position = this.transform.position;
                    Destroy(GameObject.Find("GreenBall"));
                    Destroy(GameObject.Find("PurpleBall"));
                    this.GetComponent<SphereCollider>().enabled = false;
                    WaitForSeconds temp = new WaitForSeconds(1);
                    yield return temp;
                    gameGUI.enabled = false;
                    endGUI.enabled = true;
                }

                if(activeLine == Lines.BLUELINE)
                {
                    PlaySound(3);
                    GameObject obj = Instantiate(Resources.Load("PurpleDie")) as GameObject;
                    obj.transform.position = this.transform.position;
                    Destroy(GameObject.Find("GreenBall"));
                    Destroy(GameObject.Find("PurpleBall"));
                    this.GetComponent<SphereCollider>().enabled = false;
                    WaitForSeconds temp = new WaitForSeconds(1);
                    yield return temp;
                    gameGUI.enabled = false;
                    endGUI.enabled = true;
                }
                break;
            }
    }

    public void Tap()
    {
       
            switch (activeLine)
            {
                case Lines.REDLINE:
                    {
                        activeLine = Lines.BLUELINE;
                    }
                    break;
                case Lines.BLUELINE:
                    {
                        activeLine = Lines.REDLINE;
                    }
                    break;
            }
        
    }

    void PlaySound(int num)
    {
        float vol = .3f;
        string clip;
        switch (num)
        {
            case 0: clip = "Sounds/Pickup";
                break;
            case 1: clip = "Sounds/Pickdown";
                break;
            case 3: clip = "Sounds/PowerDownLouder";
                vol = 10f;
                break;
            default: clip = "Sounds/Pickdown";
                break;
        }

        AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>(clip), Camera.main.transform.position, vol);
    }
}

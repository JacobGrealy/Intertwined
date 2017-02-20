using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : MonoBehaviour
{

    public float xVelocity = 2f;
    public float yVelocity = 0f;
    private float timer;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - xVelocity, transform.position.y + yVelocity, 0), Time.deltaTime * 10.0f);
            timer = 0.0f;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {

            if (other.gameObject.GetComponent<BallBehaviour>().activeLine == BallBehaviour.Lines.BLUELINE
               && this.tag == "BlueObstacle")
            {
                GameObject obj = Instantiate(Resources.Load("PurpleElectricEffect")) as GameObject;
                obj.transform.position = this.transform.position;
                Destroy(this.gameObject);
            }

            if (other.gameObject.GetComponent<BallBehaviour>().activeLine == BallBehaviour.Lines.BLUELINE
                && this.tag == "RedObstacle")
            {

                if (other.transform.position.y < this.transform.position.y)
                {
                    yVelocity = 2f;
                    GameObject obj = Instantiate(Resources.Load("BlueHit")) as GameObject;
                    obj.transform.position = this.transform.position;

                }
                if (other.transform.position.y > this.transform.position.y)
                {
                    yVelocity = -2f;
                    GameObject obj = Instantiate(Resources.Load("BlueHit")) as GameObject;
                    obj.transform.position = this.transform.position;

                }
            }

            if (other.gameObject.GetComponent<BallBehaviour>().activeLine == BallBehaviour.Lines.REDLINE
               && this.tag == "RedObstacle")
            {
                GameObject obj = Instantiate(Resources.Load("BlueElectricEffect")) as GameObject;
                obj.transform.position = this.transform.position;
                Destroy(this.gameObject);
            }

            if (other.gameObject.GetComponent<BallBehaviour>().activeLine == BallBehaviour.Lines.REDLINE
               && this.tag == "BlueObstacle")
            {

                if (other.transform.position.y < this.transform.position.y)
                {
                    yVelocity = 2f;
                    GameObject obj = Instantiate(Resources.Load("PurpleHit")) as GameObject;
                    obj.transform.position = this.transform.position;

                }
                if (other.transform.position.y > this.transform.position.y)
                {
                    yVelocity = -2f;
                    GameObject obj = Instantiate(Resources.Load("PurpleHit")) as GameObject;
                    obj.transform.position = this.transform.position;

                }
            }
        }

    }
}

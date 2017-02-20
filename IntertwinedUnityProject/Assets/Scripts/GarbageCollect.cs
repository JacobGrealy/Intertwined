using UnityEngine;
using System.Collections;

public class GarbageCollect : MonoBehaviour {

    private ArrayList ListOfAllObjects;
    private float TimeUntilCollection = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TimeUntilCollection -= Time.deltaTime;
        if(TimeUntilCollection <= 0)
        {
            CollectGarbage();
            TimeUntilCollection = 1f;
        }
	}

    void CollectGarbage()
    {
        ListOfAllObjects = new ArrayList(FindObjectsOfType<GameObject>());
        ArrayList ObjectsToDelete = new ArrayList();
        GameObject camera = Camera.main.gameObject;
        float ScreenAspactRatio = Screen.width / Screen.height;

        foreach(GameObject g in ListOfAllObjects)
        {
            if(g.transform.position.x <= camera.transform.position.x - camera.GetComponent<Camera>().orthographicSize * ScreenAspactRatio * 1.2f
                && (g.tag == "RedObstacle" || g.tag == "BlueObstacle" || g.tag == "Obstacle"))
            {
                ObjectsToDelete.Add(g);
            }
        }
        for(int i = 0; i < ObjectsToDelete.Count; i++)
        {
            Destroy((GameObject)ObjectsToDelete[i]);
        }
    }
}

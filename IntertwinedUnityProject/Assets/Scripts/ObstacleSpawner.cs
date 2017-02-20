using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject[] InspectorPickUps;
    public int[] InspectorPickUpWeights;
    public GameObject[] InspectorObstacles;
    public int[] InspectorObstaclesWeights;
    public IDictionary<GameObject, int> PickUps;
    public float PickUpSpawnTimeMax;
    public float PickUpSpawnTimeMin;
    public IDictionary<GameObject, int> Obstacles;
    public float ObstacalesTimeMax;
    public float ObstacalesTimeMin;
    public float MaxSpawnHeight;
    public float MinSpawnHeight;
    private float pickupTimer, obstacleTimer;


    private List<string> wieghtedObsetcles;
    private List<string> wieghtedPickUps;
    private float timer;
    private float largeObstacle;
    public float LargeObstacleTimer;

    private float actualPickUpSpawnTime;
    private float actualObstacelSpawnTime;
    private float acualSpawnHeight;


    void Start()
    {
        PickUps = new Dictionary<GameObject, int>();
        Obstacles = new Dictionary<GameObject, int>();
        for (int i = 0; i < InspectorPickUps.Length; i++ )
        {
            PickUps.Add(new KeyValuePair<GameObject, int>(InspectorPickUps[i], InspectorPickUpWeights[i]));
        }
        for (int i = 0; i < InspectorObstacles.Length; i++)
        {
            Obstacles.Add(new KeyValuePair<GameObject, int>(InspectorObstacles[i], InspectorObstaclesWeights[i]));
        }
        wieghtedObsetcles = new List<string>();
        wieghtedPickUps = new List<string>();
        foreach(KeyValuePair<GameObject, int> kv in PickUps)
        {
            int count = 0;
            while(count < kv.Value)
            {
                wieghtedPickUps.Add(kv.Key.name);
                count++;
            }
        }

        foreach (KeyValuePair<GameObject, int> kv in Obstacles)
        {
            int count = 0;
            while (count < kv.Value)
            {
                wieghtedObsetcles.Add(kv.Key.name);
                count++;
            }
        }

        acualSpawnHeight = Random.Range(MinSpawnHeight,MaxSpawnHeight);
        actualObstacelSpawnTime = Random.Range(ObstacalesTimeMin,ObstacalesTimeMax);
        actualPickUpSpawnTime = Random.Range(PickUpSpawnTimeMin, PickUpSpawnTimeMax);
        pickupTimer = 0;
        obstacleTimer = 0;

    }
    void Update()
    {
        pickupTimer += Time.deltaTime;
        obstacleTimer += Time.deltaTime;

        //if enough time passed shoot pick up;
        if(actualPickUpSpawnTime < pickupTimer)
        {
            if (wieghtedPickUps.Count > 0)
            {
                pickupTimer = 0;
                //shoot pick up
                GameObject go = Instantiate(Resources.Load(wieghtedPickUps[Random.Range(0, wieghtedPickUps.Count)])) as GameObject;
                go.transform.position = new Vector3(transform.position.x, acualSpawnHeight, 0);

                //rset pickup spawn time
                actualPickUpSpawnTime = Random.Range(PickUpSpawnTimeMin, PickUpSpawnTimeMax);

                //reset spawnheight
                acualSpawnHeight = Random.Range(MinSpawnHeight, MaxSpawnHeight);
            }
        }
        
        if(actualObstacelSpawnTime < obstacleTimer)
        {
            if (wieghtedObsetcles.Count > 0)
            {
                obstacleTimer = 0;
                //shoot pick up
                GameObject go = Instantiate(Resources.Load(wieghtedObsetcles[Random.Range(0, wieghtedObsetcles.Count)])) as GameObject;

                if (acualSpawnHeight >= -2.0f && acualSpawnHeight <= 2.0f)
                {
                    float randomYPosition = Random.Range(2, 10);
                    int PosNeg = Random.Range(0, 1);


                    if (PosNeg == 0)
                    {

                        go.transform.position = new Vector3(transform.position.x, randomYPosition, 0);

                    }
                    if (PosNeg == 1)
                    {
                        go.transform.position = new Vector3(transform.position.x, -randomYPosition, 0);

                    }
                }
                else
                {
                    go.transform.position = new Vector3(transform.position.x, acualSpawnHeight, 0);
                }
                //rset pickup spawn time
                actualObstacelSpawnTime = Random.Range(ObstacalesTimeMin, ObstacalesTimeMax);

                //reset spawnheight
                acualSpawnHeight = Random.Range(MinSpawnHeight, MaxSpawnHeight);
            }
        }









        //timer += Time.deltaTime;
        //int randomObject = Random.Range(0, 2);
        //largeObstacle += Time.deltaTime;

        //if (timer > 1)
        //{
        //    Random.seed = Time.frameCount;
        //    if (randomObject == 0)
        //    {
        //        GameObject go = Instantiate(Resources.Load("RedObstacle")) as GameObject;
        //        go.transform.position = transform.position;
        //        go.layer = 9;

        //        if (largeObstacle >= LargeObstacleTimer)
        //        {
        //            go.transform.localScale *= 2.0f;

        //            largeObstacle = 0.0f;
        //        }
        //    }
        //    else if (randomObject == 1)
        //    {
        //        GameObject go = Instantiate(Resources.Load("BlueObstacle")) as GameObject;
        //        go.transform.position = transform.position;

        //        go.layer = 8;

        //        if (largeObstacle >= LargeObstacleTimer)
        //        {
        //            go.transform.localScale *= 2.0f;

        //            largeObstacle = 0.0f;
        //        }

        //    }
        //    else
        //    {
        //        GameObject go = Instantiate(Resources.Load("Obstacle")) as GameObject;
        //        go.transform.position = transform.position;
        //        go.layer = 0;

        //        if (largeObstacle >= LargeObstacleTimer)
        //        {
        //            go.transform.localScale *= 2.0f;

        //            largeObstacle = 0.0f;

        //            if (go.transform.position.y <= 0.1 && go.transform.position.y >= -0.1f)
        //            {
        //                int randomY = Random.Range(0, 1);

        //                if (randomY == 0)
        //                {
        //                    go.transform.position += new Vector3(0.0f, 1.0f, 0.0f);


        //                }
        //                if (randomY == 1)
        //                {
        //                    go.transform.position += new Vector3(0.0f, -1.0f, 0.0f);
        //                }
        //            }
        //        }
        //    }
        //    timer = 0;
        }
    
}

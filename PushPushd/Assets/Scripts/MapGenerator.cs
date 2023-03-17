using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] mapObjectPrefab;
    public string dataPath;
    public List<Dictionary<string, object>> data;
    public GameMgr gameMgr;
    void Start()
    {
        LoadMapData(1);

        for (int i=0; i<12; i++) 
        {
            for (int j = 0; j < 12; j++) 
            {
                GameObject ground = Instantiate(mapObjectPrefab[0]) as GameObject;
                ground.name = ground.tag + "(" + j + "," + i + ")";
                ground.transform.parent = GameObject.Find("Ground12x12").transform;
                ground.transform.localPosition = new Vector3(j, 0, -i);
            }
        }
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        MakeMap();
    }
    public void LoadMapData(int stageNum) 
    {
        dataPath = "MapData/" + "LV" + stageNum; // MapData/LV1
        data = CSVReader.Read(dataPath);
    }
    void MakeMap() 
    {
        for(int i=0; i<12; i++) 
        {
            for (int j = 0; j < 12; j++) 
            {
                int dataSet = (int)data[i][j.ToString()];

                if(dataSet!=0) 
                {
                    GameObject mapObj = Instantiate(mapObjectPrefab[dataSet]);

                    switch(mapObj.tag) 
                    {
                        case "Wall":
                            mapObj.name = mapObj.tag + "(" + j + ", " + i + ")";
                            mapObj.transform.parent = GameObject.Find("Map12x12").transform;
                            mapObj.transform.localPosition= new Vector3(j, 0, -i);
                            break;
                        case "Bucket":
                            mapObj.name = mapObj.tag + "(" + j + ", " + i + ")";
                            mapObj.transform.parent = GameObject.Find("Map12x12").transform;
                            mapObj.transform.localPosition = new Vector3(j, 0, -i);

                            break;
                        case "Ball":
                            mapObj.name = mapObj.tag + "(" + j + ", " + i + ")";
                            mapObj.transform.parent = GameObject.Find("Map12x12").transform;
                            mapObj.transform.localPosition = new Vector3(j, 0, -i);

                            break;
                        case "Player":
                            mapObj.name = mapObj.tag + "(" + j + ", " + i + ")";
                            mapObj.transform.parent = GameObject.Find("Map12x12").transform;
                            mapObj.transform.localPosition = new Vector3(j, 0, -i);

                            break;
                            default: break;
                    }
                }
            }
        }

        gameMgr.SetBucketsAndBalls();
    }

    public void MapDestroy(int lv) 
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] buckets = GameObject.FindGameObjectsWithTag("bucket");
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < walls.Length; i++)
        {
            Destroy(walls[i]);
        }
        for (int i = 0; i < buckets.Length; i++)
        {
            Destroy(buckets[i]);
        }
        for (int i = 0; i < balls.Length; i++)
        {
            Destroy(balls[i]);
        }
        
            Destroy(player);
        LoadMapData(lv);
        MakeMap();
        
    }
}
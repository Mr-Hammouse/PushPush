using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    RaycastHit hit2;

    public GameMgr gameMgr;
    public Transform tr;

    void Start()
    {
        gameMgr=GameObject.Find("GameMgr").GetComponent<GameMgr>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CheckOthers(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CheckOthers(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CheckOthers(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CheckOthers(Vector3.back);
        }
    }

    public void CheckOthers(Vector3 dir) 
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(dir), out hit, 1f))
        {
            Transform tr = hit.collider.transform;
            //Debug.Log(tr.gameObject.tag);
            switch (hit.collider.tag)
            {
                case "Ball":
                    Debug.Log("Ball!!!!!!");
                    if (Physics.Raycast(tr.position, tr.TransformDirection(dir), out hit2, 1f)) 
                    {
                        switch(hit2.collider.tag) 
                        {
                            case "Bucket":
                                break;
                            case "Ball":
                                break;
                            case "Wall":
                                break;
                        }
                    }
                    break;
                case "Wall":
                    Debug.Log("벽이니까 아무것도 하지마!!!!!!");
                    break;
                default:
                    break;
            }
        }
        else transform.Translate(dir);
        tr.Translate(dir);
        gameMgr.CheckBallPosition();
    }
}
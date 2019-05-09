using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BallManager : NetworkBehaviour
{
    public GameObject prefabBall;
    bool ballComing;
    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isServer || ballComing)
        {
            return;
        }
        if(NetworkServer.connections.Count == 2)
        {
            ball = (GameObject)Instantiate(prefabBall);
            NetworkServer.Spawn(ball);
            ballComing = true;
        }
    }
}

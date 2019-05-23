using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkTransform))]
[RequireComponent(typeof(Rigidbody))]
public class PaddleController : NetworkBehaviour {

    public float batasAtas;
    public float batasBawah;

    public float kecepatan;
    public string axis;
    void Awake()
    {
        //register the spaceship in the gamemanager, that will allow to loop on it.
        NetworkGameManager.aShip.Add(this);
        if (transform.position.x > 0)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        float gerak = GetInputPC();

        float nextPos = transform.position.y + gerak;
        if (nextPos > batasAtas)
        {
            gerak = 0;
        }
        if (nextPos < batasBawah)
        {
            gerak = 0;
        }

        transform.Translate(0, gerak, 0);

        
    }

    float GetInputPC()
    {
        return Input.GetAxis(axis) * kecepatan * Time.deltaTime;
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ControllerPlayer : MonoBehaviour {

    private Player player;


    void Awake()
    {
        player = ReInput.players.GetPlayer(0);
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (player.GetButtonDown("Yo"))
        {
            Debug.Log(player);
        }

    }
}

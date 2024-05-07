using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class AIAgent : Agent
{
    public Rigidbody2D playerRb;
    public GameManager manager;
    private TapController playerInput;

    public bool getScore = false;
    public bool dead = false;
    
    public override void Initialize()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<TapController>();
        manager = GameObject.Find("Main Camera").GetComponent<GameManager>();
    }

    public override void OnEpisodeBegin()
    {
        dead = false;
        manager.StartGame();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position.x);
        sensor.AddObservation(transform.position.y);
        sensor.AddObservation(playerRb.velocity.y);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        var jump = actionBuffers.DiscreteActions[0];

        switch (jump)
        {
            case 0:
                playerInput.pressedJump = true;
                SetReward(-0.05f);
                break;
            case 1:
                break;
        }

        if(getScore) 
        {
            SetReward(3.0f);
            getScore = false;
        }
        
        if(!dead) SetReward(0.5f);
        else
        {
            manager.ConfirmedGameOver();
            SetReward(-10.0f); 
            EndEpisode();
        }
        
    }
    
}

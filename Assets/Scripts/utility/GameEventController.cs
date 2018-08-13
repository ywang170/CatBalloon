using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventController : MonoBehaviour {

    public Dictionary<
        GameEvent.GameEventType, 
        List<GameEventReceiver>
        > 
        EventReceiverMap { get; set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BindWithEvent(
        GameEventReceiver receiver, 
        GameEvent.GameEventType gameEventType)
    {
        List<GameEventReceiver> currentReceivers = 
            EventReceiverMap[gameEventType];
        if (!currentReceivers.Contains(receiver))
        {
            currentReceivers.Add(receiver);
        }
    }

    public void SendEvent(GameEvent gameEvent)
    {
        GameEvent.GameEventType gameEventType =
            gameEvent.EventType;
        List<GameEventReceiver> currentReceivers = 
            EventReceiverMap[gameEventType];
        foreach (GameEventReceiver receiver in currentReceivers)
        {
            receiver.ReactToEvent(gameEvent);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Play

    System.Action _startBeginCallback = null;
    System.Action _preMidCallback = null;
    System.Action _afterMidCallback = null;
    System.Action _endCallback = null;

    public void Play(string triggerName, System.Action startBeginCallback, System.Action preMidCallback, System.Action afterMidCallback, System.Action endCallback)
    {
        gameObject.GetComponent<Animator>().SetTrigger(triggerName);
        _startBeginCallback = startBeginCallback;
        _preMidCallback = preMidCallback;
        _afterMidCallback = afterMidCallback;
        _endCallback = endCallback;
    }

    //Animation Event
    public void OnBeginEvent()
    {
        if (_startBeginCallback != null)
            _startBeginCallback();
    }

    public void OnPreMidEvent()
    {
        if (_preMidCallback != null)
            _preMidCallback();
    }

    public void OnAfterMidEvent()
    {
        if (_afterMidCallback != null)
            _afterMidCallback();
    }

    public void OnEndEvent()
    {
        if (_endCallback != null)
            _endCallback();
    }
}

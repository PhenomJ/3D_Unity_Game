using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	// Use this for initialization
	void Start () {
        _destination = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.Instance.IsMouseDown())
        {
            Vector3 mousePosition = InputManager.Instance.GetCursorPosition();

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("Ground")))
            {
                MoveStart(hit.point);
            }
        }

        UpdateMove();
	}

    // Character Move
    Vector3 _destination;

    void MoveStart(Vector3 destination)
    {
        //목적지 셋팅
        _destination = destination;
    }

    Vector3 _velocity = Vector3.zero;

    void UpdateMove()
    {
        Vector3 snapGround = Vector3.zero;
        Vector3 direction = (_destination - transform.position).normalized;

        _velocity = direction *  18.0f;

        if (gameObject.GetComponent<CharacterController>().isGrounded)
            snapGround = Vector3.down;

        //목적지가 현재 위치가 일정 거리 이상이면 -> 이동
        float distance = Vector3.Distance(_destination, transform.position);
        
        if (distance > 0.5f)
        {
            gameObject.GetComponent<CharacterController>().Move(_velocity * Time.deltaTime + snapGround);
        }
        //목적기 까지의 거리와 방향을 구한다.

        //현재 속도를 보관

        //목적지에 가까이 왔으면 도착
    }
}

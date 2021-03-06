﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacter();
    }

    virtual public void UpdateCharacter()
    {
        UpdateChangeState();
        if (_stateList.ContainsKey(_stateType))
            _stateList[_stateType].Update();

        else
            Debug.LogWarning(_stateType);
    }

    //State
    public enum eState
    {
        NONE,
        IDLE,
        MOVE,
        ATTACK,
        CHASE,
        MONSTERIDLE,
        PATROL,
    }

    protected eState _stateType = eState.IDLE;
    eState _nextStateType = eState.IDLE;
    protected Dictionary<eState, State> _stateList = new Dictionary<eState, State>();

    void UpdateChangeState()
    {
        if (_nextStateType != _stateType)
        {
            _stateList[_stateType].Stop();
            _stateType = _nextStateType;
            _stateList[_stateType].Start();
        }
    }

    public void ChangeState(eState state)
    {
        _nextStateType = state;
    }

    virtual protected void InitState()
    {
        State idleState = new IdleState();
        State moveState = new MoveState();
        State attackState = new AttackState();
        State chaseState = new ChaseState();
        

        idleState.Init(this);
        moveState.Init(this);
        attackState.Init(this);
        chaseState.Init(this);

        _stateList.Add(eState.IDLE, idleState);
        _stateList.Add(eState.MOVE, moveState);
        _stateList.Add(eState.ATTACK, attackState);
        _stateList.Add(eState.CHASE, chaseState);
    }

    //Move
    protected Vector3 _targetPosition = Vector3.zero;
    protected GameObject _targetObj;

    public Vector3 GetTargetPosition()
    {
        return _targetPosition;
    }

    public GameObject GetTargetObj()
    {
        return _targetObj;
    }

    virtual public void ArriveDestination()
    {
        ChangeState(eState.IDLE);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public bool isGround()
    {
        return gameObject.GetComponent<CharacterController>().isGrounded;
    }

    public void Move(Vector3 velocity)
    {
        gameObject.GetComponent<CharacterController>().Move(velocity);
    }

    public void Rotate(Vector3 direction)
    {
        Quaternion characterTargetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, characterTargetRotation, 300.0f * Time.deltaTime);
    }

    // Animation

    public GameObject characterVisual;

    public void SetAnimationTrigger(string triggerName)
    {
        characterVisual.GetComponent<Animator>().SetTrigger(triggerName);
    }

    public Quaternion GetRotation()
    {
        return transform.rotation;
    }

    public AnimationPlayer GetAnimationPlayer()
    {
        return characterVisual.GetComponent<AnimationPlayer>();
    }

    //Attack
    AttackArea[] _attackAreas;

    void InitAttackInfo()
    {
        _attackAreas = GetComponentsInChildren<AttackArea>();
    }
    public void AttackStart()
    {
        for (int i = 0; i < _attackAreas.Length; i++)
            _attackAreas[i].Enable();
    }

    public void AttackEnd()
    {
        for (int i = 0; i < _attackAreas.Length; i++)
            _attackAreas[i].Disable();
    }

    public float GetAttackRange()
    {
        return 1.5f;
    }

    public enum eCharacterType
    {
        MONSTER,
        PLAYER,
        NONE,
    }

    protected eCharacterType _type = eCharacterType.NONE;

    public eCharacterType GetCharacterType()
    {
        return _type;
    }

    virtual public void Init()
    {
        InitState();
        InitAttackInfo();
        InitDamageInfo();
    }

    void InitDamageInfo()
    {
        HitArea[] hitArea = GetComponentsInChildren<HitArea>();

        for (int i = 0; i < hitArea.Length; i++)
        {
            hitArea[i].Init(this);
        }
    }

    public float GetRefreshTime()
    {
        return 2.0f;
    }

    public float GetMaxSearchRange()
    {
        return 5.0f;
    }

    public void Patrol()
    {
        ChangeState(eState.PATROL);
    }

    protected bool _isSetPosition = false;

    public bool IsSetPosition()
    {
        return _isSetPosition;
    }

    public void SetMovePosition(bool isSetPosition)
    {
        _isSetPosition = isSetPosition;
    }

    public void SetTargetObj (GameObject targetObj)
    {
        _targetObj = targetObj;
    }

    virtual public void StopChase()
    {

    }

    virtual public bool IsSearchRange(float distance)
    {
        return false;
    }
}

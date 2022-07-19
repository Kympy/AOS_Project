using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected float HP; // 현재 체력
    public float _hp { get { return HP; } }

    protected float MaxHP; // 최대 체력
    public float _maxHp { get { return MaxHP; } }

    protected float MP; // 현재 마나
    public float _mp { get { return MP; } }

    protected float MaxMP; // 최대 마나
    public float _maxMp { get { return MaxMP; } }

    protected float Speed; // 이동 속도
    public float _speed { get { return Speed; } }

    protected Vector3 PlayerPos; // 현재 위치 좌표
    public Vector3 _playerPos { get { return PlayerPos; } }

    protected float NormalDamage; // 평타 공격력
    public float _normalDamage { get { return NormalDamage; } }

    public abstract void InitPlayer();
    public abstract void OnKeyBoard();
    public abstract void Attack();
    public abstract void MoveByClick();
    public abstract void Movement();

    public void SetHP(int damage)
    {
        HP += damage;
    }
    public void SetSpeed(int speed)
    {
        Speed = speed;
    }
    public void SetPlayerPos(Vector3 position)
    {
        PlayerPos = position;
    }
    public void SetNormalDamage(int damage)
    {
        NormalDamage = damage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected float HP;
    public float _hp { get { return HP; } }

    protected float Speed;
    public float _speed { get { return Speed; } }
    protected Vector3 PlayerPos;
    public Vector3 _playerPos { get { return PlayerPos; } }

    protected float NormalDamage;
    public float _normalDamage { get { return NormalDamage; } }

    public abstract void InitPlayer();
    public abstract void OnKeyBoard();
    public abstract void Attack();

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

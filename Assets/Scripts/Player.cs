using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected float HP; // ���� ü��
    public float _hp { get { return HP; } }

    protected float MaxHP; // �ִ� ü��
    public float _maxHp { get { return MaxHP; } }

    protected float MP; // ���� ����
    public float _mp { get { return MP; } }

    protected float MaxMP; // �ִ� ����
    public float _maxMp { get { return MaxMP; } }

    protected float Speed; // �̵� �ӵ�
    public float _speed { get { return Speed; } }

    protected Vector3 PlayerPos; // ���� ��ġ ��ǥ
    public Vector3 _playerPos { get { return PlayerPos; } }

    protected float NormalDamage; // ��Ÿ ���ݷ�
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

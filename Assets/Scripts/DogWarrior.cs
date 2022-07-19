using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DogWarrior : Player
{
    private Vector3 desiredPos;
    private Vector3 desiredDir;
    //private Rigidbody rigidBody;
    private Ray mouseRay;
    private RaycastHit hit;
    public GameObject click;

    private void Awake()
    {
        InitPlayer();
    }
    private void Start()
    {
        InputManager.Instance.KeyAction -= OnKeyBoard;
        InputManager.Instance.KeyAction += OnKeyBoard;
        desiredPos = transform.position;
    }
    public override void InitPlayer()
    {
        HP = 550f;
        MaxHP = HP;
        MP = 200f;
        MaxMP = MP;
        Speed = 3f;
        NormalDamage = 5f;
        //rigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        PlayerPos = transform.position;
    }
    public override void OnKeyBoard()
    {
        if (Input.GetMouseButton(1))
        {
            MoveByClick();
        }
        Movement();
    }
    public override void Attack()
    {

    }

    public override void MoveByClick()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out hit))
        {
            desiredPos = hit.point;
            desiredPos.y = transform.position.y;
            desiredDir = desiredPos - transform.position;
            if (Input.GetMouseButtonDown(1)) Instantiate(click, hit.point, transform.rotation);
        }
    }
    public override void Movement()
    {
        if (transform.position != desiredPos) // 이동
        {
            transform.position = Vector3.MoveTowards(transform.position, desiredPos, Speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredDir), Time.deltaTime * 8f);
            AnimationManager.Instance.playerAnim.SetBool("IsMove", true);
        }
        else
        {
            AnimationManager.Instance.playerAnim.SetBool("IsMove", false);
        }
    }
}
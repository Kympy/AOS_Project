using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DogWarrior : Player
{
    private Vector3 desiredPos;
    private Vector3 desiredDir;
    private Rigidbody rigidBody;
    private Ray mouseRay;
    private RaycastHit hit;

    public GameObject Info;
    public GameObject Bar;
    public GameObject click;
    private void Awake()
    {
        InitPlayer();
    }
    private void Start()
    {
        InputManager.Instance.KeyAction -= OnKeyBoard;
        InputManager.Instance.KeyAction += OnKeyBoard;
    }
    public override void InitPlayer()
    {
        HP = 550f;
        Speed = 3f;
        NormalDamage = 5f;
        rigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Info.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0f, 90f, 0f);
        Bar.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0f, 70f, 0f);
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

    public void MoveByClick()
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
    public void Movement()
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Player CurrentPlayer; // �÷��̾�
    private Vector3 originalPos = new Vector3(3f, 10f, -3f); // �⺻ ī�޶� ��ġ
    private Quaternion originalRot = new Quaternion(0.50999f, -0.31910f, 0.21125f, 0.77036f); // �⺻ ī�޶� ����
    private bool fixedMode = true; // ī�޶� ���� ���
    private Vector3 mousePos; // ���콺 ��ġ
    private float sensitivity = 5f; // ī�޶� �ΰ���
    private Transform viewDirection; // ī�޶��� ȸ������ �ݿ��� forward ��ǥ
    
    private void Update()
    {

    }
    public void InitGameCamera() // ���� ī�޶� �ʱ�ȭ
    {
        InputManager.Instance.KeyAction -= MyKey; // Ű �Է� �ʱ�ȭ
        InputManager.Instance.KeyAction += MyKey;
        CurrentPlayer = GameManager.Instance.CurrentPlayer.GetComponent<Player>(); // �÷��̾� ã��
        viewDirection = GameObject.Find("ViewDirection").transform; // ī�޶� ���� ��ġ�� ���� ������Ʈ
    }
    private void MyKey() // ī�޶��� Ű �Է¿� ���� ������
    {
        if(Input.GetKeyDown(KeyCode.Y)) // ī�޶� ���� ����
        {
            fixedMode = !fixedMode;
        }
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition); // ī�޶� ������ ���� ���콺 ��ǥ
    }
    public void CameraView(bool start) // ���� �� ī�޶� ��
    {
        if (start)
        {
            if (fixedMode) // ī�޶� ���� �����
            {
                transform.position = CurrentPlayer.transform.position + originalPos; // ī�޶� ��ġ�� �÷��̾� + �⺻ ��ġ
                transform.LookAt(CurrentPlayer.gameObject.transform); // ī�޶�� �÷��̾ �ٶ�
            }
            else // ī�޶� ���� �����
            {
                if (mousePos.x >= 0.9) // ȭ�� ����
                {
                    transform.position += transform.right * sensitivity * Time.deltaTime;
                }
                if (mousePos.x <= 0.1) // ȭ�� ����
                {
                    transform.position -= transform.right * sensitivity * Time.deltaTime;
                }
                if (mousePos.y >= 0.9) // ȭ�� ���
                {
                    transform.position += viewDirection.forward * sensitivity * Time.deltaTime;
                }
                if (mousePos.y <= 0.1) // ȭ�� �ϴ�
                {
                    transform.position -= viewDirection.forward * sensitivity * Time.deltaTime;
                }
                transform.rotation = originalRot; // ������ ���� ����
            }
        }
    }
}

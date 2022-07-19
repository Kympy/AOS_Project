using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Player CurrentPlayer; // 플레이어
    private Vector3 originalPos = new Vector3(3f, 10f, -3f); // 기본 카메라 위치
    private Quaternion originalRot = new Quaternion(0.50999f, -0.31910f, 0.21125f, 0.77036f); // 기본 카메라 각도
    private bool fixedMode = true; // 카메라 고정 모드
    private Vector3 mousePos; // 마우스 위치
    private float sensitivity = 5f; // 카메라 민감도
    private Transform viewDirection; // 카메라의 회전값이 반영된 forward 좌표
    
    private void Update()
    {

    }
    public void InitGameCamera() // 게임 카메라 초기화
    {
        InputManager.Instance.KeyAction -= MyKey; // 키 입력 초기화
        InputManager.Instance.KeyAction += MyKey;
        CurrentPlayer = GameManager.Instance.CurrentPlayer.GetComponent<Player>(); // 플레이어 찾기
        viewDirection = GameObject.Find("ViewDirection").transform; // 카메라 절대 위치를 위한 오브젝트
    }
    private void MyKey() // 카메라의 키 입력에 따른 선택지
    {
        if(Input.GetKeyDown(KeyCode.Y)) // 카메라 고정 해제
        {
            fixedMode = !fixedMode;
        }
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition); // 카메라 조정을 위한 마우스 좌표
    }
    public void CameraView(bool start) // 게임 시 카메라 뷰
    {
        if (start)
        {
            if (fixedMode) // 카메라 고정 모드라면
            {
                transform.position = CurrentPlayer.transform.position + originalPos; // 카메라 위치는 플레이어 + 기본 위치
                transform.LookAt(CurrentPlayer.gameObject.transform); // 카메라는 플레이어를 바라봄
            }
            else // 카메라 자유 모드라면
            {
                if (mousePos.x >= 0.9) // 화면 우측
                {
                    transform.position += transform.right * sensitivity * Time.deltaTime;
                }
                if (mousePos.x <= 0.1) // 화면 좌측
                {
                    transform.position -= transform.right * sensitivity * Time.deltaTime;
                }
                if (mousePos.y >= 0.9) // 화면 상단
                {
                    transform.position += viewDirection.forward * sensitivity * Time.deltaTime;
                }
                if (mousePos.y <= 0.1) // 화면 하단
                {
                    transform.position -= viewDirection.forward * sensitivity * Time.deltaTime;
                }
                transform.rotation = originalRot; // 일정한 각도 유지
            }
        }
    }
}

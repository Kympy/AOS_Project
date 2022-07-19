using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    private GameObject selectedPlayer; // 플레이 시작 시 선택된 플레이어 오브젝트

    protected Player currentPlayer; // 현재 플레이어 스크립트
    public Player CurrentPlayer { get { return currentPlayer; } }

    protected CameraControl gameCamera; // 메인 카메라
    public CameraControl GameCamera { get { return gameCamera; } }

    public Vector3 startPosition = new Vector3(0f, 0f, 10f); // 플레이어 시작 위치
    private void Awake()
    {
        InitGameManager(); // 게임 매니저 초기화 : 생성 시 가장 먼저 초기화가 필요하지만 당장 쓰진 않는 것들
        InitPlayer(); // 플레이어 선택 및 생성
        UIManager.Instance.InitPlayerInfo(); // UI : 플레이어 이름 체력 초기화
        gameCamera.InitGameCamera(); // 게임 씬 카메라의 초기화 (플레이어 찾기)
    }
    private void Update()
    {
        InputManager.Instance.KeyInput(); // 키 입력 받기
        UIManager.Instance.DisplayPlayerInfo(); // UI : 플레이어 이름 체력 머리위에 표시
        gameCamera.CameraView(true); // 카메라 작동 시작
    }
    private void InitGameManager() // 게임 매니저 초기화 : 생성 시 가장 먼저 초기화가 필요하지만 당장 쓰진 않는 것들
    {
        gameCamera = Camera.main.GetComponent<CameraControl>(); // 메인카메라 스크립트 가져오기
    }
    public void InitPlayer()
    {
        selectedPlayer = Resources.Load("Characters/DogWarrior") as GameObject; // 선택한 플레이어 가져오기
        currentPlayer = Instantiate(selectedPlayer, startPosition, selectedPlayer.transform.rotation).GetComponent<Player>(); // 선택한 플레이어 생성
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingleTon<UIManager>
{
    private GameObject playerInfo; // 플레이어 이름 체력 정보 
    private TextMeshProUGUI playerName; // 플레이어 이름
    private Image playerHP; // 플레이어 체력
    private Image playerMP; // 플레이어 마나

    private Vector3 playerPos; // 플레이어 위치
    private Vector3 playerInfoPos = new Vector3(0f, 100f, 0f); // 정보 표시 위치

    public void InitPlayerInfo()
    {
        playerPos = GameManager.Instance.CurrentPlayer.transform.position; // 플레이어 위치 가져오기
        playerInfo = GameObject.FindGameObjectWithTag("PlayerInfo"); // 플레이어 정보 그룹
        playerName = playerInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>(); // 캔버스로부터 이름
        playerHP = playerInfo.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>(); // 캔버스로부터 체력
        playerMP = playerInfo.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>(); // 캔버스로부터 마나
    }
    public void DisplayPlayerInfo() // 플레이어 이름 체력 표시
    {
        playerPos = GameManager.Instance.CurrentPlayer._playerPos; // 플레이어 위치 가져오기
        playerInfo.gameObject.transform.position = Camera.main.WorldToScreenPoint(playerPos) + playerInfoPos; // 정보 UI 의 위치 지정
        playerHP.fillAmount = GameManager.Instance.CurrentPlayer._hp / GameManager.Instance.CurrentPlayer._maxHp; // 현재 체력 비율 표시
        playerMP.fillAmount = GameManager.Instance.CurrentPlayer._mp / GameManager.Instance.CurrentPlayer._maxMp; // 현재 마나 비율 표시
    }
}

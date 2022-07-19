using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingleTon<UIManager>
{
    private GameObject playerInfo; // �÷��̾� �̸� ü�� ���� 
    private TextMeshProUGUI playerName; // �÷��̾� �̸�
    private Image playerHP; // �÷��̾� ü��
    private Image playerMP; // �÷��̾� ����

    private Vector3 playerPos; // �÷��̾� ��ġ
    private Vector3 playerInfoPos = new Vector3(0f, 100f, 0f); // ���� ǥ�� ��ġ

    public void InitPlayerInfo()
    {
        playerPos = GameManager.Instance.CurrentPlayer.transform.position; // �÷��̾� ��ġ ��������
        playerInfo = GameObject.FindGameObjectWithTag("PlayerInfo"); // �÷��̾� ���� �׷�
        playerName = playerInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>(); // ĵ�����κ��� �̸�
        playerHP = playerInfo.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>(); // ĵ�����κ��� ü��
        playerMP = playerInfo.transform.GetChild(1).transform.GetChild(1).GetComponent<Image>(); // ĵ�����κ��� ����
    }
    public void DisplayPlayerInfo() // �÷��̾� �̸� ü�� ǥ��
    {
        playerPos = GameManager.Instance.CurrentPlayer._playerPos; // �÷��̾� ��ġ ��������
        playerInfo.gameObject.transform.position = Camera.main.WorldToScreenPoint(playerPos) + playerInfoPos; // ���� UI �� ��ġ ����
        playerHP.fillAmount = GameManager.Instance.CurrentPlayer._hp / GameManager.Instance.CurrentPlayer._maxHp; // ���� ü�� ���� ǥ��
        playerMP.fillAmount = GameManager.Instance.CurrentPlayer._mp / GameManager.Instance.CurrentPlayer._maxMp; // ���� ���� ���� ǥ��
    }
}

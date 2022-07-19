using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour  where T : class, new()
{
    private static volatile T _instance;
    private static object obj = new object();

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType(typeof(T)) as T;
                lock (obj)
                {
                    if (_instance == null)
                    {
                        //GameObject obj = new GameObject(typeof(T).ToString(), typeof(T)); // T Ÿ������ ������Ʈ �����ϰ�
                        //_instance = obj.GetComponent<T>(); // T�� ��������
                        //DontDestroyOnLoad(obj); // ���� ����
                        _instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
                        if (_instance == null)
                        {
                            Debug.Log("### Instance is NULL!!!");
                        }
                    }

                }
            }
            return _instance;
        }
    }
}

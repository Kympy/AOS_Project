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
                        //GameObject obj = new GameObject(typeof(T).ToString(), typeof(T)); // T 타입으로 오브젝트 생성하고
                        //_instance = obj.GetComponent<T>(); // T를 가져오고
                        //DontDestroyOnLoad(obj); // 삭제 방지
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

using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour
{

    float Z_Speed = -0.3f;
    float intervalTime;
    // Use this for initialization
    void Start()
    {
        intervalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, 0, 1 * Z_Speed);

        Quaternion quat = Quaternion.Euler(0, 180, 0);

        intervalTime += Time.deltaTime;
        if (intervalTime >= 0.3f)
        {
            intervalTime = 0.0f;
        }

    }

    void OnCollisionEnter(Collision c)
    {
        // 衝突したオブジェクトの名前がenemyだったとき.
        // 取得の仕方は他にもタグで取得する方法もあるよ!
        if (c.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            //それ以外の処理
        }
    }
}
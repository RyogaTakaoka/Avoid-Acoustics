using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

    private float speed;
    private float rotspeed;
    private Transform pos;

    GameManager gameScript;
    private float startTime;
    [SerializeField] private string objectName;

    private void Start()
    {
        gameScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        rotspeed = 3.0f;
        pos = transform;
        startTime = Time.time;
        //Vector3 angle = Quaternion.ToEulerAngles(transform.rotation);

        switch (objectName)
        {
            case "Bird":
                transform.Rotate(-90, 0, 0);
                break;
            case "Satelite":
                transform.Rotate(-90, 0, 0);
                break;
            default:
                break;
        }

        //transform.rotation = Quaternion.EulerAngles(angle);



        speed = 20f / gameScript.time;
    }

    void FixedUpdate()
    {
        float sokudo = -speed * Time.fixedDeltaTime;
        //Debug.Log(sokudo);

        //pos.Translate(0, 0,sokudo);
        switch (objectName)
        {
            case "Bird":
                pos.Translate(0, -sokudo, 0);
                break;
            case "Rock":
                pos.Rotate(0, 0, rotspeed);
                pos.Translate(0, 0, sokudo);
                break;
            case "Satelite":
                pos.Rotate(0, rotspeed, 0);
                pos.Translate(0, -sokudo, 0);
                break;
            default:
                pos.Translate(0, 0, sokudo);
                break;
        }


    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Wall")
        {
            GameObject.Find("Canvas/ComboText").GetComponent<ComboText>().AddPoint(1);
            Destroy(gameObject);
        }
        if (c.gameObject.tag == "player")
        {
            int combocount = ComboText.combo;
            combocount = 0;
            FindObjectOfType<ComboText>().Initialize();
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MeshRenderer))]
public class BackgroundController : MonoBehaviour
{

    public float ScrollSpeed = 0.05f;
    private MeshRenderer mr;

    float offset = 0f;

    // Use this for initialization
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetSceneByName("OnPause").isLoaded == false)
        {
          offset = Mathf.Repeat(Time.time * ScrollSpeed, 1f);
          mr.material.SetTextureOffset("_MainTex", new Vector2(0f, offset));
        }
            
    }
}
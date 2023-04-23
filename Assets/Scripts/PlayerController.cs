using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    float X_Speed = -1;
    float Z_Speed = 1;

    public AudioClip audioClip1;
    private AudioSource audioSource;

    bool canmove = true;
    bool loading = false;
    bool coli = true;
    bool no = true;

    public GameObject[] LifeLabel;
    public int destroyCount = 0;

    public float interval = 0.25f;   // 点滅周期

    //IEnumerator Pause()
    //{
    //    canmove = false;
    //    if (loading)
    //    {
    //        yield return new WaitForSeconds(2.5f);
    //    }
    //    while (SceneManager.GetSceneByName("OnPause").isLoaded == true)
    //    {
    //        yield return null;
    //    }
    //    canmove = true;
    //    loading = false;
    //}


    // Use this for initialization
    void Start()
    {
    }

    private Vector3 pos;
    private bool isDamage;

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.P) && SceneManager.GetSceneByName("OnPause").isLoaded == false)
        //{
        //    //loading = true;
        //    SceneManager.LoadScene("OnPause", LoadSceneMode.Additive);
        //    //StartCoroutine("Pause");
        //    //Time.timeScale = 0;
        //}

        if (canmove)
        {
            float vertical = Input.GetAxis("Vertical");

            float horizontal = Input.GetAxis("Horizontal");

            if (Input.GetKey("up"))
            {
                transform.Translate(0, 0, vertical * Z_Speed);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(0, 0, 1.0f);
            }
            if (Input.GetKey("down"))
            {
                transform.Translate(0, 0, vertical * Z_Speed);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, -1.0f);
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                transform.Translate(0, 0, -1.0f);
            }
            if (Input.GetKey("left"))
            {
                transform.Translate(horizontal * X_Speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(horizontal * X_Speed, 0, 0);
            }
            if (Input.GetKey("right"))
            {
                transform.Translate(horizontal * X_Speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(horizontal * X_Speed, 0, 0);
            }

            Clamp();

        }
    }

    // プレーヤーの移動できる範囲を制限する命令ブロック
    void Clamp()
    {

        // プレーヤーの位置情報を「pos」という箱の中に入れる。
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -5.5f, 5.5f);
        pos.y = Mathf.Clamp(pos.y, -1, 0);

        transform.position = pos;
    }

    IEnumerator invincibleTime(float time)
    {
        //Debug.Log("wai");
        coli = false;
        isDamage = true;
        no = false;
        yield return new WaitForSeconds(4f);      // 処理を待機.
        coli = true;
        isDamage = false;
        no = true;
        //Debug.Log("真姫");
    }

    IEnumerator Blink()
    {
        while (true)
        {
            if (!isDamage) yield break;
            Renderer r = gameObject.GetComponent<Renderer>();
            r.enabled = !r.enabled;
            yield return new WaitForSeconds(interval);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("万歳！");
        UpdatePlayerIcons();
        if (no)
        {
            StartCoroutine(invincibleTime(0.5f));
            StartCoroutine(Blink());
        }

        else
        {
            //それ以外の処理
        }
    }

    void UpdatePlayerIcons()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        if (coli)
        {
            //Debug.Log("千沙");
            destroyCount++;
            for (int i = 0; i < LifeLabel.Length; i++)
            {
                audioSource.Play();
                if (destroyCount <= i)
                    LifeLabel[i].SetActive(true);
                else
                    LifeLabel[i].SetActive(false);
            }

            //if (SceneManager.GetSceneByName("OnSky").isLoaded && destroyCount == 5)
            //{
            //    SceneManager.LoadScene("OnGameOver");
            //}

            if (SceneManager.GetSceneByName("OnSpace").isLoaded && destroyCount == 6)
            {
                SceneManager.LoadScene("OnGameOver");
            }

            if( !SceneManager.GetSceneByName("OnSpace").isLoaded && destroyCount == 3)
            {
                SceneManager.LoadScene("OnGameOver");
            }
        }

    }
}
using UnityEngine;

public class LaserController: MonoBehaviour
{
    public GameObject LaserPrefab;
    // Use this for initialization
    void Start()
    {
        Invoke("Laser3", 20);
        Invoke("Laser1", 50.5f);
        Invoke("Laser5", 50.5f);
        Invoke("Laser2", 77);
        Invoke("Laser4", 77);
    }
    
    void Laser1()
    {
        Instantiate(LaserPrefab, new Vector3(-4.8f, -0.5f, 5), transform.rotation);
    }
    void Laser2()
    {
        Instantiate(LaserPrefab, new Vector3(-2.4f, -0.5f, 5), transform.rotation);
    }
    void Laser3()
    {
        Instantiate(LaserPrefab, new Vector3(0, -0.5f, 5), transform.rotation);
    }
    void Laser4()
    {
        Instantiate(LaserPrefab, new Vector3(2.4f, -0.5f, 5), transform.rotation);
    }
    void Laser5()
    {
        Instantiate(LaserPrefab, new Vector3(4.8f, -0.5f, 5), transform.rotation);
    }
}
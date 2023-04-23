using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour
{
    public GameObject TargetPrefab;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(IT3());
        StartCoroutine(IT1());
        StartCoroutine(IT5());
        StartCoroutine(IT2());
        StartCoroutine(IT4());
    }

    private IEnumerator IT1()
    {
        yield return new WaitForSeconds(49);
        GameObject obj = Instantiate(TargetPrefab, new Vector3(-4.8f, 0, -10), transform.rotation) as GameObject;
        yield return new WaitForSeconds(1.6f);
        Destroy(obj);
    }
    private IEnumerator IT2()
    {
        yield return new WaitForSeconds(75.5f);
        GameObject obj = Instantiate(TargetPrefab, new Vector3(-2.4f, 0, -10.5f), transform.rotation) as GameObject;
        yield return new WaitForSeconds(1.6f);
        Destroy(obj);
    }
    private IEnumerator IT3()
    {
        yield return new WaitForSeconds(18.5f);
        GameObject obj = Instantiate(TargetPrefab, new Vector3(0, 0, -10.5f), transform.rotation) as GameObject;
        yield return new WaitForSeconds(1.6f);
        Destroy(obj);
    }
    private IEnumerator IT4()
    {
        yield return new WaitForSeconds(75.5f);
        GameObject obj = Instantiate(TargetPrefab, new Vector3(2.4f, 0, -10.5f), transform.rotation) as GameObject;
        yield return new WaitForSeconds(1.6f);
        Destroy(obj);
    }
    private IEnumerator IT5()
    {
        yield return new WaitForSeconds(49);
        GameObject obj = Instantiate(TargetPrefab, new Vector3(4.8f, 0, -10.5f), transform.rotation) as GameObject;
        yield return new WaitForSeconds(1.6f);
        Destroy(obj);
    }   
}
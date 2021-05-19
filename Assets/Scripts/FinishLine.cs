using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject uiObject;

    public GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
        timer.SetActive(false);
    }
    
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            uiObject.SetActive(true);
            timer.SetActive(true);
            TimerFinish.Finish();
            StartCoroutine("Wait");
        }
    }

    private IEnumerable Wait()
    {
        yield return new WaitForSeconds(5);
        Destroy(uiObject);
        Destroy(timer);
        Destroy(gameObject);
    }
}

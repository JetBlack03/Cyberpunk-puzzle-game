using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject destroyable1;
    public GameObject destroyable2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NextLevel")
        {
            GameObject.Find("Level GUI").GetComponent<Animator>().Play("end");
            StartCoroutine(NewLevel());
            if (destroyable1 != null)
            {
                Destroy(destroyable1);
                Destroy(destroyable2);
            }
        }
    }

    IEnumerator NewLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

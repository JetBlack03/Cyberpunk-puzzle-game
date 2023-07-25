using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    bool on;
    public float upperLimit;
    public float lowerLimit;
    float direction = 1;
    public bool goBack;
    float timeStart;
    public float goBackTime;
    public GameObject progressBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
            if (direction == 1)
            {
                transform.GetChild(4).Translate(0, Time.deltaTime * 3, 0);

                PlayerMove player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
                if (player.onPlatform)
                {
                    player.transform.position = new Vector3(player.transform.position.x, transform.GetChild(4).position.y + 1.195827f, player.transform.position.z);

                    player.gravity = 0;
                }
                else
                {
                    print("f");
                    player.gravity = -9.8f;
                }
                if (transform.GetChild(4).localPosition.y >= upperLimit)
                {
                    direction = -1;
                    timeStart = Time.time;
                    on = false;
                    player.gravity = -9.8f;
                }
                
            }
            if (direction == -1)
            {
                transform.GetChild(4).Translate(0, Time.deltaTime * -3, 0);
                if (transform.GetChild(4).localPosition.y <= lowerLimit)
                {
                    direction = 1;
                    on = false;
                }
            }
        }
        else
        {
            if (goBack && direction == -1)
            {
                if(Time.time - timeStart >= goBackTime)
                {
                    transform.GetChild(4).Translate(0, Time.deltaTime * -3, 0);
                    if (transform.GetChild(4).localPosition.y <= lowerLimit)
                    {
                        direction = 1;
                        on = false;
                    }
                    if (progressBar != null) progressBar.SetActive(false);

                }
                else
                {
                    progressBar.SetActive(true);
                    progressBar.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(2.087708f * (Time.time - timeStart) / goBackTime, 0.345f);
                }
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(false);

            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {

            if(collision.transform.GetComponent<Projectile>().ammoType == "MA")
            {
                if(!goBack || direction == 1)
                    on = true;
            }
        }

    }

}

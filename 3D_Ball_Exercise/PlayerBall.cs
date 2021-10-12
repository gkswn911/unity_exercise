using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public int itemCount;
    public float JumpPower;
    public GameManagerLogic manager;
    bool isJump;
    Rigidbody rigid;
    AudioSource audio;

    // Start is called before the first frame update
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, JumpPower, 0), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }
    
   void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            manager.GetItem(itemCount);
            audio.Play();
            // gameObject는 자기 자신을 말한다.
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Finish")
        {
            // Game Finish!
            if (itemCount == manager.totalItemCount)
            {
                if(manager.stage == 2)
                {
                    SceneManager.LoadScene("ExampleScene1_" + 0);
                }
                else
                { 
                // Enter to Next Stage
                manager.stage++;
                SceneManager.LoadScene("ExampleScene1_" + manager.stage);
                }
            }
            // Restart..
            else
            {
                // Restart Currnet Stage
                SceneManager.LoadScene("ExampleScene1_" + manager.stage);
            }
        }
    }

}

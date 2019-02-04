using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text scoreText;
    public Text winText;
    private Rigidbody rb;
    private int count = 0, score = 0, lives = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetAllText();
        SetAllText2();
        winText.text = "";
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            score++;
            SetAllText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count++;
            score--;
            lives--;
            SetAllText();
        }
        else if (other.gameObject.CompareTag("Pick Up2"))
        {
            other.gameObject.SetActive(false);
            count++;
            score++;
            SetAllText();
        }
        else if (other.gameObject.CompareTag("Enemy2"))
        {
            other.gameObject.SetActive(false);
            count++;
            score--;
            lives--;
            SetAllText();
        }
    }

    void SetAllText ()
    {
        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();
        if (lives == 0 && gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
        else if (count >= 16)
        {
            winText.text = "You Win";
        }
        if (count >= 16 && score > 13)
        {
            count = 0;
            lives = 3;                       
            transform.position = new Vector3(-70.0f, 0.5f, 0.0f);
            winText.text = "";
        }

    }   

    void SetAllText2 ()
    {             
        if (lives == 0 && gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
        else if (count >= 12)
        {
            winText.text = "You Win";
        }
    }
}

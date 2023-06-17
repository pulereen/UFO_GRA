using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Text scoreText;
    public Text winText;
    Rigidbody2D rb2d;
    public float speed = 0;
    private int count = 0;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * 15);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp"))
        {
            count++;
            Destroy(collision.gameObject);
            UpdateScoreText();

        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Wynik: " + count;
        if (count == 5)
        {
            winText.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            StartCoroutine(StopTime());
            
        }
    }

    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level02");
    }
}


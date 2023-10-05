using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Obstacle : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float speed;

    private void Awake()
    {
        text = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            Destroy(collision.gameObject);
            Invoke("ReloadScene", 3f);
        }

        if(collision.collider.name == "Out")
        {
            int score = int.Parse(text.text) + 1;
            text.text = score.ToString();
            Destroy(gameObject);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

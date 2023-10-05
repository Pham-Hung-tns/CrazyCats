using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CatHitter : MonoBehaviour
{
    public float forceByPlayer;
    public float forceRadius;
    public bool isAI = false;
    public TextMeshProUGUI textScore;
    private HitableObject ho;
    public BillBoard billBoard;
    public GameObject[] hitEffect;
    public GameManager gm;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!isAI)
        {
            if (hit.gameObject.tag == "hitable")
            {
                Rigidbody body = hit.collider.attachedRigidbody;
                ho = hit.gameObject.GetComponent<HitableObject>();
                body.isKinematic = false;
                body.AddExplosionForce(forceByPlayer, transform.position + Vector3.down, forceRadius);
                Instantiate(hitEffect[UnityEngine.Random.Range(0, hitEffect.Length)], hit.transform.position, Quaternion.identity);

                ScoreEffect();
                GetCoins();
                Invoke("NullBillBoard", 0.8f);
                // check vat the da va cham
                hit.gameObject.tag = "hitted";
            }
        }

    }

    private void GetCoins()
    {
        int actualCoin = PlayerPrefs.GetInt("nbCoin", 0);
        PlayerPrefs.SetInt("nbCoin", actualCoin + ho.coin);
    }

    private void ScoreEffect()
    {
        int newScore = int.Parse(textScore.GetComponent<TextMeshProUGUI>().text) + ho.point;
        iTween.PunchScale(billBoard.gameObject, new Vector3(0.1f, 0.1f, 0.1f), 0.2f);
        billBoard.GetComponent<TextMesh>().text = "+ " + ho.point.ToString();
        textScore.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
    }

    public void NullBillBoard()
    {
        billBoard.GetComponent<TextMesh>().text = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAI && gm.gameStarted && !gm.gameEnded)
        {
            if(other.gameObject.tag == "hitable")
            {
                Rigidbody body = other.gameObject.GetComponent<Rigidbody>();
                ho = other.gameObject.GetComponent<HitableObject>();
                body.isKinematic = false;
                body.AddExplosionForce(forceByPlayer, transform.position + Vector3.down, forceRadius);
                Instantiate(hitEffect[UnityEngine.Random.Range(0, hitEffect.Length)], other.transform.position, Quaternion.identity);
                other.gameObject.tag = "hitted";

                if(other.gameObject.name != "touched")
                {
                    AIPlayer aip = GetComponent<AIPlayer>();
                    aip.GetPoint(ho.point);
                }
                other.gameObject.name = "touched";
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPlayer : MonoBehaviour
{
    NavMeshAgent agent;
    public Animator catAnim;
    public int score = 0;
    public float radius = 10;
    public GameManager gm;
    public Texture[] skins; 
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponentInChildren<Renderer>().material.mainTexture = skins[Random.Range(0, skins.Length)];
    }

    public void StartGame()
    {
        agent.destination = RandomNavmeshLocation(radius);
        InvokeRepeating("ChangDestination", Random.Range(8,12), Random.Range(8, 12));
        
    }

    private Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;

        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        
        // lay mau trong pham vi radius voi diem bat dau la randomDirection
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }

    private void ChangeDestination()
    {
        agent.destination = RandomNavmeshLocation(radius);

    }

    private void Update()
    {
        catAnim.SetBool("canMove", true);
        if (gm.gameStarted && agent.remainingDistance < 1f)
        {
            ChangeDestination();
        }
    }

    public void GetPoint(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}

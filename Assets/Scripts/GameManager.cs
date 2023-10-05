using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public int level = 1;
    public bool gameStarted = false;
    public bool gameEnded { get; private set; }
    public GameObject[] rooms;
    public GameObject[] tutorials;
    public AIPlayer[] AIplayers;
    public GameObject screenEnd;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreFinal;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI[] finalScoresText;
    public string[] finalScores;
    public int timeVal = 10;

    public GameObject characterController;
    public GameObject[] pos;
    public GameObject[] posAI;
    public GameObject[] posAI1;
    public AudioSource audio;
    private void Awake()
    {
        if(PlayerPrefs.GetInt("level", 1) >= rooms.Length)
        {
            level = rooms.Length;
            PlayerPrefs.SetInt("level", 0);
        }
        else
        {
            level = PlayerPrefs.GetInt("level", 1);
        }
        levelText.text = "LEVEL: " + level.ToString();
        for (int i = 1; i <= rooms.Length; i++)
        {
            if (i <= level)
            {
                rooms[i - 1].SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("score", 0) != 0)
        {
            highScore.text = "High Score: " + PlayerPrefs.GetInt("score", 0);
        }

        characterController.transform.position = pos[level - 1].transform.position;
        AIplayers[0].transform.position = posAI[level-1].transform.position;
        AIplayers[1].transform.position = posAI[level - 1].transform.position;
    }

    private void Start()
    {
        gameEnded = true;
    }
    private void Update()
    {
    }

    public void StartGame()
    {
        audio.Play();
        gameStarted = true;
        gameEnded = false;
        tutorials[0].SetActive(false);
        InvokeRepeating("SetTimer", 1, 1);
        foreach(AIPlayer ai in AIplayers)
        {
            ai.StartGame();
        }
    }

    public void SetTimer()
    {
        if (timeVal == 0)
        {
            audio.Stop();

            int score = int.Parse(scoreText.text);

            int scoreTotal = PlayerPrefs.GetInt("scoreTotal", 0);
            scoreTotal += score;
            
            PlayerPrefs.SetInt("scoreTotal", scoreTotal);
            //int actualLevel = Mathf.FloorToInt(scoreTotal / 100) + 1;
            

            int scoreMax = PlayerPrefs.GetInt("score", 0);

            if (score > scoreMax)
                PlayerPrefs.SetInt("score", score);

            scoreFinal.text = "Score: " + score;
            screenEnd.SetActive(true);
            gameEnded = true;
            CancelInvoke();

            // show ranked
            finalScores[0] = "You : " + scoreText.text;
            finalScores[1] = AIplayers[0].gameObject.name + " : " + AIplayers[0].score;
            finalScores[2] = AIplayers[1].gameObject.name +" : "+ AIplayers[1].score;

            for (int i =0;i < 3; i++)
            {
                finalScoresText[i].text = finalScores[i];
            }
        }
        else
        {
            timeVal--;
            timeText.text = timeVal.ToString();
        }
    }

    public void RestartGame()
    {
        audio.Play();
        PlayerPrefs.SetInt("level",PlayerPrefs.GetInt("level", 1));
        timeVal = 20;
        Application.LoadLevel(Application.loadedLevelName);
        screenEnd.SetActive(false);
    }

    public void NextLevel()
    {
        audio.Play();
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 1) + 1);
        timeVal = 20;
        Application.LoadLevel(Application.loadedLevelName);
        screenEnd.SetActive(false);
    }
    public void WatchAd()
    {
        GetExtraTime();
    }

    public void GetExtraTime()
    {
        timeVal = 10;
        timeText.text = timeVal.ToString();
        InvokeRepeating("SetTimer", 1, 1);
        gameEnded = false;
        screenEnd.SetActive(false);
    }
}

using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timer;
    public float gameTimeLimit = 30f;
    public float timeLeft;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public GameObject myPlayer;
    WASDcontroller2D playerScript;

    Vector3 startPos;
    public float score;
    float scoreBase, dScore;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPlayer = GameObject.FindWithTag("Player");
        playerScript = myPlayer.GetComponent<WASDcontroller2D>();
        startPos = myPlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime is the amount of time that has
        //passed since the last frame
        timer += Time.deltaTime;
        timeLeft = gameTimeLimit - timer;

        if (timeLeft <= 0)
        {
            //end the game
            Destroy(myPlayer);
            gameOverScreen.SetActive(true);
            Debug.Log("Game Over!");

        }

        timerText.text = timeLeft.ToString();

        float posScore = Mathf.Abs(myPlayer.transform.position.y - startPos.y);
        if( posScore > scoreBase)
        {
            scoreBase = posScore;
        }
        int dScore = playerScript.destroyedCount;

        score = scoreBase * (dScore + 1);

        
        scoreText.text = score.ToString();
    }

    void FixedUpdate()
    {
        //Time.fixedDeltaTime is the amount of time that has
        //passed since the last physics step
        float delta = Time.fixedDeltaTime;
    }
}

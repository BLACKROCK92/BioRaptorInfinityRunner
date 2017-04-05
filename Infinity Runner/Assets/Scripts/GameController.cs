using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject playerGO;
    public GameObject endGameCanvas;
    public Vector3 spawnValues;
    public int enemyCount;
    public float spawnWait;
    public float waveWait;
    public float startWait;
    private int score;
    private int lives;

    private bool gameOver;
    private bool restart;
    private bool paused;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text endGameText;
    public Text livesText;
    public Text pauseText;

    void Start()
    {
        score = 0;
        lives = 3;
        gameOver = false;
        restart = false;
        restartText.text = "";
        pauseText.text = "";
        endGameText.text = "";
        UpdateScore();
        UpdateLives();
        StopCoroutine(SpawnWaves());
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                //Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(0, spawnValues.y), spawnValues.z);
                //Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
                Vector3 spawnPosition2 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(0, spawnValues.y), spawnValues.z);
                Instantiate(enemyPrefab2, spawnPosition2, enemyPrefab.transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                if (getLives() >= 1)
                {
                    restartText.text = "Press 'R' to Respawn!";
                    restart = true;
                    break;
                }
            }
        }
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Respawn();
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    void Pause()
    {
        if (paused)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            pauseText.text = "Game Paused\n\nPress P to resume!";
            endGameCanvas.SetActive(true);
            paused = false;
        }
        else
        {
            Cursor.visible = false;
            endGameCanvas.SetActive(false);
            paused = true;
            Time.timeScale = 1;
            pauseText.text = "";
        }

    }

    void Respawn()
    {
        Time.timeScale = 1;
        foreach (GameObject playerGO in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(playerGO, 0.1f);
        }
        Instantiate(playerGO, new Vector3(0, 0, 0), Quaternion.identity);
        restart = false;
        gameOver = false;
        restartText.text = "";
        gameOverText.text = "";
        endGameText.text = "";
        StopCoroutine(SpawnWaves());
        StartCoroutine(SpawnWaves());
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            go.SetActive(false);
            Destroy(go, 0.1f);
        }
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Shot"))
        {
            go.SetActive(false);
            Destroy(go, 0.1f);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("PowerUp"))
        {
            go.SetActive(false);
            Destroy(go, 0.1f);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void TakeLife(int value)
    {
        setLives(value);
        UpdateLives();
    }

    void UpdateLives()
    {
        livesText.text = "Lives: " + lives;
    }

    public void GameOver()
    {
        if (getLives() > 0)
        {
            gameOverText.text = "You have " + getLives() + " live(s) remaining !";
            gameOver = true;
            Cursor.visible = true;
        }

    }

    public IEnumerator EndGame()
    {
        endGameText.text = "Game Over!\n\nYour Score was : " + score + "\n\nThanks for playing !";
        endGameCanvas.SetActive(true);
        yield return null;
    }

    public void endGame()
    {
        print("exit");
        Application.Quit();
    }

    public void Restart()
    {
        score = 0;
        lives = 3;
        Respawn();
        scoreText.text = "Score: 0";
        if (endGameCanvas.activeInHierarchy)
        {
            endGameCanvas.SetActive(false);
        }
        Cursor.visible = false;
    }

    public int getLives()
    {
        return lives;
    }

    public void setLives(int value)
    {
        lives += value;
    }

}
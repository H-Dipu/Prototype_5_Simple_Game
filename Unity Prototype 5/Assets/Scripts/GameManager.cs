using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private int score;
    public TextMeshProUGUI scoreText;

    private int numberOfTargets;
    public TextMeshProUGUI numberOfTargetsText;

    public TextMeshProUGUI gameOverText;

    private float spawnRate = 1.0f;

    public bool isGameActive;

    public Button restartButton;


    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;

        StartCoroutine(SpawnTarget());
      
        numberOfTargets = 0;
        UpdateScore(0);

       


    }

    // Update is called once per frame
    void Update()
    {
        
    }

     IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            //UpdateScore(1);
            UpdateNumberOfTargets(1);
        }
    }

    public  void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        

    }

    public void UpdateNumberOfTargets(int numberOfTargetsToAdd)
    {
        numberOfTargets += numberOfTargetsToAdd;
        numberOfTargetsText.text = "Target: " + numberOfTargets;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
       
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int MaxAmountOfGem { get; set; }
    public int MaxAmountOfFruit { get; set; }

    private UIManager uiManager;
    private int currentGem, currentFruit;
    private void Awake()
    {
        uiManager = UIManager.Instant;
    }
    // Start is called before the first frame update
    void Start()
    {
        MaxAmountOfFruit = 32;
        MaxAmountOfGem = 100;

        currentFruit = 0;
        uiManager.UpdateFruitText(currentFruit);
        currentGem = 0;
        uiManager.UpdateGemText(currentGem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        uiManager.ShowOrHidePausePanel(true);
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        uiManager.ShowOrHidePausePanel(false);
        Time.timeScale = 1;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void ExitLevel()
    {
        SceneManager.LoadScene(0); //quay về màn hình menu chính
        Time.timeScale = 1;
    }
    public void IncreaseGem(int value)
    {
        currentGem += value;
        uiManager.UpdateGemText(currentGem);
    }
    public void IncreaseFruit(int value)
    {
        currentFruit += value;
        uiManager.UpdateFruitText(currentFruit);
    }
    
    public void Victory()
    {
        int stars = 1;
        if(currentGem >= MaxAmountOfGem)
        {
            stars++;
        }
        if(currentFruit >= MaxAmountOfFruit)
        {
            stars++;
        }

        uiManager.ShowOrHideVictoryPanel(true);
        uiManager.victoryPanel.GetComponent<VictoryPanel>().UpdateResult(currentGem, currentFruit, stars);

        Time.timeScale = 0;
    }
    public void Defeat()
    {
        uiManager.ShowOrHideDefeatPanel(true);
        
        uiManager.defeatPanel.GetComponent<DefeatPanel>().UpdateResult(currentGem, currentFruit);

        Time.timeScale = 0;
    }
}

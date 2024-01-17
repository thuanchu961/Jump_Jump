using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] public GameObject victoryPanel;
    [SerializeField] public GameObject defeatPanel;

    [SerializeField] private List<Heart> heartsList;

    [SerializeField] private Text gemText;
    [SerializeField] private Text fruitText;

    [SerializeField] private Button pauseButton;

    private int currentHeartIndex;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GameManager.Instant;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHeartIndex = 0;
        pausePanel.SetActive(false);
        victoryPanel.SetActive(false);
        defeatPanel.SetActive(false);
        pauseButton.onClick.AddListener(gameManager.PauseGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateGemText(int value)
    {
        gemText.text = $"{value}/{gameManager.MaxAmountOfGem}";
    }
    public void UpdateFruitText(int value)
    {
        fruitText.text = $"{value}/{gameManager.MaxAmountOfFruit}";
    }
    public void DecreseHeart()
    {
        heartsList[currentHeartIndex].DisableHeart();
        currentHeartIndex++;
    }
    public void ShowOrHidePausePanel(bool value)
    {
        pausePanel.SetActive(value);
    }
    public void ShowOrHideVictoryPanel(bool value)
    {
        victoryPanel.SetActive(value);
    }
    public void ShowOrHideDefeatPanel(bool value)
    {
        defeatPanel.SetActive(value);
    }
}

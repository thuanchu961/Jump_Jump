using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatPanel : MonoBehaviour
{
    [SerializeField] private Text gemText;
    [SerializeField] private Text fruitText;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GameManager.Instant;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void UpdateResult(int gem, int fruit)
    {
        StartCoroutine(Result(gem, fruit));
    }
    IEnumerator Result(int gem, int fruit)
    {
        yield return new WaitForEndOfFrame();
        gemText.text = $"{gem}/{gameManager.MaxAmountOfGem}";
        yield return new WaitForEndOfFrame();
        fruitText.text = $"{fruit}/{gameManager.MaxAmountOfFruit}";
    }
    public void HomeButton()
    {
        gameManager.ExitLevel();
    }
    public void SelectLevelButton()
    {
        gameManager.ExitLevel();
    }
    public void ReplayButton()
    {
        gameManager.RestartLevel();
    }
}

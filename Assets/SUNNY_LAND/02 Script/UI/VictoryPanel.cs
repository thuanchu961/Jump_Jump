using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VictoryPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> listStars;
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
    public void UpdateResult(int gem, int fruit, int stars = 1)
    {
        StartCoroutine(Result(gem, fruit, stars));
    }
    IEnumerator Result(int gem, int fruit, int stars = 1)
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < stars; i++)
        {
            listStars[i].SetActive(true);
        }
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
    public void NextButton()
    {
        gameManager.NextLevel();
    }
}

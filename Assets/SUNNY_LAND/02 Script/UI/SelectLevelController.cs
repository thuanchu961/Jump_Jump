using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelController : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject buttonLevel;
    [SerializeField] private Sprite normalButton;
    [SerializeField] private Sprite lockButton;
    private int maxNumberOfButton;
    private int levelUnlocked;
    private void Awake()
    {
        maxNumberOfButton = 8;

        if (PlayerPrefs.HasKey("LevelUnlocked"))
        {
            levelUnlocked = PlayerPrefs.GetInt("LevelUnlocked");
        }
        else
        {
            levelUnlocked = 1;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateButtonLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateButtonLevel()
    {
        for (int i = 1; i <= maxNumberOfButton; i++)
        {
            GameObject ob = Instantiate(buttonLevel, Vector3.zero, Quaternion.identity);
            ob.transform.SetParent(content.transform);
            ob.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            ob.GetComponent<ButtonLevel>().ID = i;
            if(i <= levelUnlocked)
            {
                ob.GetComponent<Button>().interactable = true;
                ob.GetComponent<Image>().sprite = normalButton;
                ob.GetComponentInChildren<Text>().text = i.ToString();
            }
            else
            {
                ob.GetComponent<Button>().interactable = false;
                ob.GetComponent<Image>().sprite = lockButton;
                ob.GetComponentInChildren<Text>().text = "";
            }
        }
    }
}

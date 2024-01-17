using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneController : MonoBehaviour
{
    [SerializeField] private GameObject selectLevelPanel;
    // Start is called before the first frame update
    void Start()
    {
        selectLevelPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton()
    {
        selectLevelPanel.SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}

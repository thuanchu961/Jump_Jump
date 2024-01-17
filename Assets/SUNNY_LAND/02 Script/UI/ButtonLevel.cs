using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevel : MonoBehaviour
{
    public int ID { get; set; }
    
    public void LoadLevel()
    {
        SceneManager.LoadScene(ID);
    }
}

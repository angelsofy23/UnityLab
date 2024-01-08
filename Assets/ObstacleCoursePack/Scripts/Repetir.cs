using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Repetir : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public void RepetirGame()
    {
        SceneManager.LoadScene("New Scene");
        Time.timeScale = 1f;
    }
}

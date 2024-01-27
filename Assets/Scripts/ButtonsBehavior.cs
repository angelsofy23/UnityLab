using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonsBehavior : MonoBehaviour
{
    [SerializeField] GameObject chooseplayers;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject credits;


    public void Choose()
    {
        chooseplayers.SetActive(true);
        menu.SetActive(false);
        credits.SetActive(false);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void PlayOnePlayers()
    {
        SceneManager.LoadScene("Player1");
    }


    public void PlayTwoPlayers()
    {
        SceneManager.LoadScene("Player2");
    }

    public void VoltarHome()
    {
        chooseplayers.SetActive(false);
        menu.SetActive(true);
        credits.SetActive(false);
    }

    public void Credits()
    {
        menu.SetActive(false);
        chooseplayers.SetActive(false);
        credits.SetActive(true);
    }
}

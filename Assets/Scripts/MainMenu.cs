using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // https://www.youtube.com/watch?v=DX7HyN7oJjE
        SceneManager.LoadSceneAsync(1);
    }
}

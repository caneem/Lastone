using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuPanel : MonoBehaviour
{ 
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}


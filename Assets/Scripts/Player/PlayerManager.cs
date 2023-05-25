using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{

    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    public static bool isYouWin;
    public GameObject youWinScreen;


    public static Vector2 lastCheckPointPos = new Vector2(-8,0);

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    public CinemachineVirtualCamera VCam;

    public GameObject[] playerPrefabs;
    int characterIndex;

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0 );
        isGameOver = false;
        isYouWin = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = numberOfCoins.ToString();        
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
        }

        if(isYouWin)
        {
            youWinScreen.SetActive(true);
        }
    }


    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextLevel02()
    {
        SceneManager.LoadScene("Level02");
    }

    public void NextLevel03()
    {
        SceneManager.LoadScene("Level03");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;

    [SerializeField] TextMeshProUGUI livesText;

    bool keyPicked = false;

    void Awake()
    {
        // Singleton pattern
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
        RemoveKey();
    }

    public void ProcessPlayerDeath()
    {
        RemoveKey();
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddKey()
    {
        getKeyImage().enabled = true;
        keyPicked = true;
    }

    public void RemoveKey()
    {
        getKeyImage().enabled = false;
        keyPicked = false;
    }

    void TakeLife()
    {
        playerLives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        livesText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public bool IsKeyPicked()
    {
        return keyPicked;
    }

    Image getKeyImage() {
        return GameObject.FindWithTag("KeyImage").GetComponent<Image>();
    }
}

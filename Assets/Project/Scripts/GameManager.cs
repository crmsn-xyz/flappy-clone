using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject TextScreen;

    private void Update() {
        deathScreen.SetActive(Player.stopGame == true);

        TextScreen.SetActive(!Player.startGame);
    }

    public void RestartGame() {
        Player.stopGame = false;
        Player.startGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
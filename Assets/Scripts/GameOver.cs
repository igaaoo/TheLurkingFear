using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  private TMPro.TextMeshProUGUI highscoreText;

  // Set highscore text
  void Start()
  {
    highscoreText = GameObject.Find("Highscore").GetComponent<TMPro.TextMeshProUGUI>();
    highscoreText.text = "Pontuacao: " + GameObject.FindObjectOfType<GetHighscore>().GetScore();
  }

  // Get inputs
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.R))
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Application.Quit();
      Debug.Log("Quit");
    }
  }
}

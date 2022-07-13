using UnityEngine;

public class Sanity : MonoBehaviour
{

  private bool donwSanity = false;

  private float sanity = 100;
  private TMPro.TextMeshProUGUI sanityText;


  private void Start()
  {
    sanityText = GameObject.Find("SanityValue").GetComponent<TMPro.TextMeshProUGUI>();
  }

  // Decrease sanity
  public void JumpscareEffect()
  {
    sanity -= 10;
  }

  // Show sanity
  private void Update()
  {
    donwSanity = EventManager.instance.HasEnemy();

    if (donwSanity)
    {
      sanity -= Time.deltaTime * 0.5f;
    }
    else if (donwSanity == false && sanity <= 100)
    {
      sanity += Time.deltaTime * 0.5f;
    }

    sanityText.text = sanity.ToString("0");

    // Load gameover scene when sanity is 0
    if (sanity <= 0)
    {
      MenuManager menu = GameObject.FindObjectOfType<MenuManager>();
      GetHighscore highscore = GameObject.FindObjectOfType<GetHighscore>();
      highscore.SetHighscore();
      menu.GameOver();
    }
  }
}

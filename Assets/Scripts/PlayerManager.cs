using UnityEngine;

public class PlayerManager : MonoBehaviour
{
  [SerializeField]
  private GameObject lanternLight;

  private Ray playerRay;
  private RaycastHit hit;

  int layerMask = 1 << 3;

  private void Update()
  {
    LanternLight();
    HitEnemy();
  }

  // Turn on lantern light
  private void LanternLight()
  {
    if (Input.GetMouseButton(0))
    {
      lanternLight.SetActive(true);
    }
    else
    {
      lanternLight.SetActive(false);
    }
  }

  // Detect if player hit enemy
  private void HitEnemy()
  {
    playerRay.origin = transform.position;
    playerRay.direction = this.transform.forward;

    if (Physics.Raycast(playerRay, out hit, 10, layerMask) && hit.collider.tag == "Enemy" && Input.GetMouseButton(0))
    {
      hit.collider.GetComponent<EnemyManager>().Defeated();
    }
  }
}

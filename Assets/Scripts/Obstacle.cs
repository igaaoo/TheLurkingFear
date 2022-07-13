using UnityEngine;

public class Obstacle : MonoBehaviour
{
  //Detect when the player enters the trigger zone (collide)
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      // Slow down car
      CarController.instance.StartCoroutine(CarController.instance.Collided());
      Destroy(gameObject, 0.4f);
      Debug.Log("Collided");
    }
  }
}

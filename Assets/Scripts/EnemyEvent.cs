using UnityEngine;

public class EnemyEvent : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      //Makes the jumpscare event
      EventManager.instance.StartCoroutine(EventManager.instance.Jumpscare());
    }
  }
}

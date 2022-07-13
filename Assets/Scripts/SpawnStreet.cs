using UnityEngine;
using System.Collections;

public class SpawnStreet : MonoBehaviour
{
  [SerializeField]
  private GameObject street;

  private float streetSize;

  private void Start()
  {
    //Get the size of the street
    streetSize = street.GetComponent<Collider>().bounds.size.z;
  }

  //Spawn a street 
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      GameObject newStreet = Instantiate(Resources.Load("Prefabs/Street"), new Vector3(0, 0, this.gameObject.transform.position.z + streetSize), Quaternion.identity) as GameObject;
    }
  }

  //Destroy the past street
  private void OnTriggerExit()
  {
    StartCoroutine(DestroyStreet());
  }

  //Destroy the street after a few seconds
  private IEnumerator DestroyStreet()
  {
    yield return new WaitForSeconds(10);
    Destroy(this.gameObject);
  }


}

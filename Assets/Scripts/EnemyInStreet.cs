using UnityEngine;

public class EnemyInStreet : MonoBehaviour
{

  [SerializeField]
  private GameObject[] enemiesPos;

  [SerializeField]
  private GameObject enemyPrefab;

  private int chanceEnemy;


  // Spawn enemy in street for jumpscares
  void Start()
  {
    chanceEnemy = EventManager.instance.CanEnemyInStreet();

    int canSpawn = Random.Range(0, 10);

    if (canSpawn > chanceEnemy)
    {
      int randomPos = Random.Range(0, enemiesPos.Length);
      enemiesPos[randomPos].SetActive(true);

      GameObject enemy = Instantiate(enemyPrefab, enemiesPos[randomPos].transform.position, Quaternion.Euler(0, 90, 0), enemiesPos[randomPos].transform) as GameObject;
      enemy.GetComponentsInChildren<BoxCollider>()[0].enabled = false;
      enemy.GetComponentsInChildren<EnemyManager>()[0].enabled = false;
    }
  }
}

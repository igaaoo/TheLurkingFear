using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
  private static EventManager _instance;
  public static EventManager instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = FindObjectOfType<EventManager>();
      }
      return _instance;
    }
  }


  [Header("Enemy Configs")]
  [SerializeField]
  private bool hasEnemy = false;
  [SerializeField]
  private float spawnInterval = 1f;
  [SerializeField]
  private int canEnemyInStreet = 5;
  private float time;
  [SerializeField]
  private GameObject[] enemySpawnPoints;
  [SerializeField]
  private GameObject[] enemyPrefabs;
  [Space(10)]


  [Header("Obstacles:")]
  [SerializeField]
  private int _spawnChance;


  private GameObject jumpscare;


  private void Awake()
  {
    jumpscare = GameObject.FindWithTag("Jumpscare");
    jumpscare.SetActive(false);
    enemySpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawn");
  }

  //Returns the number of obstacles that can spawn
  public int SpawnChance()
  {
    return _spawnChance;
  }

  //Returns the chance of enemy can spawn in street
  public int CanEnemyInStreet()
  {
    return canEnemyInStreet;
  }

  public bool HasEnemy()
  {
    return hasEnemy;
  }

  //Spawn enemy
  public void SpawnEnemy()
  {
    PostProcessingController.instance.ApplyChromaticAberration();
    if (hasEnemy == false)
    {
      int randomEnemy = Random.Range(0, enemySpawnPoints.Length);
      Instantiate(enemyPrefabs[randomEnemy], enemySpawnPoints[randomEnemy].transform.position, enemyPrefabs[randomEnemy].transform.rotation, enemySpawnPoints[randomEnemy].transform);
      hasEnemy = true;
    }
  }

  //Make jumpscare on collision with enemy in street
  public IEnumerator Jumpscare()
  {
    PostProcessingController.instance.ApplyLensDistortion();
    jumpscare.SetActive(true);
    yield return new WaitForSeconds(1f);
    jumpscare.SetActive(false);
    PostProcessingController.instance.RemoveLensDistortion();

    Sanity sanity = FindObjectOfType<Sanity>();
    sanity.JumpscareEffect();

  }

  //Determines if can spawn, used by enemies
  public void CanSpawnEnemy()
  {
    hasEnemy = false;
    PostProcessingController.instance.RemoveChromaticAberration();
  }

  private void Update()
  {
    //Spawn enemy over time (spawnInterval)
    if (hasEnemy == false)
    {
      time += Time.deltaTime;
      if (time >= spawnInterval)
      {
        SpawnEnemy();
        time -= spawnInterval;
      }
    }

  }
}

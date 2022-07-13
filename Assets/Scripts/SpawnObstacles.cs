using UnityEngine;
using System.Collections.Generic;

public class SpawnObstacles : MonoBehaviour
{
  //Get the positions that obstacle can spawn
  [SerializeField]
  private Transform[] spawnPositions;

  //Gets prefabs of the obstacles
  [SerializeField]
  private GameObject[] obstacles;

  private int canSpawn;

  void Start()
  {
    //Get the number of obstacles that can spawn
    canSpawn = EventManager.instance.SpawnChance();
    Spawn(canSpawn);
  }

  private void Spawn(int max)
  {
    var usedPosition = new List<int>();

    //Spawn obstacles
    for (int i = 0; i < max; i++)
    {
      int randomPos = Random.Range(0, spawnPositions.Length);
      int randomObstacle = Random.Range(0, obstacles.Length);

      //Check if the position is already used
      if (!usedPosition.Contains(randomPos))
      {
        usedPosition.Add(randomPos);
        GameObject obstacle = Instantiate(obstacles[randomObstacle], spawnPositions[randomPos].transform.position, Quaternion.Euler(-90, 90, 0), spawnPositions[randomPos].transform) as GameObject;
      }
    }
  }
}

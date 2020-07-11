using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    private const float playerDistance = 200f;
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPart;
    public GameObject player;
    Vector3 lastEndPosition;
    
    void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        int startingSpawnLevelParts = 5;
        for(int i = 0; i <= startingSpawnLevelParts; i++) {
            SpawnLevelPart();
        }
    }

    void Update()
    {
        if(Vector3.Distance(player.transform.position, lastEndPosition) < playerDistance) {
            //Spawn another level
            SpawnLevelPart();
        }
    }
    void SpawnLevelPart() {
        Transform chosenLevelPart = levelPart[Random.Range(0, levelPart.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition) {
        Transform levelPartTransform = Instantiate(levelPart,spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}

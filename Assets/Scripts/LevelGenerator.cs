using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PlayerDistanceSpawnLevelPart = 25f;
    [SerializeField] private Transform levelStartPart;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private PlayerController player;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelStartPart.Find("EndPosition").position;

        int startingSpawnLevelParts = 5;
        for(int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }
    private void Update()
    {
        if(player != null && (Vector3.Distance(player.transform.position, lastEndPosition) < PlayerDistanceSpawnLevelPart))
        {
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Vector3 offset = levelPart.Find("StartPosition").localPosition;
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition-offset, Quaternion.identity);
        Destroy(levelPartTransform.gameObject, Vector3.Distance(player.transform.position, levelPartTransform.position)/player.speed + 20);
        return levelPartTransform;
    }
}

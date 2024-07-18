using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private Transform wallSpawnPoint;
    private List<GameObject> _wallList = new List<GameObject>();

    private IEnumerator SpawnWalls()
    {
        while (true)
        {
            Vector2 pos = wallSpawnPoint.position;
            pos.y += Random.Range(-2.5f, 2.5f);
            GameObject wall = Instantiate(wallPrefab, pos, Quaternion.identity);
            _wallList.Add(wall);
            if (_wallList.Count > 4)
            {
                Destroy(_wallList[0]);
                _wallList.RemoveAt(0);
            }
            yield return new WaitForSeconds(3f);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnWalls());
    }
}

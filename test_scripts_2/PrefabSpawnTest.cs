using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PrefabSpawnTest : MonoBehaviour
{
    // Prefab öğelerin spawn olmasını sağladığımız script. Hangi aralıklarda zamanlarda 


    public GameObject circlePrefab;
    public GameObject starPrefab;
    public GameObject squarePrefab;
    public GameObject trianglePrefab;

    public GameObject[] enemyobjects;
    public float respawnTime = 2.0f;
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        enemyobjects = new GameObject[4];
        enemyobjects[0] = circlePrefab;
        enemyobjects[1] = starPrefab;
        enemyobjects[2] = squarePrefab;
        enemyobjects[3] = trianglePrefab;
        StartCoroutine(enemyWawe());
    }
    private void spawnEnemy()
    {
        GameObject currentspawnobject = Instantiate(enemyobjects[Random.Range(0,enemyobjects.Length)]) as GameObject;
        currentspawnobject.transform.position = new Vector2(Random.Range(-screenBounds.y, screenBounds.y), screenBounds.x + 3.0f);
    }


    IEnumerator enemyWawe()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}

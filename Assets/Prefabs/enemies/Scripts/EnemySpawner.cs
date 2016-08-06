using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    public GameObject enemyPrefab5;
    public GameObject enemyPrefab6;

    GameObject newEnemy;

    public float width      = 10f;
    public float height     = 5f;
    public float speed      = 5f;
    public float spawnDelay = 0f;

    private bool mLeft      = true;
    private float xmax;
    private float xmin;


    // Use this for initialization
    void Start () {
        
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 lEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmax = lEdge.x - 1;
        xmin = rEdge.x + 1;

        SpawnEnemies();

    }


    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {                       
           GameObject enemy = Instantiate(enemyPrefab1, child.transform.position, Quaternion.identity) as GameObject; //Make the spawned enemy as a new game object
           enemy.transform.parent = child; //Put the spawned enemy under EnemySpawner in Hierarchy
        }
    }

    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {            
            GameObject enemy = Instantiate(newEnemy, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    void ScoreCheck()
    {
        int Score = ScoreKeeper.score;
        if (Score <= 0 && Score < 1000)
        {
            newEnemy = enemyPrefab1;
        }
        else if (Score >= 1000 && Score < 2500)
        {
            newEnemy = enemyPrefab2;
        }
        else if (Score >= 2500 && Score < 5000)
        {
            newEnemy = enemyPrefab3;
        }
        else if (Score >= 5000 && Score < 10000 )
        {
            newEnemy = enemyPrefab4;
        }
        else if (Score >= 10000 && Score < 50000)
        {
            newEnemy = enemyPrefab5;
        }
        else if (Score >= 50000)
        {
            newEnemy = enemyPrefab6;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Update is called once per frame
    void Update() {

        if (mLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float rFormation = transform.position.x + (0.5f * width);
        float lFormation = transform.position.x - (0.5f * width);
        if (rFormation < xmax)
        {
            mLeft = false;
        }
        else if (lFormation > xmin)
        {
            mLeft = true;
        }

        if (AllMembersDead())
        {
            SpawnUntilFull();
        }
        ScoreCheck();
      
    }

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if(childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;               
            }
        }
        return null;
    }


    bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }
}

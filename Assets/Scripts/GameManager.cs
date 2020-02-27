using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyObject;
   
    private float _xTilt = 1.75f;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemyRoutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        float _randomValueX = Random.Range(-_xTilt, _xTilt);

        Vector3 _enemyPosition = new Vector3(_randomValueX, 0.5f, 80f);

        Instantiate(_enemyObject, _enemyPosition, Quaternion.identity);
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }
}

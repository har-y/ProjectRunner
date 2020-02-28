using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyObject;
    [SerializeField] private GameObject _enemyContainer;
   
    private float _xTilt = 1.75f;
    private int _score = 0;

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

        Vector3 _enemyPosition = new Vector3(_randomValueX, 0.5f, 50f);

        GameObject _enemy = Instantiate(_enemyObject, _enemyPosition, Quaternion.identity);
        _enemy.transform.parent = _enemyContainer.transform;
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void ScoreUp()
    {
        _score++;
    }
}

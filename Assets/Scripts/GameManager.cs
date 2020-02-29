using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyObject;
    [SerializeField] private GameObject _enemyContainer;

    [SerializeField] private Text _scoreText;
   
    private float _xTilt = 1.75f;

    private int _score = 0;

    private bool _gameStarted = false;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !_gameStarted)
        {
            _scoreText.gameObject.SetActive(true);
            StartCoroutine("SpawnEnemyRoutine");
            _gameStarted = true;
        }
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
        _scoreText.text = _score.ToString();
    }
}

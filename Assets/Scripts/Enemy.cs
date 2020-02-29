using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, Time.deltaTime * -_enemySpeed);

        if (transform.position.z < -10f)
        {
            GameManager.instance.ScoreUp();
            Destroy(gameObject);
        }
    }
}

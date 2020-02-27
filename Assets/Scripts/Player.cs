using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 8f;

    private float _xTilt = 2.25f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        transform.Translate(_horizontal * Time.deltaTime * _playerSpeed, 0f, 0f);

        float _positionXRange = Mathf.Clamp(transform.position.x, -_xTilt, _xTilt);
        transform.position = new Vector3(_positionXRange, transform.position.y, transform.position.z);
    }
}

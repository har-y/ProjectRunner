using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 8f;

    private float _xTilt = 2.25f;
    private float _positionXRange;
    private float _horizontal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
#if     UNITY_EDITOR
        {
            _horizontal = Input.GetAxis("Horizontal");
        }
#elif UNITY_STANDALONE_WIN
        {
            _horizontal = Input.GetAxis("Horizontal");
        }
#elif UNITY_ANDROID
        {
            TouchInput();
        }
#endif
        transform.Translate(_horizontal * Time.deltaTime * _playerSpeed, 0f, 0f);

        _positionXRange = Mathf.Clamp(transform.position.x, -_xTilt, _xTilt);
        transform.position = new Vector3(_positionXRange, transform.position.y, transform.position.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameManager.instance.Restart();
        }
    }

    private void TouchInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPosition = Input.mousePosition;
            float screenMiddle = Screen.width / 2;

            if (touchPosition.x < screenMiddle)
            {
                _horizontal = -1;
            }
            else if (touchPosition.x > screenMiddle)
            {
                _horizontal = 1;
            }
        }
    }
}

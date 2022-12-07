using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Movement
{
    [SerializeField] Transform _playerTransform = null;
    private bool _isTouched = true;
    public void setupPlayer(Transform playerTransform) { _playerTransform = playerTransform; _isTouched = false; }

    // Update is called once per frame
    void Update()
    {
        if(_isTouched == false)
        {
            walk(_thisTransform.position - _playerTransform.position);
        }
    }
    public void getTouched()
    {
        _isTouched = true;
    }
}

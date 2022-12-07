using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Movement : MonoBehaviour
{
    protected Transform _thisTransform = null;
    [SerializeField] private float _speed = 2.5f;
    void Start()
    {
        _thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    protected void walk(Vector3 direction)
    {
        _thisTransform.Translate(direction.normalized * Time.deltaTime * _speed);
    }
}

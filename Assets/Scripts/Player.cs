using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movement
{
    private Vector3 _mousePoint = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {

            RaycastHit2D hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, -Vector2.up);
            if (hit.collider != null)
            {
                _mousePoint = hit.point;
                walk(_mousePoint - _thisTransform.position);
            }
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if (horizontal != 0.0f || vertical != 0.0f)
            {
                walk(new Vector3(horizontal, vertical));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy e ) == true)
        {
            e.getTouched();
        }
        Debug.Log(collision);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] private Movement _player = null;
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] private BoxCollider2D _ground = null;
    [SerializeField] private Enemy _enemyPrefab = null;
    void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab, this.transform);
            _enemies.Add(enemy);
            Vector2 extents = _ground.size * 0.5f;
            Vector2 point = new Vector2(Random.Range(-extents.x, extents.x), Random.Range(-extents.y, extents.y));
            enemy.transform.position = point;

            enemy.setupPlayer(_player.transform);



        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}

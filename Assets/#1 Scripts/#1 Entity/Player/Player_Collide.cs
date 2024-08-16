using System;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Player_Collide : MonoBehaviour
{
    private Player _player;
    private Tilemap tilemap;


    public void Start()
    {
        _player = this.GetComponentInParent<Player>();
        tilemap = GameObject.FindGameObjectWithTag("ground").GetComponent<Tilemap>();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {

    }

    public void OnTriggerExit2D(Collider2D other)
    {

    }
}

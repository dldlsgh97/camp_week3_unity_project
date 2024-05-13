using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite;
    private TopDownController _controller;

    private void Awake()
    {
        _controller = GetComponent<TopDownController>();
        
    }
    void Start()
    {
        _controller.OnLookEvent += FlipPlayer;
    }

    private void FlipPlayer(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (Mathf.Abs(rotZ) > 90f)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }
    }
}

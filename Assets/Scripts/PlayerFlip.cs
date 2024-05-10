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
        Debug.Log(Mathf.Abs(rotZ));
        if (Mathf.Abs(rotZ) > 90f)
        {
            playerSprite.flipX = true;
            //transform.localScale = new Vector3(-0.5f, 0.5f, 0);
        }
        else
        {
            playerSprite.flipX = false;
            //transform.localScale = new Vector3(0.5f, 0.5f, 0);
        }
    }
}

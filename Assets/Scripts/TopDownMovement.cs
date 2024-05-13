using UnityEngine;

public class TopDownMovement :MonoBehaviour
{
    private TopDownController movementController;
    private Rigidbody2D movementRigidbody;
    private Animator playerAnim;
    [SerializeField] int playerSpeed = 3;

    

    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        // 같은 게임오브젝트의 TopDownController, Rigidbody를 가져올 것 
        movementController = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        Debug.Log("TopDownMovement Start");
        // OnMoveEvent에 Move를 호출하라고 등록함
        movementController.OnMoveEvent += Move;
        ChangePlayerSprite();

    }
    private void Update()
    {
        ChangePlayerSprite();
    }
    private void FixedUpdate()
    {
        // 물리 업데이트에서 움직임 적용
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        if(direction != Vector2.zero)
        {
            playerAnim.SetBool("isWalk", true);
        }
        else
        {
            playerAnim.SetBool("isWalk", false);
        }
        direction = direction * playerSpeed;

        movementRigidbody.velocity = direction;
    }
    void ChangePlayerSprite()
    {
        if(GameManager.Instance.playerId == -1)
        {
            Debug.Log("Player Penguin");
            playerAnim.SetBool("isPenguin", true);
        }
        else if (GameManager.Instance.playerId == 1)
        {
            Debug.Log("Player Knight");
            playerAnim.SetBool("isPenguin", false);
        }

    }

}

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
        // OnMoveEvent에 Move를 호출하라고 등록함
        movementController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        // 물리 업데이트에서 움직임 적용
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        // 이동방향만 정해두고 실제로 움직이지는 않음.
        // 움직이는 것은 물리 업데이트에서 진행(rigidbody가 물리니까)
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
}

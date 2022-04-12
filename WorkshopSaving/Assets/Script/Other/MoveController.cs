using UnityEngine;

public class MoveController : MonoBehaviour
{
    [Header("General:")]
    public float moveSpeed = 2.5f;
    public Transform toRotateWithX;
    [Header("Movement Restriction:")]
    public bool lockHorizontal = false;
    public bool lockVertical = false;
    [Header("PhysX specifics:")]
    public Collider2D myFeet;
    public Rigidbody2D body2D;
    public float jumpForce = 5.5f;
    private bool isJumping = false;
    [Header("Animations:")]
    public GameObject idle;
    public GameObject walk;
    [Header("Camera follow :")]
    public float XvalueCam = 0f;
    public float YvalueCam = 0f;

    void Update()
    {
        if (!lockHorizontal)
        {
            MoveHorizontal(Input.GetAxis("Horizontal"));
            ChangeAnim(Input.GetAxis("Horizontal"));
        }
        jump();
        CameraFollow();

        if (lockVertical == false) 
            MoveVertical(Input.GetAxis("Vertical"));
    }

    public void CameraFollow()
    {
        Camera.main.transform.position = new Vector3(transform.position.x + XvalueCam, transform.position.y + YvalueCam,Camera.main.transform.position.z);
    }

    public void SetJumpForce(float force){
        jumpForce = force;
    }

    public void ChangeAnim(float direction)
    {
        if (direction == 0)
        {
            idle.SetActive(true);
            walk.SetActive(false);
        }
        else
        {
            idle.SetActive(false);
            walk.SetActive(true);
        }
    }

    public void MoveHorizontal(float direction)
    {
        if (body2D)
        {
            Vector2 newVelocity = body2D.velocity;
            newVelocity.x = direction * moveSpeed;
            body2D.velocity = newVelocity;
        } else
            transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        Flip(direction);
    }

    public void MoveVertical(float direction)
    {
        if (body2D)
        {
            Vector2 newVelocity = body2D.velocity;
            newVelocity.y = direction * moveSpeed;
            body2D.velocity = newVelocity;
        } else
            transform.position += Vector3.up * direction * moveSpeed * Time.deltaTime;
    }

    public void jump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)){

            if (!isJumping && body2D && myFeet && myFeet.IsTouchingLayers())
            {
                isJumping = true;
                body2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            }
        }
        else
        {
            isJumping = false;
        }
    }

    public void Flip(float direction)
    {
        if (!toRotateWithX)
            return;

        if (direction > 0.00)
            toRotateWithX.rotation = Quaternion.Euler(0, 0, 0);
        else if (direction < 0.00)
            toRotateWithX.rotation = Quaternion.Euler(0, -180, 0);
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    //스피드
    public float moveSpeed = 5f;

    private SpriteRenderer playerSprite;
    private Animator anim;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        SetBounds();
    }


    void Update()
    {
        ClampPosition();

        //방향키에따른 움직임
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        // -1 0 1
        if (Input.GetAxis("Horizontal") <= -0.5f) anim.SetBool("Left", true);
        else anim.SetBool("Left", false);

        if (Input.GetAxis("Horizontal") >= 0.5f) anim.SetBool("Right", true);
        else anim.SetBool("Right", false);

        if (Input.GetAxis("Vertical") >= 0.5f) anim.SetBool("Up", true);
        else anim.SetBool("Up", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, pos.position, Quaternion.identity);
        }

        transform.Translate(moveX, moveY, 0);
    }

    void SetBounds()
    {
        minBounds = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void ClampPosition()
    {
        Vector3 playerPos = transform.position;
        Vector2 spriteSize = playerSprite.bounds.extents;

        playerPos.x = Mathf.Clamp(playerPos.x, minBounds.x + spriteSize.x, maxBounds.x - spriteSize.x);
        playerPos.y = Mathf.Clamp(playerPos.y, minBounds.y + spriteSize.y, maxBounds.y - spriteSize.y);

        transform.position = playerPos;
    }
}

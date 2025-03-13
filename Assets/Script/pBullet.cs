using UnityEngine;

public class pBullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;
    public GameObject effect;

    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject go =  Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(go, 1f);
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class BossHead : MonoBehaviour
{
    [SerializeField] private GameObject bossbullet;

    public void RightDownLaunch()
    {
        GameObject go = Instantiate(bossbullet, transform.position, Quaternion.identity);
        go.GetComponent<BossBullet>().Move((new Vector2(1, -1)));
    }

    public void LeftDownLaunch()
    {
        GameObject go = Instantiate(bossbullet, transform.position, Quaternion.identity);
        go.GetComponent<BossBullet>().Move((new Vector2(-1, -1)));
    }

    public void DownLaunch()
    {
        GameObject go = Instantiate(bossbullet, transform.position, Quaternion.identity);
        go.GetComponent<BossBullet>().Move((new Vector2(0, -1)));
    }
}

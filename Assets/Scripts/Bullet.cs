using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float deleteTime = 5.0f;
    public GameObject boms;


    void Start()
    {
        //deketeTime秒後に消える
        Destroy(gameObject, deleteTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        //相手がEnemyタグなら相手を削除
        //相手がEnemyタグならbomsを生成
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Instantiate(boms, other.transform.position, Quaternion.identity);
        }
        //いずれにしても自分を削除
        Destroy(gameObject);
    }



}

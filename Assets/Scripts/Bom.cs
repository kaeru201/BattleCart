using UnityEngine;

public class Bom : MonoBehaviour
{
    public float deleteTime = 3.0f;

    void Start()
    {
        //生成されて数秒後に削除
        Destroy(gameObject, deleteTime);
    }

    
}

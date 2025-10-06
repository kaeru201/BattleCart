using UnityEngine;

public class EnemyController : MonoBehaviour
{
    CharacterController controller;

    Vector3 moveDirection = Vector3.zero;

    public float gravity = 9.81f;

    public float speedZ = -10;
    public float accelerationZ = -8;

    public float deletePosY = -10f;
    public bool useGravity;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        //もしステージ外に落ちたら消滅
        if (transform.position.y <= deletePosY)
        {
            Destroy(gameObject);
            return;
        }

        //徐々に加速しZ方向に常に前進させる
        float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(acceleratedZ, speedZ, 0);

        //もし地面を走るなら
        if (useGravity)
        {
            //重力分の力をフレーム追加
            moveDirection.y -= gravity * Time.deltaTime;
        }
        //もし空を飛ぶなら
        else
        {
            moveDirection.y = 0;
        }

    　　//移動実行
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        //移動後接地していたらY方向の速度はリセットする
        if (controller.isGrounded) moveDirection.y = 0;
    }
}

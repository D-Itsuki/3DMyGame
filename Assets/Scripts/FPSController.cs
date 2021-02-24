using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    /// <summary>動く速さ</summary>
    public float m_movingSpeed;
    /// <summary>ターンの速さ</summary>
    public float m_turnSpeed = 3f;
    /// <summary>ジャンプ力</summary>
    public float m_jumpPower = 5f;
    /// <summary>接地判定の際、中心 (Pivot) からどれくらいの距離を「接地している」と判定するかの長さ</summary>
    [SerializeField] float m_isGroundedLength = 1.1f;

    [SerializeField] int nowHealth;
    int maxHealth;

    public List<ItemBase> items = new List<ItemBase>();

    [SerializeField] Slider hpSlider;

    public Coroutine m_coroutine;
    CapsuleCollider collider;
    CameraController1 camera;

    bool isCrouch = false;

    Rigidbody m_rb = null;

    void Start()
    {
        maxHealth = nowHealth;
        hpSlider.value = maxHealth;
        camera = FindObjectOfType<CameraController1>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        m_rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        // 方向の入力を取得し、方向を求める
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        // 入力方向のベクトルを組み立てる
        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            m_rb.velocity = new Vector3(0f, m_rb.velocity.y, 0f);
        }
        else
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            dir = Camera.main.transform.TransformDirection(dir);    // メインカメラを基準に入力方向のベクトルを変換する
            dir.y = 0;  // y 軸方向はゼロにして水平方向のベクトルにする

            // 入力方向に滑らかに回転させる
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * m_turnSpeed);  // Slerp を使うのがポイント

            Vector3 velo = dir.normalized * m_movingSpeed; // 入力した方向に移動する
            velo.y = m_rb.velocity.y;   // ジャンプした時の y 軸方向の速度を保持する
            m_rb.velocity = velo;   // 計算した速度ベクトルをセットする
        }

        // ジャンプの入力を取得し、接地している時に押されていたらジャンプする
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            m_rb.AddForce(Vector3.up * m_jumpPower, ForceMode.Impulse);
            //m_anim.SetTrigger("Jump");
        }

        //　ダッシュ
        if (Input.GetButtonDown("Fire3"))
        {
            m_movingSpeed *= 2f;
        }
        if (Input.GetButtonUp("Fire3"))
        {
            m_movingSpeed /= 2f;
        }

        //アイテム使用
        if (Input.GetButtonDown("Use"))
        {
            items[0].Use();
        }

        //しゃがみ
        if (Input.GetButtonDown("Fire1") && IsGrounded())
        {
            Debug.Log("しゃがみ");
            isCrouch = true;
            m_movingSpeed /= 2;
            collider.height = 0.7f;
            collider.center = new Vector3(0, 0.45f, 0);
            camera.CrouchCamera();
        }
        if (Input.GetButtonUp("Fire1") && IsGrounded() && isCrouch)
        {
            Debug.Log("立ち");
            isCrouch = false;
            m_movingSpeed *= 2;
            collider.center = new Vector3(0, 0.8f, 0);
            collider.height = 1.7f;
            camera.StandUp();
        }
    }

    /// <summary>
    /// Update の後に呼び出される。Update の結果を元に何かをしたい時に使う。
    /// </summary>
    void LateUpdate()
    {
        // 水平方向の速度を求めて Animator Controller のパラメーターに渡す
        Vector3 horizontalVelocity = m_rb.velocity;
        horizontalVelocity.y = 0;
        //m_anim.SetFloat("Speed", horizontalVelocity.magnitude);
    }

    /// <summary>
    /// 地面に接触しているか判定する
    /// </summary>
    /// <returns></returns>
    bool IsGrounded()
    {
        // Physics.Linecast() を使って足元から線を張り、そこに何かが衝突していたら true とする
        Vector3 start = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z);   // start: オブジェクトの中心
        Vector3 end = start + Vector3.down * m_isGroundedLength;  // end: start から真下の地点
        Debug.DrawLine(start, end); // 動作確認用に Scene ウィンドウ上で線を表示する
        bool isGrounded = Physics.Linecast(start, end); // 引いたラインに何かがぶつかっていたら true とする
        return isGrounded;
    }

    public IEnumerator speedUp()
    {
        Debug.Log("Speed up");
        m_movingSpeed *= 2;
        
        yield return new WaitForSeconds(10);

        m_movingSpeed /= 2;
        Debug.Log("Speed up end");
    }

    public void Damage(string tag )
    {
        if (tag == "Obstacle")
        {
            nowHealth -= 1;
            hpSlider.value = (float)nowHealth / maxHealth;
            Debug.Log(nowHealth);
        }
        else if (tag == "Boss")
        {
            nowHealth = 0;
        }
        

        //死んだらGAMEOVER用のシーンに遷移
        if (nowHealth < 1)
        {
            Debug.Log("GAME OVER");
            hpSlider.value = (float)nowHealth / maxHealth;
            GameManager.m_isGameOver = true;
        }
    }
}

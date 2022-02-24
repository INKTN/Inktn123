using UnityEngine;

/// <summary>
/// 控制器：2D橫向卷軸版本
/// </summary>
public class Controller2D : MonoBehaviour
{
    #region 欄位：公開
    [Header("移動速度"), Range(0, 100)]
    public float speed = 3.5f;
    [Header("跳躍高度"), Range(0, 1500)]
    public float jump = 500;
    [Header("檢查地板尺寸與位移")]
    [Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("跳躍按鍵與可跳躍圖層")]
    public KeyCode keyJump = KeyCode.Space;
    public LayerMask canJumpLayer;

    [Header("動畫參數：走路與跳躍")]
    public string parameterWalk = "走路開關";
    public string parameterJump = "跳躍開關";

    #endregion

    #region 欄位：私人
    private Animator ani;
    /// <summary>
    /// 剛體元件 Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;

    /// <summary>
    /// 繪製圖示
    /// 在 Unity 繪製輔助用的圖示
    ///  線條、射線、圓形、方形、扇形、圖片
    ///  圖示 Gizmos 類別
    /// </summary>
    private void OnDrawGizmos()
    {
        // 1.決定圖示顏色
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        // 2.決定形狀
        // transform.postion 此物件的世界座標
        // transform.TransformDirection() 根據變形元件的區域座標轉換為世界座標
        Gizmos.DrawSphere(transform.position + 
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);
    }

    // 將私人欄位顯示在屬性面板上
    [SerializeField]

    /// <summary>是否在地板上 
    ///
    /// </summary>
    private void CheckGround() 
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius, canJumpLayer);

        print("碰到的物件名稱：" + hit.name);
    }


    #endregion

    #region 事件
    private void Start()
    {
        // 剛體欄位 = 取得元件<2D 剛體>()
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    #endregion

    /// <summary>
    ///  Update 約 60 FPS
    ///  固定更新事件 50 FPS
    ///  處理物理行為
    /// </summary>
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {

        Flip();
        CheckGround();
    }


    #region 方法 想測試加速度調整
    /// <summary>
    /// 1.玩家是否有按移動按鍵 左右方向鍵 或 A、D
    /// 2.物件移動行為(API)
    /// </summary>
    private void Move()
    {
        // h 值 指定為 輸入.取得軸向(水平軸) - 水平軸代表左右鍵與AD
        float h = Input.GetAxis("Horizontal");
        print("玩家左右按鍵值：" + h);

        // 剛體元件.加速度 = 新 二維向量(h 值 * 移動速度, 剛體.加速度.垂直);
        rig.velocity = new Vector2(h * speed, rig.velocity.y);

        ani.SetBool(parameterWalk, h != 0);
    }

    /// <summary>
    /// 翻面:
    /// 左 角度 Y 180 h值<0
    /// 右 角度 Y 0   h值>0
    /// </summary>
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");

        //如果h<0 左 角度 Y180
        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        //如果h>0 右 角度 Y 0
        else if (h > 0)
        {
            transform.eulerAngles = Vector3.zero;

        }

    }


    #endregion



    
    
    


}

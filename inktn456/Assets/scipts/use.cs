using UnityEngine;

public class use : MonoBehaviour
{
    #region
    [Header("檢查追蹤區域大小與位移")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3Trackoffset;
    [Header("目標圖層")]
    public LayerMask layerTarget;
    #endregion




    #region 事件
    private void OnDrawGizmos()
    {
        // 指定圖示的顏色
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        // 繪製立方體(中心,尺寸)
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3Trackoffset), v3TrackSize);
    }


    #endregion

    private void Update()
    {
        CheckTargetInArea();    
    }


    #region
    /// <summary>
    /// 檢查目標是否在區域內 
    /// </summary>
    private void CheckTargetInArea()
    {
        // 2D 物理.覆蓋盒形(中心,尺寸,角度)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3Trackoffset), v3TrackSize, 0, layerTarget);

        if (hit) print(hit.name);



    }




    #endregion
}

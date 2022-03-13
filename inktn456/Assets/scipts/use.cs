using UnityEngine;

public class use : MonoBehaviour
{
    #region
    [Header("�ˬd�l�ܰϰ�j�p�P�첾")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3Trackoffset;
    [Header("�ؼйϼh")]
    public LayerMask layerTarget;
    #endregion




    #region �ƥ�
    private void OnDrawGizmos()
    {
        // ���w�ϥܪ��C��
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        // ø�s�ߤ���(����,�ؤo)
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3Trackoffset), v3TrackSize);
    }


    #endregion

    private void Update()
    {
        CheckTargetInArea();    
    }


    #region
    /// <summary>
    /// �ˬd�ؼЬO�_�b�ϰ줺 
    /// </summary>
    private void CheckTargetInArea()
    {
        // 2D ���z.�л\����(����,�ؤo,����)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3Trackoffset), v3TrackSize, 0, layerTarget);

        if (hit) print(hit.name);



    }




    #endregion
}

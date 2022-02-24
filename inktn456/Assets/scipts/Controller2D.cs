using UnityEngine;

/// <summary>
/// ����G2D��V���b����
/// </summary>
public class Controller2D : MonoBehaviour
{
    #region ���G���}
    [Header("���ʳt��"), Range(0, 100)]
    public float speed = 3.5f;
    [Header("���D����"), Range(0, 1500)]
    public float jump = 500;
    [Header("�ˬd�a�O�ؤo�P�첾")]
    [Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("���D����P�i���D�ϼh")]
    public KeyCode keyJump = KeyCode.Space;
    public LayerMask canJumpLayer;

    [Header("�ʵe�ѼơG�����P���D")]
    public string parameterWalk = "�����}��";
    public string parameterJump = "���D�}��";

    #endregion

    #region ���G�p�H
    private Animator ani;
    /// <summary>
    /// ���餸�� Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;

    /// <summary>
    /// ø�s�ϥ�
    /// �b Unity ø�s���U�Ϊ��ϥ�
    ///  �u���B�g�u�B��ΡB��ΡB���ΡB�Ϥ�
    ///  �ϥ� Gizmos ���O
    /// </summary>
    private void OnDrawGizmos()
    {
        // 1.�M�w�ϥ��C��
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        // 2.�M�w�Ϊ�
        // transform.postion �����󪺥@�ɮy��
        // transform.TransformDirection() �ھ��ܧΤ��󪺰ϰ�y���ഫ���@�ɮy��
        Gizmos.DrawSphere(transform.position + 
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);
    }

    // �N�p�H�����ܦb�ݩʭ��O�W
    [SerializeField]

    /// <summary>�O�_�b�a�O�W 
    ///
    /// </summary>
    private void CheckGround() 
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius, canJumpLayer);

        print("�I�쪺����W�١G" + hit.name);
    }


    #endregion

    #region �ƥ�
    private void Start()
    {
        // ������� = ���o����<2D ����>()
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    #endregion

    /// <summary>
    ///  Update �� 60 FPS
    ///  �T�w��s�ƥ� 50 FPS
    ///  �B�z���z�欰
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


    #region ��k �Q���ե[�t�׽վ�
    /// <summary>
    /// 1.���a�O�_�������ʫ��� ���k��V�� �� A�BD
    /// 2.���󲾰ʦ欰(API)
    /// </summary>
    private void Move()
    {
        // h �� ���w�� ��J.���o�b�V(�����b) - �����b�N���k��PAD
        float h = Input.GetAxis("Horizontal");
        print("���a���k����ȡG" + h);

        // ���餸��.�[�t�� = �s �G���V�q(h �� * ���ʳt��, ����.�[�t��.����);
        rig.velocity = new Vector2(h * speed, rig.velocity.y);

        ani.SetBool(parameterWalk, h != 0);
    }

    /// <summary>
    /// ½��:
    /// �� ���� Y 180 h��<0
    /// �k ���� Y 0   h��>0
    /// </summary>
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");

        //�p�Gh<0 �� ���� Y180
        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        //�p�Gh>0 �k ���� Y 0
        else if (h > 0)
        {
            transform.eulerAngles = Vector3.zero;

        }

    }


    #endregion



    
    
    


}

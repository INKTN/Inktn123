using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    [Header("���ƪ�����")]
    public Image imgScore;
    [Header("����")]
    public float Score = 10;

    private float Score10;

    private void Awake()
    {
        Score10 = Score;
    }

    // minus=��
    public void minus(float used)
    {
        Score -= used;
        imgScore.fillAmount = Score / Score10;
    }
}

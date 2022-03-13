using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    [Header("分數長條圖")]
    public Image imgScore;
    [Header("分數")]
    public float Score = 10;

    private float Score10;

    private void Awake()
    {
        Score10 = Score;
    }

    // minus=減
    public void minus(float used)
    {
        Score -= used;
        imgScore.fillAmount = Score / Score10;
    }
}

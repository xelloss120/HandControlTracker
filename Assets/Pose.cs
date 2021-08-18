using UnityEngine;
using UnityEngine.UI;

public class Pose : MonoBehaviour
{
    public InputField InputField;

    public Vector3 HipsPos;
    public Vector3 LegLeftPos;
    public Vector3 LegRightPos;

    public Quaternion HipsRot;
    public Quaternion LegLeftRot;
    public Quaternion LegRightRot;

    [SerializeField] Transform Head;
    [SerializeField] Transform HeadDummy;
    [SerializeField] Transform Hips;
    [SerializeField] Transform LegLeft;
    [SerializeField] Transform LegRight;

    [SerializeField] Text PoseText;
    [SerializeField] Button LearnButton;

    public void OnClickPose()
    {
        // 頭と垂直軸だけ合わせたダミーを用意してコレを親とした位置と回転を適用
        HeadDummy.position = Head.position;
        HeadDummy.eulerAngles = new Vector3(0, Head.eulerAngles.y, 0);

        Hips.position = HeadDummy.TransformPoint(HipsPos);
        Hips.rotation = HeadDummy.rotation * HipsRot;

        LegLeft.position = HeadDummy.TransformPoint(LegLeftPos);
        LegLeft.rotation = HeadDummy.rotation * LegLeftRot;

        LegRight.position = HeadDummy.TransformPoint(LegRightPos);
        LegRight.rotation = HeadDummy.rotation * LegRightRot;

        // Marker経由でVMTオブジェクトへ遅延処理で適用
        Hips.gameObject.SetActive(true);
        LegLeft.gameObject.SetActive(true);
        LegRight.gameObject.SetActive(true);

        Invoke("DelayMethod", 0.1f);
    }

    void DelayMethod()
    {
        // VMTオブジェクトへの反映が完了したのでMarkerオブジェクトを無効化
        Hips.gameObject.SetActive(false);
        LegLeft.gameObject.SetActive(false);
        LegRight.gameObject.SetActive(false);
    }

    public void OnClickLearn()
    {
        // 頭と垂直軸だけ合わせたダミーを用意してコレを親とした位置と回転を記憶
        HeadDummy.position = Head.position;
        HeadDummy.eulerAngles = new Vector3(0, Head.eulerAngles.y, 0);
        
        var rotation = Quaternion.Inverse(HeadDummy.rotation);

        HipsPos = HeadDummy.InverseTransformPoint(Hips.position);
        HipsRot = rotation * Hips.rotation;

        LegLeftPos = HeadDummy.InverseTransformPoint(LegLeft.position);
        LegLeftRot = rotation * LegLeft.rotation;

        LegRightPos = HeadDummy.InverseTransformPoint(LegRight.position);
        LegRightRot = rotation * LegRight.rotation;
    }

    public void ChangedInputField()
    {
        PoseText.text = InputField.text;
    }

    public void OnClickSwitch()
    {
        LearnButton.interactable = !LearnButton.interactable;
    }
}

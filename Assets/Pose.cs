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

    [SerializeField] Transform HeadY;
    [SerializeField] Transform Hips;
    [SerializeField] Transform LegLeft;
    [SerializeField] Transform LegRight;

    [SerializeField] Text PoseText;
    [SerializeField] Button LearnButton;

    public void OnClickPose()
    {
        // 頭と垂直軸だけ合わせたオブジェクトを親とした位置と回転を適用
        Hips.position = HeadY.TransformPoint(HipsPos);
        Hips.rotation = HeadY.rotation * HipsRot;

        LegLeft.position = HeadY.TransformPoint(LegLeftPos);
        LegLeft.rotation = HeadY.rotation * LegLeftRot;

        LegRight.position = HeadY.TransformPoint(LegRightPos);
        LegRight.rotation = HeadY.rotation * LegRightRot;
    }

    public void OnClickLearn()
    {
        // 頭と垂直軸だけ合わせたオブジェクトを親とした位置と回転を記憶
        var rotation = Quaternion.Inverse(HeadY.rotation);

        HipsPos = HeadY.InverseTransformPoint(Hips.position);
        HipsRot = rotation * Hips.rotation;

        LegLeftPos = HeadY.InverseTransformPoint(LegLeft.position);
        LegLeftRot = rotation * LegLeft.rotation;

        LegRightPos = HeadY.InverseTransformPoint(LegRight.position);
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

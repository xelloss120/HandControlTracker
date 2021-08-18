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

    void Ready()
    {
        // 頭と垂直軸だけ合わせたダミーを用意
        HeadDummy.position = Head.position;
        HeadDummy.eulerAngles = new Vector3(0, Head.eulerAngles.y, 0);

        // 腰と足をダミーの子に設定
        Hips.parent = HeadDummy;
        LegLeft.parent = HeadDummy;
        LegRight.parent = HeadDummy;
    }

    public void OnClickPose()
    {
        Ready();
        Invoke("DelayMethodPose1", 0.1f);
    }

    void DelayMethodPose1()
    {
        // ダミーの子にした状態でMarkerを経由してVMTオブジェクトに遅延処理で反映
        Hips.localPosition = HipsPos;
        Hips.localRotation = HipsRot;

        LegLeft.localPosition = LegLeftPos;
        LegLeft.localRotation = LegLeftRot;

        LegRight.localPosition = LegRightPos;
        LegRight.localRotation = LegRightRot;

        Hips.gameObject.SetActive(true);
        LegLeft.gameObject.SetActive(true);
        LegRight.gameObject.SetActive(true);

        Invoke("DelayMethodPose2", 0.1f);
    }

    void DelayMethodPose2()
    {
        // VMTオブジェクトへの反映が完了したのでMarkerオブジェクトを無効化
        Hips.gameObject.SetActive(false);
        LegLeft.gameObject.SetActive(false);
        LegRight.gameObject.SetActive(false);

        // ハンドコントローラでの操作に備えて親子関係を解除
        Hips.parent = null;
        LegLeft.parent = null;
        LegRight.parent = null;
    }

    public void OnClickLearn()
    {
        Ready();
        Invoke("DelayMethodLearn", 0.1f);
    }

    void DelayMethodLearn()
    {
        // ダミーの子にした状態が反映されたMarkerの位置と回転を覚えてから
        HipsPos = Hips.localPosition;
        HipsRot = Hips.localRotation;

        LegLeftPos = LegLeft.localPosition;
        LegLeftRot = LegLeft.localRotation;

        LegRightPos = LegRight.localPosition;
        LegRightRot = LegRight.localRotation;

        // ハンドコントローラでの操作に備えて親子関係を解除
        Hips.parent = null;
        LegLeft.parent = null;
        LegRight.parent = null;
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

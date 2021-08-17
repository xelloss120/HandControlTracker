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
        HeadDummy.position = Head.position;
        HeadDummy.eulerAngles = new Vector3(0, Head.eulerAngles.y, 0);

        Hips.parent = HeadDummy;
        LegLeft.parent = HeadDummy;
        LegRight.parent = HeadDummy;

        Invoke("DelayMethodPose1", 0.1f);
    }

    void DelayMethodPose1()
    {
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
        Hips.gameObject.SetActive(false);
        LegLeft.gameObject.SetActive(false);
        LegRight.gameObject.SetActive(false);

        Hips.parent = null;
        LegLeft.parent = null;
        LegRight.parent = null;
    }

    public void OnClickLearn()
    {
        HeadDummy.position = Head.position;
        HeadDummy.eulerAngles = new Vector3(0, Head.eulerAngles.y, 0);

        Hips.parent = HeadDummy;
        LegLeft.parent = HeadDummy;
        LegRight.parent = HeadDummy;

        Invoke("DelayMethodLearn", 0.1f);
    }

    void DelayMethodLearn()
    {
        HipsPos = Hips.localPosition;
        HipsRot = Hips.localRotation;

        LegLeftPos = LegLeft.localPosition;
        LegLeftRot = LegLeft.localRotation;

        LegRightPos = LegRight.localPosition;
        LegRightRot = LegRight.localRotation;

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

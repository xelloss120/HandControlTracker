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

    [SerializeField] Text PoseText;
    [SerializeField] Button LearnButton;

    public void OnClickPose()
    {
        Debug.Log("OnClickPose" + PoseText.text);
    }

    public void OnClickLearn()
    {
        Debug.Log("OnClickLearn" + PoseText.text);
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

using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject Pose;
    [SerializeField] GameObject Edit;
    [SerializeField] GameObject Offset;

    public void Main()
    {
        Pose.SetActive(true);
        Edit.SetActive(false);
        Offset.SetActive(false);
    }

    public void PoseEdit()
    {
        Pose.SetActive(true);
        Edit.SetActive(true);
        Offset.SetActive(false);
    }

    public void InitSettings()
    {
        Pose.SetActive(false);
        Edit.SetActive(false);
        Offset.SetActive(true);
    }
}

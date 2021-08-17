using System.IO;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] Pose Pose1;
    [SerializeField] Pose Pose2;
    [SerializeField] Pose Pose3;
    [SerializeField] Pose Pose4;
    [SerializeField] Pose Pose5;

    [SerializeField] Offset Offset1;
    [SerializeField] Offset Offset2;
    [SerializeField] Offset Offset3;
    [SerializeField] Offset Offset4;
    [SerializeField] Offset Offset5;

    void Awake()
    {
        int i = 0;
        var txt = File.ReadAllText("Settings.txt");
        var line = txt.Split('\n');

        SetPose(Pose1, line[i++]);
        SetPose(Pose2, line[i++]);
        SetPose(Pose3, line[i++]);
        SetPose(Pose4, line[i++]);
        SetPose(Pose5, line[i++]);

        Offset1.Value = float.Parse(line[i++]);
        Offset2.Value = float.Parse(line[i++]);
        Offset3.Value = float.Parse(line[i++]);
        Offset4.Value = float.Parse(line[i++]);
        Offset5.Value = float.Parse(line[i++]);
    }

    void OnDestroy()
    {
        var txt = "";

        txt += GetPoseString(Pose1) + "\n";
        txt += GetPoseString(Pose2) + "\n";
        txt += GetPoseString(Pose3) + "\n";
        txt += GetPoseString(Pose4) + "\n";
        txt += GetPoseString(Pose5) + "\n";

        txt += Offset1.Value + "\n";
        txt += Offset2.Value + "\n";
        txt += Offset3.Value + "\n";
        txt += Offset4.Value + "\n";
        txt += Offset5.Value + "\n";

        File.WriteAllText("Settings.txt", txt);
    }

    void SetPose(Pose pose, string str)
    {
        int i = 0;
        var p = str.Split(',');

        pose.InputField.text = p[i++];

        pose.HipsPos = new Vector3(float.Parse(p[i++]), float.Parse(p[i++]), float.Parse(p[i++]));
        pose.LegLeftPos = new Vector3(float.Parse(p[i++]), float.Parse(p[i++]), float.Parse(p[i++]));
        pose.LegRightPos = new Vector3(float.Parse(p[i++]), float.Parse(p[i++]), float.Parse(p[i++]));

        pose.HipsRot = new Quaternion(float.Parse(p[i++]), float.Parse(p[i++]), float.Parse(p[i++]), float.Parse(p[i++]));
        pose.LegLeftRot = new Quaternion(float.Parse(p[i++]), float.Parse(p[i++]), float.Parse(p[i++]), float.Parse(p[i++]));
        pose.LegRightRot = new Quaternion(float.Parse(p[i++]), float.Parse(p[i++]), float.Parse(p[i++]), float.Parse(p[i++]));
    }

    string GetPoseString(Pose pose)
    {
        var str = "";
        str += pose.InputField.text + ",";
        str += GetVector3String(pose.HipsPos);
        str += GetVector3String(pose.LegLeftPos);
        str += GetVector3String(pose.LegRightPos);
        str += GetQuaternionString(pose.HipsRot);
        str += GetQuaternionString(pose.LegLeftRot);
        str += GetQuaternionString(pose.LegRightRot);
        return str;
    }

    string GetVector3String(Vector3 vector3)
    {
        var str = "";
        str += vector3.x + ",";
        str += vector3.y + ",";
        str += vector3.z + ",";
        return str;
    }

    string GetQuaternionString(Quaternion quaternion)
    {
        var str = "";
        str += quaternion.x + ",";
        str += quaternion.y + ",";
        str += quaternion.z + ",";
        str += quaternion.w + ",";
        return str;
    }
}

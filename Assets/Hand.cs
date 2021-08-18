using UnityEngine;
using EasyLazyLibrary;

public class Hand : MonoBehaviour
{
    enum HandType
    {
        L,
        R
    }

    [SerializeField] HandType Type;
    [SerializeField] Transform Hips;
    [SerializeField] Transform LegLeft;
    [SerializeField] Transform LegRight;

    ulong Button;
    ulong PreButton;

    Vector3 Position;
    Vector3 PositionHips;
    Vector3 PositionLegLeft;
    Vector3 PositionLegRight;

    Quaternion Rotation;
    Quaternion RotationHips;
    Quaternion RotationLegLeft;
    Quaternion RotationLegRight;

    EasyOpenVRUtil EasyOpenVRUtil;

    void Start()
    {
        EasyOpenVRUtil = new EasyOpenVRUtil();
        EasyOpenVRUtil.StartOpenVR();
    }

    void Update()
    {
        EasyOpenVRUtil.Init();
        EasyOpenVRUtil.AutoExitOnQuit();

        if (Type == HandType.L)
        {
            EasyOpenVRUtil.GetControllerButtonPressed(EasyOpenVRUtil.GetLeftControllerIndex(), out Button);
        }
        else
        {
            EasyOpenVRUtil.GetControllerButtonPressed(EasyOpenVRUtil.GetRightControllerIndex(), out Button);
        }

        if (Button != 0)
        {
            // コントローラボタン押下時の位置と回転を記憶
            if (PreButton != Button)
            {
                Position = transform.position;
                PositionHips = Hips.position;
                PositionLegLeft = LegLeft.position;
                PositionLegRight = LegRight.position;

                Rotation = transform.rotation;
                RotationHips = Hips.rotation;
                RotationLegLeft = LegLeft.rotation;
                RotationLegRight = LegRight.rotation;
            }

            // コントローラボタン押下時からの移動量と回転量を有効な対象へ反映
            if (Hips.gameObject.activeInHierarchy)
            {
                Hips.position = PositionHips - (Position - transform.position);
                Hips.rotation = (transform.rotation * Quaternion.Inverse(Rotation)) * RotationHips;
            }
            if (LegLeft.gameObject.activeInHierarchy)
            {
                LegLeft.position = PositionLegLeft - (Position - transform.position);
                LegLeft.rotation = (transform.rotation * Quaternion.Inverse(Rotation)) * RotationLegLeft;
            }
            if (LegRight.gameObject.activeInHierarchy)
            {
                LegRight.position = PositionLegRight - (Position - transform.position);
                LegRight.rotation = (transform.rotation * Quaternion.Inverse(Rotation)) * RotationLegRight;
            }
        }
        PreButton = Button;
    }
}

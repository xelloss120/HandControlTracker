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

    EasyOpenVRUtil eou;

    void Start()
    {
        eou = new EasyOpenVRUtil();
        eou.StartOpenVR();
    }

    void Update()
    {
        eou.Init();
        eou.AutoExitOnQuit();

        if (Type == HandType.L)
        {
            eou.GetControllerButtonPressed(eou.GetLeftControllerIndex(), out Button);
        }
        else
        {
            eou.GetControllerButtonPressed(eou.GetRightControllerIndex(), out Button);
        }

        if (Button != 0)
        {
            if (PreButton != Button)
            {
                // コントローラボタン押下時の位置を記憶
                Position = transform.position;
                PositionHips = Hips.position;
                PositionLegLeft = LegLeft.position;
                PositionLegRight = LegRight.position;

                // コントローラボタン押下時の回転を記憶
                Rotation = transform.rotation;
                RotationHips = Hips.rotation;
                RotationLegLeft = LegLeft.rotation;
                RotationLegRight = LegRight.rotation;
            }

            // コントローラボタン押下時からの移動量を有効な対象へ反映
            Hips.position = Hips.gameObject.activeInHierarchy ? PositionHips - (Position - transform.position) : PositionHips;
            LegLeft.position = LegLeft.gameObject.activeInHierarchy ? PositionLegLeft - (Position - transform.position) : PositionLegLeft;
            LegRight.position = LegRight.gameObject.activeInHierarchy ? PositionLegRight - (Position - transform.position) : PositionLegRight;

            // コントローラボタン押下時からの回転量を有効な対象へ反映
            Hips.rotation = Hips.gameObject.activeInHierarchy ? (transform.rotation * Quaternion.Inverse(Rotation)) * RotationHips : RotationHips;
            LegLeft.rotation = LegLeft.gameObject.activeInHierarchy ? (transform.rotation * Quaternion.Inverse(Rotation)) * RotationLegLeft : RotationLegLeft;
            LegRight.rotation = LegRight.gameObject.activeInHierarchy ? (transform.rotation * Quaternion.Inverse(Rotation)) * RotationLegRight : RotationLegRight;
        }
        PreButton = Button;
    }
}

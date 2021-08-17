using System;
using UnityEngine;
using EasyLazyLibrary;

public class GetTransform : MonoBehaviour
{
    [SerializeField] GameObject Head;
    [SerializeField] GameObject HandLeft;
    [SerializeField] GameObject HandRight;

    [SerializeField] GameObject Tracker0;
    [SerializeField] GameObject Tracker1;
    [SerializeField] GameObject Tracker2;

    [SerializeField] string Tracker0Name;
    [SerializeField] string Tracker1Name;
    [SerializeField] string Tracker2Name;

    [SerializeField] EasyOpenVROverlayForUnity EasyOpenVROverlayForUnity;

    EasyOpenVRUtil EasyOpenVRUtil;

    DateTime DateTime;

    void Start()
    {
        EasyOpenVRUtil = new EasyOpenVRUtil();
        EasyOpenVRUtil.StartOpenVR();
    }

    void Update()
    {
        EasyOpenVRUtil.Init();
        EasyOpenVRUtil.AutoExitOnQuit();

        var head = EasyOpenVRUtil.GetHMDTransform();
        var handL = EasyOpenVRUtil.GetLeftControllerTransform();
        var handR = EasyOpenVRUtil.GetRightControllerTransform();

        var tracker0 = EasyOpenVRUtil.GetTransformBySerialNumber(Tracker0Name);
        var tracker1 = EasyOpenVRUtil.GetTransformBySerialNumber(Tracker1Name);
        var tracker2 = EasyOpenVRUtil.GetTransformBySerialNumber(Tracker2Name);

        EasyOpenVRUtil.SetGameObjectLocalTransform(ref Head, head);
        EasyOpenVRUtil.SetGameObjectLocalTransform(ref HandLeft, handL);
        EasyOpenVRUtil.SetGameObjectLocalTransform(ref HandRight, handR);

        EasyOpenVRUtil.SetGameObjectLocalTransform(ref Tracker0, tracker0);
        EasyOpenVRUtil.SetGameObjectLocalTransform(ref Tracker1, tracker1);
        EasyOpenVRUtil.SetGameObjectLocalTransform(ref Tracker2, tracker2);

        if (head != null && handL != null && handR != null)
        {
            var center = (handL.position + handR.position) / 2;
            if (Vector3.Distance(center, head.position) < 0.1f &&
                Vector3.Distance(handL.position, handR.position) < 0.4f)
            {
                TimeSpan ts = DateTime.Now - DateTime;
                if (ts.Seconds > 1)
                {
                    // 両手を頭に寄せた状態が、前回から1秒以上経過していれば、オーバーレイの表示を切り替え
                    EasyOpenVROverlayForUnity.show = !EasyOpenVROverlayForUnity.show;
                }
                DateTime = DateTime.Now;
            }
        }
    }
}

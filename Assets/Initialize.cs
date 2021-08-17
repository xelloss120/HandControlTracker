using UnityEngine;

public class Initialize : MonoBehaviour
{
    [SerializeField] GameObject Head;

    [SerializeField] GameObject VMT_0;
    [SerializeField] GameObject VMT_1;
    [SerializeField] GameObject VMT_2;

    [SerializeField] GameObject Tracker0;
    [SerializeField] GameObject Tracker1;
    [SerializeField] GameObject Tracker2;

    [SerializeField] GameObject Marker0;
    [SerializeField] GameObject Marker1;
    [SerializeField] GameObject Marker2;

    [SerializeField] Offset OffsetHeadHips;
    [SerializeField] Offset OffsetHipsLeg;
    [SerializeField] Offset OffsetLegWidth;
    [SerializeField] Offset OffsetHipsDepth;
    [SerializeField] Offset OffsetLegDepth;

    public void Init()
    {
        // 頭から垂直軸だけ合わせてオフセットを付けた位置に腰を配置
        var pos = Head.transform.position;
        pos.y -= OffsetHeadHips.Value;
        pos += Head.transform.forward * OffsetHipsDepth.Value;

        VMT_0.transform.position = pos;
        VMT_0.transform.eulerAngles = new Vector3(0, Head.transform.eulerAngles.y, 0);

        // 足は腰の子にして位置と回転を遅延処理で適用
        VMT_1.transform.parent = VMT_0.transform;
        VMT_2.transform.parent = VMT_0.transform;

        // 腰から回転なしにオフセットを付けた位置に足を配置
        VMT_1.transform.localPosition = new Vector3(-OffsetLegWidth.Value / 2, -OffsetHipsLeg.Value, OffsetLegDepth.Value);
        VMT_2.transform.localPosition = new Vector3(+OffsetLegWidth.Value / 2, -OffsetHipsLeg.Value, OffsetLegDepth.Value);

        VMT_1.transform.localRotation = Quaternion.identity;
        VMT_2.transform.localRotation = Quaternion.identity;

        Invoke("DelayMethod1", 0.1f);
    }

    void DelayMethod1()
    {
        // ここでOVR Advanced Settingsのオフセットを吸収したい
        // 足は腰の子になっているので腰だけで吸収する
        // 遅延処理とした結果、VMTとOpenVRで取得したトラッカーの差をOVR Advanced Settingsのオフセットとする
        // この差を再度VMTに設定して、さらにもう一度遅延処理

        var pos = VMT_0.transform.position;
        pos += pos - Tracker0.transform.position;
        VMT_0.transform.position = pos;

        Invoke("DelayMethod2", 0.1f);
    }

    void DelayMethod2()
    {
        // 最初の処理から見てVMT->Tracker->Markerの関係で
        // トラッカー操作用オブジェクトに位置と回転を適用
        Marker0.transform.position = Tracker0.transform.position;
        Marker0.transform.rotation = Tracker0.transform.rotation;
        Marker1.transform.position = Tracker1.transform.position;
        Marker1.transform.rotation = Tracker1.transform.rotation;
        Marker2.transform.position = Tracker2.transform.position;
        Marker2.transform.rotation = Tracker2.transform.rotation;

        // トラッカー操作用オブジェクトにOVR Advanced Settingsのオフセットを設定
        Marker0.GetComponent<Marker>().Offset = VMT_0.transform.position - Tracker0.transform.position;
        Marker1.GetComponent<Marker>().Offset = VMT_1.transform.position - Tracker1.transform.position;
        Marker2.GetComponent<Marker>().Offset = VMT_2.transform.position - Tracker2.transform.position;

        // 足の親を腰からnullにして解除
        VMT_1.transform.parent = null;
        VMT_2.transform.parent = null;
    }
}

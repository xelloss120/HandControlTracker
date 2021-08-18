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
        // 頭の向き（垂直軸のみ）を適用
        var direction = new Vector3(0, Head.transform.eulerAngles.y, 0);
        VMT_0.transform.eulerAngles = direction;
        VMT_1.transform.eulerAngles = direction;
        VMT_2.transform.eulerAngles = direction;

        // 頭のオフセットを適用
        VMT_0.transform.position = Head.transform.position;
        VMT_0.transform.position -= Vector3.up * OffsetHeadHips.Value;
        VMT_0.transform.position += VMT_0.transform.forward * OffsetHipsDepth.Value;

        // 足のオフセットを適用
        VMT_1.transform.position = Head.transform.position;
        VMT_1.transform.position -= (Vector3.up * OffsetHeadHips.Value) + (Vector3.up * OffsetHipsLeg.Value);
        VMT_1.transform.position += VMT_0.transform.forward * OffsetLegDepth.Value;

        VMT_2.transform.position = VMT_1.transform.position;

        VMT_1.transform.position -= VMT_0.transform.right * OffsetLegWidth.Value / 2;
        VMT_2.transform.position += VMT_0.transform.right * OffsetLegWidth.Value / 2;

        Invoke("DelayMethod1", 0.1f);
    }

    void DelayMethod1()
    {
        // ここでOVR Advanced Settingsのオフセットを吸収したい
        // VMTオブジェクトと取得したトラッカーオブジェクトの差をOVR Advanced Settingsのオフセットとする
        VMT_0.transform.position += VMT_0.transform.position - Tracker0.transform.position;
        VMT_1.transform.position += VMT_1.transform.position - Tracker1.transform.position;
        VMT_2.transform.position += VMT_2.transform.position - Tracker2.transform.position;

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
    }
}

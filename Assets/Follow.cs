using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform HeadY;
    [SerializeField] Transform Marker0;
    [SerializeField] Transform Marker1;
    [SerializeField] Transform Marker2;

    bool state = false;

    public void OnClick()
    {
        state = !state;

        if (state)
        {
            Marker0.parent = HeadY;
            Marker1.parent = HeadY;
            Marker2.parent = HeadY;
        }
        else
        {
            Marker0.parent = null;
            Marker1.parent = null;
            Marker2.parent = null;
        }
    }
}

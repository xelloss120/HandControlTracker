using UnityEngine;
using UnityEngine.UI;

public class Ctrl : MonoBehaviour
{
    [SerializeField] Image Hips;
    [SerializeField] Image LegLeft;
    [SerializeField] Image LegRight;

    [SerializeField] Marker MarkerHips;
    [SerializeField] Marker MarkerLegLeft;
    [SerializeField] Marker MarkerLegRight;

    public void OnClickHips()
    {
        Hips.color = new Color(1, 0.5f, 0.5f);
        LegLeft.color = new Color(1, 1, 1);
        LegRight.color = new Color(1, 1, 1);

        MarkerHips.Active = true;
        MarkerLegLeft.Active = false;
        MarkerLegRight.Active = false;
    }

    public void OnClickLegLeft()
    {
        Hips.color = new Color(1, 1, 1);
        LegLeft.color = new Color(1, 0.5f, 0.5f);
        LegRight.color = new Color(1, 1, 1);

        MarkerHips.Active = false;
        MarkerLegLeft.Active = true;
        MarkerLegRight.Active = false;
    }

    public void OnClickLegRight()
    {
        Hips.color = new Color(1, 1, 1);
        LegLeft.color = new Color(1, 1, 1);
        LegRight.color = new Color(1, 0.5f, 0.5f);

        MarkerHips.Active = false;
        MarkerLegLeft.Active = false;
        MarkerLegRight.Active = true;
    }

    public void OnClickNone()
    {
        Hips.color = new Color(1, 1, 1);
        LegLeft.color = new Color(1, 1, 1);
        LegRight.color = new Color(1, 1, 1);

        MarkerHips.Active = false;
        MarkerLegLeft.Active = false;
        MarkerLegRight.Active = false;
    }
}

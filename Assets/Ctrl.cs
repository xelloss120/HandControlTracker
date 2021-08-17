using UnityEngine;
using UnityEngine.UI;

public class Ctrl : MonoBehaviour
{
    [SerializeField] Image Hips;
    [SerializeField] Image LegLeft;
    [SerializeField] Image LegRight;

    [SerializeField] GameObject MarkerHips;
    [SerializeField] GameObject MarkerLegLeft;
    [SerializeField] GameObject MarkerLegRight;

    public void OnClickHips()
    {
        Hips.color = new Color(1, 0.5f, 0.5f);
        LegLeft.color = new Color(1, 1, 1);
        LegRight.color = new Color(1, 1, 1);

        MarkerHips.SetActive(true);
        MarkerLegLeft.SetActive(false);
        MarkerLegRight.SetActive(false);
    }

    public void OnClickLegLeft()
    {
        Hips.color = new Color(1, 1, 1);
        LegLeft.color = new Color(1, 0.5f, 0.5f);
        LegRight.color = new Color(1, 1, 1);

        MarkerHips.SetActive(false);
        MarkerLegLeft.SetActive(true);
        MarkerLegRight.SetActive(false);
    }

    public void OnClickLegRight()
    {
        Hips.color = new Color(1, 1, 1);
        LegLeft.color = new Color(1, 1, 1);
        LegRight.color = new Color(1, 0.5f, 0.5f);

        MarkerHips.SetActive(false);
        MarkerLegLeft.SetActive(false);
        MarkerLegRight.SetActive(true);
    }

    public void OnClickNone()
    {
        Hips.color = new Color(1, 1, 1);
        LegLeft.color = new Color(1, 1, 1);
        LegRight.color = new Color(1, 1, 1);

        MarkerHips.SetActive(false);
        MarkerLegLeft.SetActive(false);
        MarkerLegRight.SetActive(false);
    }
}

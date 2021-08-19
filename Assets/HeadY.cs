using UnityEngine;

public class HeadY : MonoBehaviour
{
    [SerializeField] Transform Head;

    Vector3 Angle = Vector3.zero;

    void Update()
    {
        transform.position = Head.position;
        Angle.y = Head.eulerAngles.y;
        transform.eulerAngles = Angle;
    }
}

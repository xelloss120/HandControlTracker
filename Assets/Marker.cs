using UnityEngine;

public class Marker : MonoBehaviour
{
    [SerializeField] Transform VMT;

    public Vector3 Offset;

    public bool Active = false;

    void Update()
    {
        VMT.position = transform.position + Offset;
        VMT.rotation = transform.rotation;
    }
}

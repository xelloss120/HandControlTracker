using UnityEngine;
using uOSC;

public class Tracker : MonoBehaviour
{
    [SerializeField] uOscClient uOscClient;

    [SerializeField] string address;
    [SerializeField] int index;
    [SerializeField] int enable;
    [SerializeField] float timeoffset;

    void Update()
    {
        uOscClient.Send(address, (int)index, (int)enable, (float)timeoffset,
            (float)transform.position.x,
            (float)transform.position.y,
            (float)transform.position.z,
            (float)transform.rotation.x,
            (float)transform.rotation.y,
            (float)transform.rotation.z,
            (float)transform.rotation.w
        );
    }
}

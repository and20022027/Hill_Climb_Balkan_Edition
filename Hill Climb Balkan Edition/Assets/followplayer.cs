using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform Sasija;
    public Vector2 offset;

    void Update()
    {
        transform.position = Sasija.position;
    }
}

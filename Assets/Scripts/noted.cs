using UnityEngine;

public class noted : MonoBehaviour
{
    public int laneIndex;
    public float speed = 5f;     // kecepatan turun
    public float destroyY = -6f; // batas bawah layar

    void Update()
    {
        // gerak turun (smooth, FPS independent)
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // hancur kalau lewat batas
        if (transform.position.y <= destroyY)
        {
            Destroy(gameObject);
        }
    }   
}

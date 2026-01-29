using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    public int maxHp = 100;
    public int hpSekarang;
    public int damage = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpSekarang = maxHp;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        hpSekarang -= damage;
        if (hpSekarang < 0)
        {
            Debug.Log("Player Mati");
        }
        Debug.Log("Player Hp sekarang: " + hpSekarang);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            hpSekarang += 10;
        } else if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Player Health: " + hpSekarang);
        }
    }
}

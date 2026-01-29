using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public int maxHp = 50;
    public int currentHp;
    public int damage = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if(currentHp < 0)
        {
            Debug.Log("Enemy Mati");
        }
        Debug.Log("Enemy Hp sekarang: " + currentHp);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        } else if(Input.GetKeyDown(KeyCode.H))
        {
            currentHp += 10;
        }
    }
}

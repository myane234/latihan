
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Image healthBarImage;
    public float maxHealth = 100f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkMati();

        if (Input.GetKeyDown(KeyCode.T))
        {
            takeDamage(10f); // contoh panggil takeDamage
            Debug.Log($"Darah: {maxHealth}");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            heal(10f); // contoh panggil heal
            Debug.Log($"Darah: {maxHealth}");
        }
        
    }

    void checkMati()
    {
        if(maxHealth <= 0)
        {
            Debug.Log($"Sudah mati: {maxHealth}");
        }
    }

    public void takeDamage(float damage)
    {
        maxHealth -= damage; // max health di kurangin ama damage
        healthBarImage.fillAmount = maxHealth / 100f; // ngatur fill amount health bar
    }

    public void heal(float jumlahHeal)
    {
        maxHealth += jumlahHeal; // max health di tambah ama heal
        maxHealth = Mathf.Clamp(maxHealth, 0f, 100f); // nge clamp max health supaya ga lebih dari 100

        healthBarImage.fillAmount = maxHealth / 100f; // ngatur fill amount health bar
    }
}

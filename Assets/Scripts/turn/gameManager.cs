
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public Player player;
    public Enemy Enemy;
    public Transform PlayerSprite;
    public Transform EnemySprite;
    public GameObject bulletPrefab;
    public Transform SpawnBullet;
    public float bulletSpeeed = 20f;

    enum TurnState
    {
        Player_turn,
        Enemy_turn,
        Game_over
    }

    TurnState TurnSekarang;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnSekarang = TurnState.Player_turn;
        Debug.Log("Turn Sekarang: " + TurnSekarang);
    }

    // Update is called once per frame
    void Update()
    {
        if(TurnSekarang == TurnState.Enemy_turn)
        {
            Debug.Log("Giliran Musuh");
            EnemyTurn();
        } else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                PlayerAttack(); 
            }
        }
    }

    public void PlayerAttack()
    {
        if (TurnSekarang != TurnState.Player_turn) return;

        Debug.Log("PLayer Menyerang");
        shotutil.Shoot(bulletPrefab, SpawnBullet, bulletSpeeed);
        Enemy.TakeDamage(player.damage);

        if (Enemy.currentHp <= 0)
        {
            TurnSekarang = TurnState.Game_over;
            Debug.Log("Musuh Kalah! Game Over");
            Destroy(EnemySprite.gameObject);
        }
        TurnSekarang = TurnState.Enemy_turn;
    }

    void EnemyTurn()
    {
        if (TurnSekarang != TurnState.Enemy_turn) return;

        Debug.Log("Enemy Menyerang");
        player.TakeDamage(Enemy.damage);

        if (player.hpSekarang < 0)
        {
            TurnSekarang = TurnState.Game_over;
            Debug.Log("Player Kalah! Game Over");
        }
        else
        {
            TurnSekarang = TurnState.Player_turn;
            Debug.Log("Turn Sekarang: " + TurnSekarang);
        }
        TurnSekarang = TurnState.Player_turn;
    }
}
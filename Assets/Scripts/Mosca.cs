using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mosca : MonoBehaviour
{
    Vector3 initialPosition;

    int coinsCount = 0;
    public int lives = 3;
    public TextMeshProUGUI txtLives;
    public TextMeshProUGUI txtCoins;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        txtLives.text = "Vidas " + lives;
        txtCoins.text = "Monedas: " + coinsCount;
    }

    private void Update()
    {
    }


    //Destruir la mosca si colisiona con el ventilador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damager"))
        {
            PlayerDeath();
        } else if (collision.gameObject.CompareTag("Coin"))
        {
            ScoreCoin(collision.gameObject);
        } 
    }

    void PlayerDeath()
    {
        transform.position = initialPosition;
        lives--;
        txtLives.text = "Vidas " + lives;

        if (lives == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void ScoreCoin(GameObject gameObject)
    {
        coinsCount++;
        txtCoins.text = "Monedas: " + coinsCount;
        Destroy(gameObject);
    }
}

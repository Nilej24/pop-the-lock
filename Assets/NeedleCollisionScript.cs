using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleCollisionScript : MonoBehaviour
{
    private bool onCoin = false;
    private bool canFail = false;
    public NeedleRotateScript needleRotate;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.OnCoinHit += OnCoinHit;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {

            if (gameManager.starting) {
                gameManager.Play();
                return;
            }

            if (!gameManager.playing) return;

            if (onCoin) {

                needleRotate.ChangeDirection();
                gameManager.OnCoinHit();

            } else {

                gameManager.GameOver();

            }

        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.name == "Coin")
        {
            onCoin = true;
            canFail = true;

        }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.gameObject.name == "Coin")
        {
            onCoin = false;
            if (canFail) gameManager.GameOver();
        }
	}

    private void OnCoinHit()
    {
        canFail = false;
    }

}

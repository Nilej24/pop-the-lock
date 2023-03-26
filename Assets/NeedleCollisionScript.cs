using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

            UseTestFunc("hi", "from unity c#");

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

    // react test
    [DllImport("__Internal")]
    private static extern void TestFunc(string text1, string text2);

    private void UseTestFunc(string text1, string text2) {
        #if UNITY_WEBGL == true && UNITY_EDITOR == false
            TestFunc(text1, text2);
        #endif
    }

}

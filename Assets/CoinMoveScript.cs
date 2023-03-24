using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMoveScript : MonoBehaviour
{
    public GameManager gameManager;
    public NeedleRotateScript needleRotate;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.OnCoinHit += OnCoinHit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCoinHit()
    {
        // move to new location
        if (gameManager.count == 0) return;

        // get angle in opposite direction between 45 and 180
        float angle = Random.Range(45, 100);
        if (needleRotate.clockwise) angle = -angle;

        // rotate
        transform.Rotate(0, 0, angle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleRotateScript : MonoBehaviour
{
    public bool clockwise = true;
    public float rotateSpeed = -50;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.OnCoinHit += OnCoinHit;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.playing)
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    public void ChangeDirection() {
        clockwise = !clockwise;
    }

    private void OnCoinHit() {

        // increase speed
        rotateSpeed = Mathf.Abs(rotateSpeed) + 2;
        // put in right direction
        if (clockwise) rotateSpeed = -rotateSpeed;

    }

}

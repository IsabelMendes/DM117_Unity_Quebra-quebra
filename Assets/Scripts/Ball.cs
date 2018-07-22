using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    //Referncia para o som da bola
    AudioSource ballkAudioSource;

    //Referencia para o rigidbody da bola
    Rigidbody2D ballRG;

    //Refernecia para a plataforma
    Paddle padle;

    //Referencia para a cruz
    CrossHair crossHair;

    //posicao inicia da bola
    Vector3 offset = new Vector3(0f, 0.6f, 0f);

	// Use this for initialization
	void Start () {
        ballkAudioSource = GetComponent<AudioSource>();
        ballRG = GetComponent <Rigidbody2D>();
        ballRG.isKinematic = true;
        padle = FindObjectOfType<Paddle>();
        crossHair = FindObjectOfType<CrossHair>();

 

    }
	
	// Update is called once per frame
	void Update () {
        if (!LevelControl.hasGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                LaunhBall();
            }
            else {
                MoveWithPadle();
            }
            
        }
        
	}
    void MoveWithPadle()  {
        transform.position = padle.transform.position + offset;

    }

    //metodo para lancar a bola
    void LaunhBall() {
        Vector2 ballDirection = (crossHair.transform.position - transform.position);
        ballDirection.Normalize();
        ballRG.isKinematic = false;
        ballRG.AddForce(ballDirection * 15, ForceMode2D.Impulse);
        LevelControl.hasGameStarted = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballkAudioSource.Play();
    }
}

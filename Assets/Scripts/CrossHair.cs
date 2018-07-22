using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour {

    //Referencia para o componente LineRendesr
    LineRenderer crossHLineRender;

    //referencia para a bola
    Ball ball;

    //Velocidade para mover o crossHair
    float crossHairSpeed = 7.0f;

	// Use this for initialization
	void Start () {
        crossHLineRender = GetComponent<LineRenderer>();
        ball = FindObjectOfType<Ball>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (LevelControl.hasGameStarted) {
            gameObject.SetActive(false);
        } else {
            ConfigureLine();
        }
		
	}
    //metodo para configurar a posicao da cruz e tambem a linha entre a bola e a cruz.
    void ConfigureLine()
    {
        float translationX = Input.GetAxis("Horizontal") * Time.deltaTime * crossHairSpeed;
        float translationY = Input.GetAxis("Vertical") * Time.deltaTime * crossHairSpeed;
        transform.Translate(translationX, translationY, 0);
        crossHLineRender.SetPosition(0, ball.transform.position);
        crossHLineRender.SetPosition(1, transform.position);
    }
}

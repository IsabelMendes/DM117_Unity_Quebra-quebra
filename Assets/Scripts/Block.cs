using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {

    [SerializeField]
    Sprite[] damagSprites;

    AudioSource blockAudioSource;
    //Referencia para o sprite render
    SpriteRenderer blockSpriteRender;

    //referencia para o score text
    [SerializeField]
    GameObject scoreText;

    Canvas canvas;

    int maxHits;
    int numHits;


	// Use this for initialization
	void Start () {
        maxHits = damagSprites.Length + 1;
        blockAudioSource = GetComponent<AudioSource>();
        blockSpriteRender = GetComponent<SpriteRenderer>();
        canvas = FindObjectOfType<Canvas>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //detectar colisao com bola
    public void OnCollisionEnter2D(Collision2D collision) {
        HandleDamage();
    }
    //Metado para tratar colisao no bloco
    public void HandleDamage() {
        AudioSource.PlayClipAtPoint(blockAudioSource.clip, Camera.main.transform.position);
        numHits++;
        if (numHits >= maxHits)
        {
            SpawncoreText();
            Destroy(gameObject);
        } else {
            blockSpriteRender.sprite = damagSprites[numHits - 1];
        }
        
    }
       void SpawncoreText()
    {
        GameObject scoreTextClone = Instantiate(scoreText, transform.position, transform.rotation, canvas.transform);
        Text text = scoreTextClone.GetComponentInChildren<Text>();

        text.color = blockSpriteRender.color;
        text.text = (maxHits * 20).ToString();
        Destroy(scoreTextClone, 2.0f);

    }
}

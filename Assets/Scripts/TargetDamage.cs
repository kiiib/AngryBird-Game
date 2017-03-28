using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDamage : MonoBehaviour {

    public int hitPoints = 2;
    public Sprite damagedSprite;
    public float damageImpactSpeed;
    public AudioSource killBirdAudio;

    private int currentHitPoints;
    private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;
    private float timer = 0;  //countdown time
    private bool isKilled = false;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHitPoints = hitPoints;
        damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;

    }
	void Update(){
        if (isKilled) {
            timer += Time.deltaTime;
            Debug.Log(timer);
            //Debug.Log(Application.loadedLevelName);
            if(timer > 1.1) {
                //Debug.Log("time out");
                if (Application.loadedLevelName == "FirstScene") {
                    Application.LoadLevel("SecondScene");
                } else {
                    Application.LoadLevel("FirstScene");
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Damager")
            return;
        if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
            return;

        spriteRenderer.sprite = damagedSprite;
        currentHitPoints--;

        if (currentHitPoints <= 0)
            Kill();
    }

    void Kill()
    {
        GameObject.Find("PlayerLife").GetComponent<PlayerLife>().lifeVolume = 3;
        spriteRenderer.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
        killBirdAudio.Play();
        isKilled = true;
    }
}

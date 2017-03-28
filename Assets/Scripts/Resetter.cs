using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour {
    public Rigidbody2D projectile;
    public float resetSpeed = 0.025f;
    //public GameObject PlayerLife;

    private float resetSpeedSqr;
    private SpringJoint2D spring;
    
	// Use this for initialization
	void Start () {
        if (GameObject.Find("PlayerLife").GetComponent<PlayerLife>().lifeVolume <= 0)
        {
            GameObject.Find("DeadText").SetActive(true);
        }else
        {
            GameObject.Find("DeadText").SetActive(false);
        }
        
        resetSpeedSqr = resetSpeed * resetSpeed;
        spring = projectile.GetComponent<SpringJoint2D>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            GameObject.Find("PlayerLife").GetComponent<PlayerLife>().lifeVolume = 3;
            Reset();
        }

        if(spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr) {
            Reset();
        }
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<Rigidbody2D>() == projectile) {
            
           
            GameObject.Find("PlayerLife").GetComponent<PlayerLife>().lifeVolume--;
            //Debug.Log(GameObject.Find("PlayerLife").GetComponent<PlayerLife>().lifeVolume);
            Reset();
        }
    }

    void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

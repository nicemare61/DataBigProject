using System;
using System.Collections;
using System.Collections.Generic;
using Searching;
using UnityEngine;

public class SpeedSkill : MonoBehaviour
{
    private float speed = 4.5f;
    [SerializeField]
    private GameObject[] floorPrefab;
    OOPPlayer oopPlayer;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private bool currentSideSkill;
    // Start is called before the first frame update
    
    // Update is called once per frame
    private void Start()
    {
       oopPlayer = GameObject.Find("Player").GetComponent<OOPPlayer>();
       if (oopPlayer.isRight)
       {
           currentSideSkill = true;
       }
       else if(oopPlayer.isRight == false)
       {
           currentSideSkill = false;
       }
    }

    void Update()
    {
        if (currentSideSkill == false)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
            spriteRenderer.flipX = true;
        }
        else if(currentSideSkill)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionTrigger2D(Collision2D other)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Debug.Log("Hit Enemy");
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}

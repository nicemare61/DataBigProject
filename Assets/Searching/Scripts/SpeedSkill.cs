using System;
using System.Collections;
using System.Collections.Generic;
using Searching;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedSkill : MonoBehaviour
{
    private float speed = 4.5f;
    [SerializeField]
    private GameObject[] floorPrefab;
    OOPPlayer oopPlayer;
    
    [SerializeField] private Element element;
    [SerializeField] private bool isLargeSkill;
    
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
        if (!currentSideSkill && !isLargeSkill)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
            spriteRenderer.flipX = true;
        }
        else if(currentSideSkill && !isLargeSkill)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Enemy")
        {
            Destroy(this.gameObject);
            
            if (other.GetComponent<Character>().element == element)
            {
                other.GetComponent<Character>().TakeDamage(10);
            }
            else if (other.GetComponent<Character>().element == Element.Fire && element == Element.Plant ||
                     other.GetComponent<Character>().element == Element.Plant && element == Element.Water ||
                     other.GetComponent<Character>().element == Element.Water && element == Element.Fire)
            {
                other.GetComponent<Character>().TakeDamage(5);
            }
            else if (other.GetComponent<Character>().element == Element.Plant && element == Element.Fire ||
                     other.GetComponent<Character>().element == Element.Water && element == Element.Plant ||
                     other.GetComponent<Character>().element == Element.Fire && element == Element.Water)
            {
                other.GetComponent<Character>().TakeDamage(20);
            }
        }

        if (other.transform.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}

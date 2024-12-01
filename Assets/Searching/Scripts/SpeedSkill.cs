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
    private OOPMapGenerator oopMapGenerator;
    private int hpSkill = 1;
    private Vector3 playerPos;

    private bool currentSideSkill;
    // Start is called before the first frame update
    
    // Update is called once per frame
    private void Start()
    {
       oopPlayer = GameObject.Find("Player").GetComponent<OOPPlayer>();
       playerPos = GameObject.Find("Player").transform.position;
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
        CheckSkill();
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
        oopMapGenerator = GameObject.Find("MapController").GetComponent<OOPMapGenerator>();
        int waveNow = oopMapGenerator.waveCount;
        int waveNext = 2;
        if (waveNow == waveNext && isLargeSkill)
        {
            Destroy(this.gameObject);
            waveNext++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckSkill();
        if (other.transform.tag == "Enemy")
        {
            Destroy(this.gameObject);

            if (other.GetComponent<Character>().element == element && hpSkill == 1)
            {
                other.GetComponent<Character>().TakeDamage(10);
                hpSkill--;
            }
            else if ((other.GetComponent<Character>().element == Element.Fire && element == Element.Plant ||
                      other.GetComponent<Character>().element == Element.Plant && element == Element.Water ||
                      other.GetComponent<Character>().element == Element.Water && element == Element.Fire) &&
                     hpSkill == 1)
            {
                other.GetComponent<Character>().TakeDamage(5);
                hpSkill--;
            }
            else if ((other.GetComponent<Character>().element == Element.Plant && element == Element.Fire ||
                      other.GetComponent<Character>().element == Element.Water && element == Element.Plant ||
                      other.GetComponent<Character>().element == Element.Fire && element == Element.Water)
                     && hpSkill == 1)
            {
                other.GetComponent<Character>().TakeDamage(20);
                hpSkill--;
            }
        }

        if (other.transform.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

    void CheckSkill()
    {
        if (hpSkill <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

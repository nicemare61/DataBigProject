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
        if (waveNow == waveNext && isLargeSkill )
        {
            Destroy(this.gameObject);
            waveNext++;
        }

        if (playerPos != oopPlayer.transform.position)
        {
            Destroy(this.gameObject);
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

            if (hpSkill == 1)
            {
                other.GetComponent<Character>()
                    .TakeDamage(ElementDamage(5, other.GetComponent<Character>().element, element));
                hpSkill--;
            }

            if (hpSkill == 0)
            {
                Destroy(this.gameObject);
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
    public int ElementDamage(int Damage ,Element Attack, Element Defense)
    {
        switch (Attack)
        { case Element.Fire:
                switch (Defense)
                { case Element.Water:
                        Damage = Damage / 2;
                        break;
                    case Element.Plant:
                        Damage = Damage * 2;
                        break; }
                break;
            case Element.Plant:
                switch (Defense)
                { case Element.Fire:
                        Damage = Damage / 2;
                        break;
                    case Element.Water:
                        Damage = Damage * 2;
                        break; }
                break;
            case Element.Water:
                switch (Defense)
                { case Element.Plant:
                        Damage = Damage / 2;
                        break;
                    case Element.Fire:
                        Damage = Damage * 2;
                        break; }
                break; }
        /*
        if ((Attack == Element.Fire && Defense == Element.Water) ||
            (Attack == Element.Water && Defense == Element.Plant) ||
            (Attack == Element.Plant && Defense == Element.Fire))
        {
            Damage = Damage / 2;
        }
        else if ((Attack == Element.Fire && Defense == Element.Plant) ||
            (Attack == Element.Water && Defense == Element.Fire) ||
            (Attack == Element.Plant && Defense == Element.Water))
        {
            Damage = Damage * 2;
        }
        */
        return Damage;
    }
}

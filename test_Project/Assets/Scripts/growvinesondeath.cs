using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growvinesondeath : MonoBehaviour
{
    private Health healthscript;
    public GameObject boss;
    private float bosshealth;
    private Animator anim;
    public Sprite postgrow;
    public SpriteRenderer spriterenderer;
    // Start is called before the first frame update
    void Start()
    {
        healthscript = boss.GetComponent<Health>();
        anim = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bosshealth = healthscript.healthfull;
        if (bosshealth <= 0)
        {
            anim.Play("grow");
            Invoke("ChangeSprite", 0.66f);
        }
    }
    void ChangeSprite()
    {
        
        spriterenderer.sprite = postgrow;
        Debug.Log("grow");
    }
}

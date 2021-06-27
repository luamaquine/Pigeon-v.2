using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField] private float spellSpeed;
    [SerializeField] private GameObject projetil;
    [SerializeField] private GameObject flash;
    [SerializeField] private float flashSize;
    [SerializeField] private float flashCD;
    [SerializeField] private float spellCD;
    [SerializeField] private Slider ultimateBar;
    [SerializeField] private int maxCharge;
    private Rigidbody2D rig;
    private GameObject flashPos;
    private FlashLine flashLine;
    private GameObject linePos;
    private GameObject wand;
    private BoxCollider2D lineBox;
    private CanFlash canFlash;
    private Vector2 dir;
    private float timeLastFlash;
    private float timeLastSpell;
    private float timeRegenMana;
    private int chargeUlt;
    
    public int damage;

    private void Start()
    {
        timeLastFlash = flashCD;
        timeLastSpell = spellCD;
        dir = Vector2.right;
        rig = GetComponent<Rigidbody2D>();
        ultimateBar.value = (float) chargeUlt / maxCharge;
        flashPos = gameObject.transform.GetChild(1).gameObject;
        canFlash = gameObject.transform.GetChild(1).gameObject.GetComponent<CanFlash>();
        linePos = gameObject.transform.GetChild(2).gameObject;
        flashLine = gameObject.transform.GetChild(2).gameObject.GetComponent<FlashLine>();
        
        lineBox = linePos.GetComponent<BoxCollider2D>();
        lineBox.size = new Vector2(1, flashSize);
    }

    private void Update()
    {
        if (rig.velocity != Vector2.zero)
            dir = rig.velocity.normalized;
        
        flashPos.transform.localPosition = dir * flashSize;
        linePos.transform.localPosition = dir * flashSize/2;
        float angulo = AnguloEntreDoisPontos(transform.position,linePos.transform.position); 
        linePos.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,angulo+90));
        if (timeLastSpell < spellCD) timeLastSpell += Time.deltaTime;
        if (timeLastFlash < flashCD) timeLastFlash += Time.deltaTime;

        timeRegenMana += Time.deltaTime;
        if(timeRegenMana > 1)
        {
            timeRegenMana = 0;
            GetCharge(3);
        }
    }

    private float AnguloEntreDoisPontos(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    public void Spell()
    {
        if(timeLastSpell >= spellCD){
            GameObject spell = Instantiate(projetil);
            spell.transform.position = transform.position;
            FindObjectOfType<AudioManager>().Play("PlayerGun");
            spell.GetComponent<Rigidbody2D>().velocity = dir * spellSpeed;
            spell.GetComponent<Projetil>().damage = damage;
            timeLastSpell = 0;
        }
    }

    public void Flash()
    {
        if (canFlash.canFlash && flashLine.canFlash && timeLastFlash >= flashCD)
        {
            GameObject flashAnim1= Instantiate(flash);
            flashAnim1.transform.position = transform.position;
            GameObject flashAnim2 = Instantiate(flash);
            FindObjectOfType<AudioManager>().Play("Teleport");
            flashAnim2.transform.position = flashPos.transform.position;
            transform.position = flashPos.transform.position;
            timeLastFlash = 0;
        }
    }

    public void GetCharge(int chargeAmount)
    {
        if(chargeUlt + chargeAmount < maxCharge)
            chargeUlt += chargeAmount;
        else
        {
            chargeUlt = maxCharge;
        }
        ultimateBar.value = (float) chargeUlt / maxCharge;
    }
    
    public void Ultimate()
    {
        if(chargeUlt >= maxCharge){
            GameObject spell = Instantiate(projetil);
            spell.transform.position = transform.position;
            spell.GetComponent<Rigidbody2D>().velocity = dir * spellSpeed;
            spell.GetComponent<Projetil>().damage = damage*5;
            FindObjectOfType<AudioManager>().Play("Ultimate");
            spell.transform.localScale = Vector3.one*(float) 0.5;
            chargeUlt = 0;
            ultimateBar.value = (float) chargeUlt / maxCharge;
        }
    }
    
}

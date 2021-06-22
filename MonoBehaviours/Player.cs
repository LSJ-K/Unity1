using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public HealthBar healthBarPrefab;
    HealthBar healthBar;

    private void Start()
    {
        hitPoints.value = startingHitPointer;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item hitObject = collision.gameObject.GetComponent<Consumable>()?.item;
        //print("1. Hit : " + hitObject);
        if (hitObject != null)
        {
            print("2. Hit : " + hitObject.objectName);
            if (hitObject.itemType == Item.ItemType.HEALTH)
            {
                AdjustHitPoint(hitObject.quantity) ;
            }
            collision.gameObject.SetActive(false);
        }
    }

    private void AdjustHitPoint(int quantity)
    {
        hitPoints.value += quantity;
        if (hitPoints.value > maxHitPoints)
        {
            hitPoints.value = maxHitPoints;
        }
        print("추가되는 체력 값 : " + quantity + "\n새로운 체력 값 : " + hitPoints.value);
    }
}

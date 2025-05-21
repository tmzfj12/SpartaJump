using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemSO : ScriptableObject
{
   public string itemName;
   public Sprite itemIcon;
   public string itemDescription;
   
   public enum ItemType { Health, Speed}
   public ItemType itemType;

   public float effectValue;
   public float duration;



}

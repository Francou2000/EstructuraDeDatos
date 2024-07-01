using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIndexData", menuName = "Data/IndexData")]

public class IndexObjectData: ScriptableObject
{
    [SerializeField] ObjType objType;
    [SerializeField] EnemyRange enemyRange;
    [SerializeField] BulletOwner bulletOwner;
    [SerializeField] BulletDamage bulletDamage;
    [SerializeField] PowerUpEffect powerUpEffect;

    [SerializeField] Sprite mySprite;

    public ObjType ObjType => objType;
    public EnemyRange EnemyRange => enemyRange;
    public BulletOwner BulletOwner => bulletOwner;
    public BulletDamage BulletDamage => bulletDamage;
    public PowerUpEffect PowerUpEffect => powerUpEffect;
    public Sprite MySprite => mySprite;
}

public enum ObjType
{
    Enemy,
    PowerUp,
    Bullet
}

public enum EnemyRange
{
    None,
    Melee,
    Range
}

public enum BulletOwner
{
    None,
    Ally,
    Enemy
}

public enum BulletDamage
{
    None,
    Weak,
    Strong
}

public enum PowerUpEffect
{
    None,
    Heal,
    Invencible,
    Damage
}
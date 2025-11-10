using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells")]

public class SpellScriptableObject : ScriptableObject
{
    public float ManaCost = 5f;
    public float Lifetime = 2f;
    public float Speed = 15f;
    public float Damage = 3f;
    public float SpellRadius = 0.5f;




}

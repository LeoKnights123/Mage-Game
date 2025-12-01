using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells")]



public class SpellScriptableObject : ScriptableObject
{
    public float damageAmount = 25f;
    public float manaCost = 10f;
    public float lifetime = 2f;
    public float speed = 15f;
    public float spellRadius = 0.5f;

}

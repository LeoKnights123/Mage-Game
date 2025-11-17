using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]private float maxHealth = 50f;
    public float currentHealth;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageToApply)
    {
        Debug.Log(currentHealth);
        
        
        currentHealth -= damageToApply;
        
        if (currentHealth  <=0 ) Destroy(this.gameObject);
    }
}

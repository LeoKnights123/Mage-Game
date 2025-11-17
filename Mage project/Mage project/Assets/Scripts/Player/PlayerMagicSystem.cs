using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    [SerializeField] private Spell spellToCast;


    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana = 100f;
    [SerializeField] private float manaRechargeRate = 10f;
    [SerializeField] private float timeToWaitForRecharge = 1f;
    [SerializeField] private float currentManaRechargeTimer;
    [SerializeField] private float timeBetweenCasts = 0.25f;
    [SerializeField] private Transform castPoint;
    private float currentCastTimer;

    private bool castingMagic = false;

    private InputSystem_Actions playerControls;


    private void Awake()
    {
        playerControls = new InputSystem_Actions();
        currentMana = maxMana;

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();



    }
    private void Update()
    {
        bool isSpellCastHeldDown = playerControls.Player.SpellCast.ReadValue<float>() > 0.1;
        bool hasEnoughMana = currentMana - spellToCast.SpellToCast.ManaCost >= 0f;

        if (!castingMagic && isSpellCastHeldDown && hasEnoughMana)
        {
            castingMagic = true;
            currentMana -= spellToCast.SpellToCast.ManaCost;
            currentCastTimer = 0;
            currentManaRechargeTimer = 0;
            CastSpell();
        }

        if (castingMagic)
        {
            currentCastTimer += Time.deltaTime;
            
            if (currentCastTimer > timeBetweenCasts) castingMagic = false;
        }

        if (currentMana < maxMana && !castingMagic && !isSpellCastHeldDown)

        {
            currentManaRechargeTimer += Time.deltaTime;
            
            if (currentManaRechargeTimer > timeToWaitForRecharge)
            {
                if (currentMana > maxMana) currentMana = maxMana;
                currentMana += manaRechargeRate * Time.deltaTime;
            }
            
            
        }  
        
        
        

        
    }



    void CastSpell()
    {
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
    }
}




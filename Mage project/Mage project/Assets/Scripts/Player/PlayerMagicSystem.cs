using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{

    [SerializeField]private Spell spellToCast;

    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 10f;
    [SerializeField] private float timeToWaitForRecharge = 1f;
    [SerializeField] private float currentManaRechargerTimer;
    [SerializeField] private float timeBetweenCasts = 0.25f;
    private float currentCastTimer;

    [SerializeField] private Transform castPoint;

    private PlayerControlls playerControlls;

    private bool castingmagic = false;


    void Awake()
    {
        playerControlls = new PlayerControlls();
        currentMana = maxMana;

    }

    private void OnEnable()
    {
        playerControlls.Enable();
    }



    private void OnDisable()
    {
        playerControlls.Disable();
    }



    private void Update()
    {
        bool isSpellcastHeldDown = playerControlls.Controls.Spellcast.ReadValue<float>() > 0f;
        bool hasEnoughMana = currentMana - spellToCast.SpellToCast.manaCost >= 0f;

        if (!castingmagic && isSpellcastHeldDown && hasEnoughMana)
        {
            castingmagic = true;
            currentMana -= spellToCast.SpellToCast.manaCost;
            currentCastTimer = 0f;
            currentManaRechargerTimer = 0;
            Castspell();
            
        }

        if (castingmagic)
        {
            currentCastTimer += Time.deltaTime;
            if (currentCastTimer > timeBetweenCasts) castingmagic = false;
        }

        if (currentMana < maxMana && !castingmagic && !isSpellcastHeldDown)
        {
            currentManaRechargerTimer += Time.deltaTime;

            if (currentManaRechargerTimer > timeToWaitForRecharge)
            {
                currentMana += manaRechargeRate * Time.deltaTime;
                if (currentMana > maxMana) currentMana = maxMana;
            }

            
        }
    }

    void Castspell()
    {
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
    }
}

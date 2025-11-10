using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    [SerializeField] private Spell spellToCast;

    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float mamaRechargeRate = 2f;
    [SerializeField] private float timeBetweenCasts = 0.25f;
    [SerializeField] private Transform castPoint;
    private float currentCastTimer;

    private bool castingMagic = false;

    private InputSystem_Actions playerControls;


    private void Awake()
    {
        playerControls = new InputSystem_Actions();

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

        if (!castingMagic && isSpellCastHeldDown)
        {
            castingMagic = true;
            currentCastTimer = 0;
            CastSpell();
        }

        if (castingMagic)
        {
            currentCastTimer += Time.deltaTime;
            
            if (currentCastTimer > timeBetweenCasts) castingMagic = false;
        }
    }



    void CastSpell()
    {
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
    }
}




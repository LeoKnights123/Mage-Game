using UnityEngine;


[RequireComponent(typeof(SphereCollider))]

public class Spell : MonoBehaviour
{
    public SpellScriptableObject SpellToCast;

    private SphereCollider myCollider;
    private Rigidbody myRigidbody;


    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = SpellToCast.SpellRadius;


        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        Destroy(this.gameObject, SpellToCast.Lifetime);

    }



    private void Update()
    {
        if (SpellToCast.Speed > 0) transform.Translate(transform.forward * SpellToCast.Speed * Time.deltaTime);
    }



    private void OnTriggerEnter(Collider other)
    {
        //apply the spell effect to what we hit
        //apply hit particle effects
        //sound effects
        Destroy(this.gameObject);
    }
}

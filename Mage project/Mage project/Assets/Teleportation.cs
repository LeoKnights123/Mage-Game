using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class Teleportation : MonoBehaviour
{
    public GameObject Teleport1;
    public GameObject Teleport2;
    public bool cooldown;
    public TMP_Text scoreText;
    public int score;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == Teleport1 && !cooldown)
        {
            this.gameObject.transform.position = Teleport2.transform.position;
            cooldown = true;
            StartCoroutine(timer());
            score += 1;
            scoreText.SetText("APPLES = "+ score);
        }
        else if (collision.gameObject == Teleport2 && !cooldown)
        {
            this.gameObject.transform.position = Teleport1.transform.position;
            cooldown = true;
            StartCoroutine(timer());
        }
    }

    public IEnumerator timer()
    {
        yield return new WaitForSeconds(2);
        cooldown = false;
    }


    
}
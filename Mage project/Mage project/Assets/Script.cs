using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Script : MonoBehaviour


{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello world");
    }

    public GameObject cube;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("you pressed E");
        }
        if (Input.GetKey(KeyCode.W))
        {

            cube.transform.Translate(0, 0, 0);
        }

    }
}

           



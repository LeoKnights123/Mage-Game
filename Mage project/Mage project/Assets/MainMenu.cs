using UnityEngine;
using UnityEngine.SceneManagement;
public class NewMonoBehaviourScript : MonoBehaviour
{

    public void startButton()
    {
        SceneManager.LoadScene("MagePortal");
    }

    public void Options()
    {



    }

    public void Quit()
    {
        
        Application.Quit();


    }
       
    
      
   
}


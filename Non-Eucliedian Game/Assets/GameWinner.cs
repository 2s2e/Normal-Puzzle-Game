using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinner : MonoBehaviour
{
    public GameObject hint;
    public GameObject hint1;
    public GameObject hint2;
    public GameObject blindingLight;
    public Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVariables.blueGemFilled && GlobalVariables.greenGemFilled && GlobalVariables.yellowGemFilled)
        {
            hint.SetActive(false);
            hint1.SetActive(false);
            hint2.SetActive(false);
            InvokeRepeating("IncreaseBrightness", 0.02f, 0.02f);
            Invoke("GameWin", 3.0f);
        }
    }

    void GameWin()
    {
        SceneManager.LoadScene(1);
    }

    void IncreaseBrightness()
    {
        Light light = blindingLight.GetComponent<Light>();
        light.intensity += 0.2f;
    }
}

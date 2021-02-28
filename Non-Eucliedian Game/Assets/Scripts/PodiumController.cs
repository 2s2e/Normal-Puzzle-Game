using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumController : MonoBehaviour
{
    public Gems gemResponsible;
    public GameObject gem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.CompareTag("Player"))
        {
            if (gemResponsible == Gems.green)
            {
                if (GlobalVariables.greenGemHas)
                {
                    gem.SetActive(true);
                    GlobalVariables.greenGemHas = false;
                    GlobalVariables.greenGemFilled = true;
                }
            }
            else if(gemResponsible == Gems.yellow)
            {
                if(GlobalVariables.yellowGemHas)
                {
                    gem.SetActive(true);
                    GlobalVariables.yellowGemHas = false;
                    GlobalVariables.yellowGemFilled = true;
                }
            }
            else if(gemResponsible == Gems.blue)
            {
                if(GlobalVariables.blueGemHas)
                {
                    gem.SetActive(true);
                    GlobalVariables.blueGemHas = false;
                    GlobalVariables.blueGemFilled = true;
                }
            }
        }
        
    }
}

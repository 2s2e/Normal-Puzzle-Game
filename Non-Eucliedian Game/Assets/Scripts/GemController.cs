using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public Gems gemColor;
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
        if(other.CompareTag("Player"))
        {
            if(gemColor == Gems.green)
            {
                GlobalVariables.greenGemHas = true;
            }
            else if(gemColor == Gems.blue)
            {
                GlobalVariables.blueGemHas = true;
            }
            else if(gemColor == Gems.yellow)
            {
                GlobalVariables.yellowGemHas = true;
            }
        }
        Destroy(gameObject);

    }
}

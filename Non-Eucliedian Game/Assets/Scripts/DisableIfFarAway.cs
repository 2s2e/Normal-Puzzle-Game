using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfFarAway : MonoBehaviour
{
    private GameObject itemActivatorObject;
    private ItemActivator actiavationScript;


    void Start()
    {
        itemActivatorObject = GameObject.Find("ItemActivator");
        actiavationScript = itemActivatorObject.GetComponent<ItemActivator>();
        StartCoroutine("AddToList");
        
    }

    IEnumerator AddToList() {
        yield return new WaitForSeconds(0.1f);
        actiavationScript.activatorItems.Add(new ActivatorItem{item = this.gameObject, itemPos = transform.position});
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivator : MonoBehaviour
{
    [SerializeField]
    private int distanceFromPlayer;
    private GameObject player;
    public  List<ActivatorItem> activatorItems;
    void Start()
    {
        player = GameObject.Find("True First Person Player (1)");
        activatorItems = new List<ActivatorItem>();

        StartCoroutine("CheckActivation");
    }

    IEnumerator CheckActivation() {
        List<ActivatorItem> removeList =  new List<ActivatorItem>();
        //If something is actually in the activatorItems list
        if(activatorItems.Count > 0) {
            foreach(ActivatorItem item in activatorItems) {
                //If further away from player
                if(Vector3.Distance(player.transform.position, item.itemPos) > distanceFromPlayer){
                    //Add to the remove list which will allow us to remove from the actual activator list
                    if(item.item == null) {
                        removeList.Add(item);
                    } else {
                        item.item.SetActive(false); 
                    }
                } else { //If close to the player, active the item
                    if(item.item == null) {
                        removeList.Add(item);
                    } else {
                        item.item.SetActive(true);
                    }
                }
            }
        }
        yield return new WaitForSeconds(0.01f);

        if(removeList.Count > 0) {
            foreach(ActivatorItem item in removeList) {
                activatorItems.Remove(item);
            }
        }

        yield return new WaitForSeconds(0.01f);
        StartCoroutine("CheckActivation");
    }

    
}

public class ActivatorItem{
    public GameObject item;
    public Vector3 itemPos;

}
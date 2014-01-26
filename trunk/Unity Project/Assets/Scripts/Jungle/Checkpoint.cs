using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.GetComponent<JunglePlayer>().SpawnLocation = transform.position;
        }
    }

}

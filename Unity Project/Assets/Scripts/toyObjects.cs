using UnityEngine;
using System.Collections;

public class toyObjects : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.tag.Equals ("a")){
			SmashBrosHandler.Instance.updateScore(1);
		}
    }
}

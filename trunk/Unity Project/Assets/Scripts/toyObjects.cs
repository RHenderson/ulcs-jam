using UnityEngine;
using System.Collections;

public class toyObjects : MonoBehaviour {
	
	private bool hit = true;
	
	void OnCollisionEnter(Collision collision) {
		if (SmashBrosHandler.Instance.canScore()){
       if (collision.gameObject.tag.Equals ("a")){
			if (hit){
				SmashBrosHandler.Instance.updateScore(50);
			}else{
				SmashBrosHandler.Instance.updateScore(1);
			}
			hit = false;
		}
		}
    }
}

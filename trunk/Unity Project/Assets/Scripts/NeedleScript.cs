using UnityEngine;
using System.Collections;

public class NeedleScript : MonoBehaviour {
	
	[SerializeField] private float speed = 10.0f;
	[SerializeField] private int lifetime = 10;
	
	private Vector3 movement;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, lifetime);
        movement = new Vector3(speed, 0, 0);
	}
	
	void Update() {		
	}

    void FixedUpdate()
    {
        // 5 - Move the game object
        transform.Translate(Vector3.forward * speed);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<JunglePlayer>().Posion();
            
        }
        Destroy(gameObject);
    }
}

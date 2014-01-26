 #pragma strict

var walkspeed: float = 5.0;
var rotspeed: float = 1.0;
var stop: boolean = false;
var startpos: Vector3;
var score: int = 0;


public var hack : GameObject;

function Start() {

	startpos = transform.position;
}

function Update() {

	if (!stop) {
    //rigidbody.freezeRotation = false;
	
	transform.Translate(Vector3(0,0,1) * Time.deltaTime * walkspeed);
    //if (Input.GetKey("w")) transform.Translate(Vector3(0, 0, 1) * Time.deltaTime * walkspeed);
    //if (Input.GetKey("s")) transform.Translate(Vector3(0, 0, - 1) * Time.deltaTime * walkspeed);
    //if (Input.GetKey("a")) transform.Translate(Vector3(-1, 0, 0) * Time.deltaTime * walkspeed);
    //if (Input.GetKey("d")) transform.Translate(Vector3(1, 0, 0) * Time.deltaTime * walkspeed);
    //if (Input.GetKey("q")) transform.Translate(Vector3(0, 1, 0) * Time.deltaTime * walkspeed);
    //if (Input.GetKey("e")) transform.Translate(Vector3(0, -1, 0) * Time.deltaTime * walkspeed);
    if (Input.GetKey("w")) transform.Rotate(Vector3(-1, 0, 0) * Time.deltaTime * rotspeed);
    if (Input.GetKey("a")) transform.Rotate(Vector3(0, -1, 0) * Time.deltaTime * 5 * rotspeed);
    if (Input.GetKey("s")) transform.Rotate(Vector3(1, 0, 0) * Time.deltaTime * rotspeed);
    if (Input.GetKey("d")) transform.Rotate(Vector3(0, 1, 0) * Time.deltaTime * 5 * rotspeed);
    //if (Input.GetKey("u")) transform.Rotate(Vector3(0, 0, 1) * Time.deltaTime * 5 * rotspeed);
    //if (Input.GetKey("o"))
    //transform.Rotate(Vector3(0, 0, -1) * Time.deltaTime * 5 * rotspeed);
    
    }
}

function OnCollisionEnter(collision : Collision) {
	
	print("Collision");	
	if (collision.gameObject.tag.Equals("Objective")) {
		//set to win
		transform.Translate(Vector3(0,0,0) * Time.deltaTime * walkspeed);
		stop = true;
		hack.SendMessage("Finish", 1);
	} else if (collision.gameObject.tag.Equals("Failure")) {
		//set to lose
		transform.Translate(Vector3(0,0,0) * Time.deltaTime * walkspeed);
		hack.SendMessage("Finish", -1);
		stop = true;
	} else {
		transform.position = startpos;
	}
	
	rigidbody.angularVelocity = Vector3.zero;
}
	
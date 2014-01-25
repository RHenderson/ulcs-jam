 #pragma strict

var walkspeed: float = 5.0;
var rotspeed: float = 20.0;

function Start() {



}

function Update() {

    rigidbody.freezeRotation = false;
	
	//transform.Translate(Vector3(0,0,1) * Time.deltaTime * walkspeed);
    if (Input.GetKey("w")) transform.Translate(Vector3(0, 0, 1) * Time.deltaTime * walkspeed);
    if (Input.GetKey("s")) transform.Translate(Vector3(0, 0, - 1) * Time.deltaTime * walkspeed);
    if (Input.GetKey("a")) transform.Translate(Vector3(-1, 0, 0) * Time.deltaTime * walkspeed);
    if (Input.GetKey("d")) transform.Translate(Vector3(1, 0, 0) * Time.deltaTime * walkspeed);
    if (Input.GetKey("q")) transform.Translate(Vector3(0, 1, 0) * Time.deltaTime * walkspeed);
    if (Input.GetKey("e")) transform.Translate(Vector3(0, -1, 0) * Time.deltaTime * walkspeed);
    if (Input.GetKey("i")) transform.Rotate(Vector3(-1, 0, 0) * Time.deltaTime * rotspeed);
    if (Input.GetKey("k")) transform.Rotate(Vector3(1, 0, 0) * Time.deltaTime * rotspeed);
    if (Input.GetKey("j")) transform.Rotate(Vector3(0, -1, 0) * Time.deltaTime * 5 * rotspeed);
    if (Input.GetKey("l")) transform.Rotate(Vector3(0, 1, 0) * Time.deltaTime * 5 * rotspeed);
    if (Input.GetKey("u")) transform.Rotate(Vector3(0, 0, 1) * Time.deltaTime * 5 * rotspeed);
    if (Input.GetKey("o")) transform.Rotate(Vector3(0, 0, -1) * Time.deltaTime * 5 * rotspeed);
}

function OnCollisionEnter(collision : Collision){
	
	transform.Translate(Vector3(0,0,0) * Time.deltaTime * walkspeed);
	
	}
	
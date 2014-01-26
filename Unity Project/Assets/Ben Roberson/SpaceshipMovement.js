 #pragma strict

var walkspeed: float = 20.0;
var rotspeed: float = 20.0;
var stop: boolean = false;
var startpos: Vector3;
var score: int = 0;
var particleTRex: ParticleSystem;
var exhaust: AudioSource;

function Start() {

	startpos = transform.position;

}

function FixedUpdate() {

	if (stop){
	return;
	}
    rigidbody.freezeRotation = false;
	
	//transform.Translate(Vector3(0,0,1) * Time.deltaTime * walkspeed);
    if (Input.GetKey("e")) transform.Translate(Vector3(0, 0, 1) * Time.deltaTime * walkspeed);
    if (Input.GetKey("q")) transform.Translate(Vector3(0, 0, - 1) * Time.deltaTime * walkspeed);
    if (Input.GetKey("a")) transform.Translate(Vector3(-1, 0, 0) * Time.deltaTime * walkspeed);
    if (Input.GetKey("d")) transform.Translate(Vector3(1, 0, 0) * Time.deltaTime * walkspeed);
    if (Input.GetKey("s")) transform.Translate(Vector3(0, 1, 0) * Time.deltaTime * walkspeed);
    if (Input.GetKey("w")) transform.Translate(Vector3(0, -1, 0) * Time.deltaTime * walkspeed);
    if (Input.GetKey("i")) transform.Rotate(Vector3(-1, 0, 0) * Time.deltaTime * 5 * rotspeed);
    if (Input.GetKey("k")) transform.Rotate(Vector3(1, 0, 0) * Time.deltaTime * 5 * rotspeed);
    if (Input.GetKey("u")) transform.Rotate(Vector3(0, -1, 0) * Time.deltaTime * 5 * rotspeed);
    if (Input.GetKey("o")) transform.Rotate(Vector3(0, 1, 0) * Time.deltaTime * 5 * rotspeed);
    if (Input.GetKey("l")) transform.Rotate(Vector3(0, 0, 1) * Time.deltaTime * 5 * rotspeed);
    if (Input.GetKey("j")) transform.Rotate(Vector3(0, 0, -1) * Time.deltaTime * 5 * rotspeed);
    if (Input.GetKey("left shift") && Input.GetKey("w")) {
    	transform.Translate(Vector3(0, -2.5, 0) * Time.deltaTime * walkspeed);
    	particleTRex.Play();
    	if(!exhaust.isPlaying)
    		exhaust.Play();
    }
    else {
    	particleTRex.Stop();
    	exhaust.Stop();
    }
}

function OnCollisionEnter(collision : Collision){		
	rigidbody.angularVelocity = Vector3.zero;
	}
	
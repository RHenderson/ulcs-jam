#pragma strict

var walkspeed: float;
var blastoff: Blastoff;
var rocketMan: boolean = false;

function Start () {

}

function Update () {

	if (rocketMan == true) {
		transform.Translate(Vector3(0,0,1) * Time.deltaTime * walkspeed);
	}
}
#pragma strict

var vecX: int;
var vecY: int;
var vecZ: int;
var astSpeed: float = 20;
var orient: Transform;

function Start () {

}

function Update () {

	//orient = transform.position;
	transform.RotateAround (orient.position, Vector3(vecX, vecY, vecZ), astSpeed * Time.deltaTime);

}
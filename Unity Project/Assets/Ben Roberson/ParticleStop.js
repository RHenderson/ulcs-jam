#pragma strict

var particleTRex: ParticleSystem;

function Start () {

}

function Update () {

}

function OnCollisionEnter(collision : Collision){

	particleTRex.Stop();

}
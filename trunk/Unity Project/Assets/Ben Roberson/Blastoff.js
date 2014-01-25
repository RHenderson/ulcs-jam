#pragma strict

var particleTRex: ParticleSystem;
var teamRocket: boolean = false;
var rocketMan : RocketMan;

function Start () {

}

function Update () {

}

function OnCollisionEnter(collision : Collision){

		particleTRex.Play();
		particleTRex.audio.Play();
		teamRocket = true;
		rocketMan.rocketMan = true;
		}
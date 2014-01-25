#pragma strict

var pointB : Vector3;
var stop: boolean = false;
 
function Start () {
    var pointA = transform.position;
    while (!stop) {
        yield MoveObject(transform, pointA, pointB, 2.0);
        yield MoveObject(transform, pointB, pointA, 2.0);
    }
}
 
function MoveObject (thisTransform : Transform, startPos : Vector3, endPos : Vector3, time : float) {
    var i = 0.0;
    var rate = 1.0/time;
    while (i < 1.0 && !stop) {
        i += Time.deltaTime * rate;
        thisTransform.position = Vector3.Lerp(startPos, endPos, i);
        yield; 
    }
}

function OnCollisionEnter(collision: Collision) {
	stop = true;
	}
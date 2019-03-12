using UnityEngine;

public class rotateSphere : MonoBehaviour {


	public int speed;
	private float xDeg;
	private float yDeg;
	private Quaternion fromRotation;
	private Quaternion toRotation;

	public GameObject sphere;

	private Vector3 MouseStart, MouseMove;

	void FixedUpdate(){
		//rotate cube
		fromRotation = sphere.transform.rotation;
		if (Input.GetMouseButton (0)) {
			xDeg -= Input.GetAxis("Mouse X") * speed;
			yDeg += Input.GetAxis("Mouse Y") * speed;
		}
		toRotation = Quaternion.Euler(yDeg * Time.deltaTime, xDeg * Time.deltaTime, 0);
		sphere.transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime);

		//control camera
		Vector3 currentPosition = sphere.transform.position;
		currentPosition.z -= Input.GetAxis("Mouse ScrollWheel") * 500 * Time.deltaTime;
		if(currentPosition.z >= -50 && currentPosition.z <= 40){
			sphere.transform.position = currentPosition;
		}

	}
}

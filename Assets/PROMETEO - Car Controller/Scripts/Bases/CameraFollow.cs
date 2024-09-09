using UnityEngine;

namespace PROMETEO___Car_Controller.Scripts.Bases
{
	public class CameraFollow : MonoBehaviour {

		public Transform carTransform;
		[Range(1, 10)] public float followSpeed = 2;
		[Range(1, 10)] public float lookSpeed = 5;

		private Vector3 initialCameraPosition;
		private Vector3 initialCarPosition;
		private Vector3 absoluteInitCameraPosition;

		private void Start(){
			initialCameraPosition = gameObject.transform.position;
			initialCarPosition = carTransform.position;
			absoluteInitCameraPosition = initialCameraPosition - initialCarPosition;
		}

		private void FixedUpdate()
		{
			//Look at car
			var lookDirection = new Vector3(carTransform.position.x, carTransform.position.y, carTransform.position.z) - transform.position;
			var rot = Quaternion.LookRotation(lookDirection, Vector3.up);
			transform.rotation = Quaternion.Lerp(transform.rotation, rot, lookSpeed * Time.deltaTime);

			//Move to car
			var targetPos = absoluteInitCameraPosition + carTransform.transform.position;
			transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
		}
	}
}

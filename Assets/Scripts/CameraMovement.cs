using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private Vector3 offset;
	[SerializeField] private float sensitivity = 3; // ���������������� �����
	[SerializeField] private float limit = 80; // ����������� �������� �� Y
	[SerializeField] private float zoom = 0.25f; // ���������������� ��� ����������, ��������� �����
	[SerializeField] private float zoomMax = 5; // ����. ����������
	[SerializeField] private float zoomMin = 3; // ���. ����������
	[SerializeField] private float X, Y;

	private void Start()
	{
		limit = Mathf.Abs(limit);
		if (limit > 90) limit = 90;
		offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
		transform.position = target.position + offset;
	}

	private void Update()
	{
		if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
		offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

		X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
		Y += Input.GetAxis("Mouse Y") * sensitivity;
		Y = Mathf.Clamp(Y, -limit, limit);
		transform.localEulerAngles = new Vector3(-Y, X, 0);
		transform.position = transform.localRotation * offset + target.position;
	}
}

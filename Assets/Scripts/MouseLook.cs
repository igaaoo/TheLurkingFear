using UnityEngine;

public class MouseLook : MonoBehaviour
{

  private Camera cam;

  private float mouseX, mouseY;
  [SerializeField]
  private float mouseSens = 100f;

  private Transform playerBody;

  [SerializeField]
  private Vector3 playerEulerAngles;

  [SerializeField]
  private float maxRot;
  [SerializeField]
  private float minRot;

  private float xRotation = 0f;

  void Start()
  {
    //Hide cursor
    Cursor.lockState = CursorLockMode.Locked;


    cam = this.GetComponent<Camera>();

    //Get transform from player and mouse axis
    playerBody = GameObject.Find("Camera").GetComponent<Transform>();
  }

  void Update()
  {
    mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
    mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

    //Make turns in horizontal
    playerBody.Rotate(Vector3.up * mouseX);

    LimitRot();
    Zoom();
  }

  //Clamp horizontal rotation
  private void LimitRot()
  {
    //Clamp vertical rotation
    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -45, 45);
    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    playerEulerAngles = playerBody.rotation.eulerAngles;
    playerEulerAngles.y = (playerEulerAngles.y > 180) ? playerEulerAngles.y - 360 : playerEulerAngles.y;
  }

  //Add zoom feature
  private void Zoom()
  {
    if (Input.GetMouseButton(1))
    {
      cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 40, Time.deltaTime * 5);
      PostProcessingController.instance.ApplyVignette();
    }
    else
    {
      cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 65, Time.deltaTime * 5);
      PostProcessingController.instance.RemoveVignette();
    }
  }
}

using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour
{
  [SerializeField]
  private float carSpeed;

  private Rigidbody rb;

  private Animator animations;

  private GameObject volante;

  private GameObject carBrake;

  private static CarController _instance;
  public static CarController instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = FindObjectOfType<CarController>();
      }
      return _instance;
    }
  }

  void Start()
  {
    volante = GameObject.FindWithTag("Volante");
    carBrake = GameObject.FindWithTag("CarBrake");

    animations = GetComponent<Animator>();
    rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
    MoveForward();
    MoveSides();
  }

  //Move the car forward, increase velocity by time
  private void MoveForward()
  {
    float speedCalc = 10;
    float speedKmh = carSpeed / speedCalc;
    carSpeed += 1 * Time.deltaTime;
    rb.velocity = new Vector3(0, 0, speedKmh);
  }

  //Move the car to left and right
  private void MoveSides()
  {
    if (Input.GetKey(KeyCode.A))
    {
      rb.velocity += Vector3.left * 5;
      volante.transform.Rotate(Vector3.forward * Time.deltaTime * 80);
    }
    if (Input.GetKey(KeyCode.D))
    {
      rb.velocity += Vector3.right * 5;
      volante.transform.Rotate(Vector3.back * Time.deltaTime * 80);
    }
  }

  //Detect when the player collides and decrease velocity
  public IEnumerator Collided()
  {
    carBrake.GetComponent<AudioSource>().Play();
    animations.SetBool("Collided", true);
    float reducedSpeed = carSpeed - 10;
    float t = 0.0f;
    while (t <= 1.0f)
    {
      t += 0.5f * Time.deltaTime;
      carSpeed = Mathf.Lerp(carSpeed, reducedSpeed, t);
      yield return null;
    }
    animations.SetBool("Collided", false);

  }
}

using UnityEngine;

namespace OilSimulator
{
    public class TruckController : MonoBehaviour
    {
        [SerializeField] private float accelerationForce = 1800f;
        [SerializeField] private float brakeForce = 2200f;
        [SerializeField] private float steeringForce = 85f;
        [SerializeField] private float maxSpeed = 28f;

        private Rigidbody rb;
        private float throttle;
        private float steering;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
            }

            rb.mass = 1500f;
            rb.drag = 0.25f;
            rb.angularDrag = 0.8f;
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }

        private void Update()
        {
            throttle = Input.GetAxis("Vertical");
            steering = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            if (rb == null)
            {
                return;
            }

            Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
            float forwardVelocity = Mathf.Clamp(localVelocity.z, -maxSpeed, maxSpeed);

            if (throttle > 0f)
            {
                Vector3 force = transform.forward * accelerationForce * throttle;
                rb.AddForce(force, ForceMode.Acceleration);
            }
            else if (throttle < 0f)
            {
                Vector3 brake = -transform.forward * brakeForce * Mathf.Abs(throttle);
                rb.AddForce(brake, ForceMode.Acceleration);
            }

            float steerFactor = Mathf.Clamp01(Mathf.Abs(localVelocity.z) / 15f);
            float turnStrength = steeringForce * steerFactor;
            Quaternion deltaRotation = Quaternion.Euler(0f, steering * turnStrength * Time.fixedDeltaTime, 0f);
            rb.MoveRotation(rb.rotation * deltaRotation);

            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity *= 0.985f;
            }
        }
    }
}

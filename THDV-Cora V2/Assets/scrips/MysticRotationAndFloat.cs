using UnityEngine;

public class MysticRotationAndFloat : MonoBehaviour
{
    [SerializeField]float rotationSpeed = 50;
    //public float floatMagnitude = 0.5f;     
    //public float floatSpeed = 1f;           
    Rigidbody m_Rigidbody;
    Vector3 m_EulerAngleVelocity;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();

        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)
        m_EulerAngleVelocity = new Vector3(rotationSpeed, 0, 0);
    }
    void Update()
    {

        //transform.Rotate(Vector3.right   * rotationSpeed * Time.deltaTime);
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);


    }
}

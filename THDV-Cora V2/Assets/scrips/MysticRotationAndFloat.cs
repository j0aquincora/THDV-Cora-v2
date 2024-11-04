using UnityEngine;

public class MysticRotationAndFloat : MonoBehaviour
{
    [SerializeField]float rotationSpeed = 50;
            
    Rigidbody m_Rigidbody;
    Vector3 m_EulerAngleVelocity;

    void Start()
    {
        
        m_Rigidbody = GetComponent<Rigidbody>();

        
        m_EulerAngleVelocity = new Vector3(rotationSpeed, 0, 0);
    }
    void Update()
    {

        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);


    }
}

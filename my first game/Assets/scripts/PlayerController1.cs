using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] KeyCode keyOne; //setting the keys for movement
    [SerializeField] KeyCode keyTwo; //setting the keys for movement
    [SerializeField] Vector3 moveDirection;

    

    Rigidbody rigidbody;

    Quaternion originRotation;


    private void Start()
    {
        originRotation = transform.rotation;
        rigidbody = GetComponent<Rigidbody>();;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(keyOne)) //check if the key is pressed, if yes, then we move in one direction, if not in the other
        {
            rigidbody.velocity += moveDirection;
            Quaternion quaternion1 = Quaternion.Euler(0, -90, 0);
            transform.rotation = originRotation * quaternion1;
        
        }

        if (Input.GetKey(keyTwo)) //check if the key is pressed, if yes, then we move in one direction, if not in the other
        {
            rigidbody.velocity -= moveDirection;
            Quaternion quaternion3 = Quaternion.Euler(0, 90, 0);
            transform.rotation = originRotation * quaternion3;
        }

        if (Input.GetKey(KeyCode.R)) //check if the R key is pressed, if so restart the level
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }

}

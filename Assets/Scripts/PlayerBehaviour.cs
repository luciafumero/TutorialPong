using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    KeyCode buttonUp, buttonDown;
    [SerializeField]
    float playerSpeed = 1.0f;

    void Update()
    {
       if(Input.GetKey(buttonDown)) 
       {
            transform.position += Vector3.down * playerSpeed * Time.deltaTime;
            Debug.Log("Pesionando abajo" + gameObject.name);

       }
       else if(Input.GetKey(buttonUp)) 
       {
            transform.position += Vector3.up * playerSpeed * Time.deltaTime;
            Debug.Log("Presionando arriba" + gameObject.name);
       }
    }
}

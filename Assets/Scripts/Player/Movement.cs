using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script made by Flavio Alexandre
/// This Script is related to the behavior of the character
/// </summary>
public class Movement : MonoBehaviour
{
    //Variables
    [Header("Movement Variables")]
    [SerializeField] float _speed;//Movement Speed

    //Components
    Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    //Move Funtion
    public void Move(Vector3 move)
    {
        _rigidbody2D.MovePosition(transform.position + move * _speed * Time.deltaTime);
    }
}

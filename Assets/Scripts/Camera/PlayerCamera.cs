using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    Transform _player_Transform;
    // Start is called before the first frame update
    void Start()
    {
        _player_Transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player_Transform.position.x, _player_Transform.position.y, _player_Transform.position.z - 10f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    enum DroneState
    {
        DRONE_STATE_IDLE,
        DRONE_STATE_START_TAKINGOFF,
        DRONE_STATE_TAKINGOFF,
        DRONE_STATE_MOVING_UP,
        DRONE_STATE_FLYING,
    }

    DroneState _State;
    // Start is called before the first frame update

    Animator _Anim;
    Vector3 _Speed = new Vector3(0.0f, 0.0f, 0.0f);
    public float _SpeedMultiplier = 1.0f;

    public bool isIdle()
    {
        return (_State == DroneState.DRONE_STATE_IDLE);
    }

    public void takeOff()
    {
        _State = DroneState.DRONE_STATE_START_TAKINGOFF;
    }

    void Start()
    {
        _Anim = GetComponent<Animator>();

        _State = DroneState.DRONE_STATE_IDLE;

    }

    public void Move(float _speedX, float _speedZ)
    {
        _Speed.x = _speedX;
        _Speed.z = _speedZ;

        UpdateDrone();
    }

    // Update is called once per frame
    void UpdateDrone()
    {

        switch (_State)
        {
            case DroneState.DRONE_STATE_IDLE:
                break;
            case DroneState.DRONE_STATE_START_TAKINGOFF:
                _Anim.SetBool("TakeOff", true);
                _State = DroneState.DRONE_STATE_TAKINGOFF;
                break;
            case DroneState.DRONE_STATE_TAKINGOFF:
                if (_Anim.GetBool("TakeOff") == false)
                {
                    _State = DroneState.DRONE_STATE_MOVING_UP;
                }
                break;
            case DroneState.DRONE_STATE_MOVING_UP:
                if (_Anim.GetBool("MoveUp") == false)
                {
                    _State = DroneState.DRONE_STATE_FLYING;
                }
                break;
            case DroneState.DRONE_STATE_FLYING:
                float angleZ = -30.0f * _Speed.x * 60.0f * Time.deltaTime;
                float angleX = 30.0f * _Speed.z * 60.0f * Time.deltaTime;

                Vector3 rotation = transform.localRotation.eulerAngles;
                transform.localPosition += _Speed * _SpeedMultiplier * Time.deltaTime;
                transform.localRotation = Quaternion.Euler(angleX, rotation.y, angleZ);
                break;
        }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;


public class GameManager : MonoBehaviour
{
    public DroneController _DroneController;
    public Button _FlyButton;

    // Start is called before the first frame update
    void Start()
    {
        _FlyButton.onClick.AddListner(EventOnClickFlyButton);
    }

    // Update is called once per frame
    void Update()
    {
        float speedX = Input.GetAxis("Horizontal");
        float speedZ = Input.GetAxis("Vertical");
        _DroneController.Move(speedX, speedZ);
    }

    public void EventOnClickFlyButton()
    {
        if (_DroneController.isIdle())
        {
            _DroneController.takeOff();
        }
    }
}

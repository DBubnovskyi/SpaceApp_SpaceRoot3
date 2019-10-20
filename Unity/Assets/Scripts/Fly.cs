using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class Fly : MonoBehaviour
{
    Aircraft aircraft;
    void Start()
    {
        if(gameObject.name == "Starship")
            aircraft = new Starship(gameObject);
        if (gameObject.name == "Luminaris Starship")
            aircraft = new LuminarisStarship(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        if (vertical > 0.5f)
        {
            aircraft.PitchDown();
        }
        else if (vertical < -0.5f)
        {
            aircraft.PitchUp();
        }
        else if (horizontal > 0.5f)
        {
            aircraft.RollRight();
        }
        else if (horizontal < -0.5f) 
        {
            aircraft.RollLeft();
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            aircraft.YawLeft();
        }
        else if (Input.GetKey(KeyCode.E)) 
        {
            aircraft.YawRight();
        }
        else if (Input.GetKey(KeyCode.LeftShift)) 
        {
            aircraft.SpeedUp();
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            aircraft.SlowDown();
        }
        else
        {
            aircraft.Normalize();
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            aircraft.Mode = Aircraft.FlyMode.Normal;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            aircraft.Mode = Aircraft.FlyMode.Vertical;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            aircraft.Mode = Aircraft.FlyMode.Space;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.F1))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        else if (Input.GetKey(KeyCode.F2))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

    }
}

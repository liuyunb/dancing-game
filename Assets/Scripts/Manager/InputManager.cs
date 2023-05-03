using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            GameManager.Instance.InputArrow(KeyCode.UpArrow);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            GameManager.Instance.InputArrow(KeyCode.LeftArrow);
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            GameManager.Instance.InputArrow(KeyCode.DownArrow);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            GameManager.Instance.InputArrow(KeyCode.RightArrow);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.Instance.ConfirmArrow();
        }
    }
}

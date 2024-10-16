using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractToggle : Interactable
{
    public string message1;
    public string message2;

    public void ToggleMessage()
    {
        if (this.message == message1)
        {
            this.message = message2;
        }
        else
        {
            this.message = message1;
        }
    }
}

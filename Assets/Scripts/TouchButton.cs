using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    [SerializeField]Material greenMaterial;
    [SerializeField]Material grayMaterial;
    NumberPad numberPad;
    MeshRenderer rend;
    public char number;
    override protected void Awake()
    {
        base.Awake();
        rend = GetComponent<MeshRenderer>();
        numberPad = GameObject.Find("Numberpad").GetComponent<NumberPad>();

    }

    override protected void OnHoverEntered(HoverEnterEventArgs args)
    {
        if (numberPad.isOccupied==0)
        {
            base.OnHoverEntered(args);
            rend.material = greenMaterial;
            numberPad.UpdateAndCheck(number);
        }
        ++numberPad.isOccupied;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        rend.material = grayMaterial;
        --numberPad.isOccupied;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandle : XRBaseInteractable
{
    public bool open;
    [SerializeField]GameObject door;
    [SerializeField] float coffe;
    bool ispulling;
    Vector3 startpos;
    private XRBaseController m_Controller;
    protected override void Awake()
    {
        base.Awake();
        ispulling = false;
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        ispulling = true;
        startpos = args.interactableObject.transform.position - door.transform.position;
        var controllerInteractor = args.interactorObject as XRBaseControllerInteractor;
        m_Controller = controllerInteractor.xrController;
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        ispulling = false;
    }

    // Start is called before the first frame update
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (ispulling&& open)
        {
            var curpos= m_Controller.transform.position- door.transform.position;
            float strength = Vector3.Dot(door.transform.right, curpos - startpos);
            if(strength<0)
                door.transform.position = new Vector3(Mathf.MoveTowards(door.transform.position.x, -0.8f, -strength * Time.deltaTime), 
                    door.transform.position.y, door.transform.position.z);
            else
                door.transform.position = new Vector3(Mathf.MoveTowards(door.transform.position.x, 0f, strength * Time.deltaTime),
                    door.transform.position.y, door.transform.position.z);
        }

    }
}

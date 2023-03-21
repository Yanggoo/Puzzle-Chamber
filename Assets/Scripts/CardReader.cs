using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReader : XRSocketInteractor
{
    float distance = 0.15f;
    float swipthreshold = 0.5f;
    Vector3 startPos;
    Vector3 endPos;
    [SerializeField]bool swip;
    GameObject doorLock;
    IXRHoverInteractable m_card;
    [SerializeField]GameObject doorHandel;
    protected override void Awake()
    {
        base.Awake();
        doorLock = GameObject.Find("DoorLockingBar");
        m_card = null;
    }
    private void Update()
    {
        if (m_card != null && Vector3.Dot(m_card.transform.forward, Vector3.up) < swipthreshold)
            swip = false;
    }
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        startPos = args.interactableObject.transform.position;
        swip = true;
        m_card = args.interactableObject;
    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        endPos = args.interactableObject.transform.position;
        if ((startPos - endPos).y >= distance&& swip)
        {
            doorLock.SetActive(false);
            doorHandel.GetComponent<DoorHandle>().open = true;
        }
        m_card = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GrabFoodActived : MonoBehaviour
{
    public SteamVR_Action_Boolean EatAction;
    PointManager pointManager = new PointManager();
    Interactable interactable;
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    void Update()
    {
        if(interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (EatAction[source].stateDown)
            {
                Eat();
            }
        }
    }
    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        if(interactable.attachedToHand == null && grabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
        }
        else if (isGrabEnding)
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
    }
    public void Eat()
    {
        pointManager = GameObject.FindGameObjectWithTag("PointManager").GetComponent<PointManager>();
        pointManager.OnPointChange(gameObject.GetComponent<ItemDetail>().energy, gameObject.GetComponent<ItemDetail>().fat, gameObject.GetComponent<ItemDetail>().vitamin);
        Destroy(gameObject);
    }
}

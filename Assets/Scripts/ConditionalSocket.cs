using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ConditionalSocket : XRSocketInteractor
{
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        if (GameManager.instance.isDebaf) return false;
        return base.CanSelect(interactable);
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        var obj = args.interactableObject.transform.GetComponent<KastrulaController>();
        if (obj != null)
        {
            obj.isOnPlita = true;
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        var obj = args.interactableObject.transform.GetComponent<KastrulaController>();
        if (obj != null)
        {
            obj.isOnPlita = false;
        }
    }
}

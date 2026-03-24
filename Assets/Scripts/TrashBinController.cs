using UnityEngine;

public class TrashBinController : VitezhkaController
{
    protected override void OnTriggerStay(Collider other)
    {
        if(GameManager.instance.isTrashopened)
        {
            force = 4f;
        }
        else
        {
            force = 0f;
        }
    }
}

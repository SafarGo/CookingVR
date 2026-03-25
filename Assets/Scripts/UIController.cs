using UnityEngine;

public class UIController : MonoBehaviour
{
    public void OpenRecepie(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void CloseRecepie(GameObject obj) {
        obj.SetActive(false);
    }
}

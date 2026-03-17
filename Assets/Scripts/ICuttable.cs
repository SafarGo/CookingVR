using UnityEngine;

public interface ICuttable
{
    void OnCut()
    { 
        Debug.Log("Cutting");
    }
}
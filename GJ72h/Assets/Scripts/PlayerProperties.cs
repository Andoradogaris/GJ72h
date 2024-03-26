using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [SerializeField] bool isNoisy = false;
    
    public void SetNoisy(bool heard)
    {
        isNoisy = heard;
    }
    
    public bool IsNoisy()
    {
        return isNoisy;
    }
}

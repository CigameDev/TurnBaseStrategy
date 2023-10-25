using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditorInternal;
using UnityEngine;

/// <summary>
/// Tuan thu single 
/// Class nay chi lam 1 nhiem vu duy nhat la lay ra vi tri chuot
/// </summary>
public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;
    private Camera cam;

    [SerializeField] private LayerMask mousePlaneLayerMask;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cam = Camera.main;
    }
    //private void Update()
    //{
    //    transform.position = MouseWorld.GetPosition();
    //}

    public static Vector3 GetPosition()
    {
        Ray ray = instance.cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point;
    }    
}

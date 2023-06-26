using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Transform _gunBarrel; 
    [SerializeField] private float _shootDistance = 100f; 
    [SerializeField] private LayerMask _shootableLayers;
    public void Initialize(Camera camera)
    {
        _camera = camera;
    }
    
    public void Aim()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, _shootDistance, _shootableLayers))
        {
            transform.position = hit.point;
                
            Vector3 direction = hit.point - _gunBarrel.position;
            _gunBarrel.rotation = Quaternion.LookRotation(direction);
        }
    }
}
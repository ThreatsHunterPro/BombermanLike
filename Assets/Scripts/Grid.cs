using UnityEngine;

public class Grid : MonoBehaviour
{
   [SerializeField]
   private bool drawGrid = false;
   
   [SerializeField, Range(0.0f, 100.0f)]
   private float gap = 6.0f;
   
   [SerializeField]
   private MeshRenderer surface = null;

   [SerializeField, Header("Debug"), Range(0.0f, 10.0f)]
   private float gridPointRadius = 0.1f;
   
   [SerializeField, Header("Debug")]
   private Color gridColor = Color.white;

   private Vector3 Extent => surface ? surface.bounds.extents : Vector3.zero;

   private void OnDrawGizmos() => DrawGrid();
   private void DrawGrid()
   {
      if (!drawGrid) return;
      
      Gizmos.color = gridColor;
      
      float _exentX = Extent.x;
      for (float _xIndex = -_exentX; _xIndex < _exentX; _xIndex += gap)
      {
         float _extentZ = Extent.z;
         for (float _zIndex = -_extentZ; _zIndex < _extentZ; _zIndex += gap)
         {
            Vector3 _gridPoint = new Vector3(_xIndex + 1.0f, 0.1f, _zIndex + 1.0f);
            Gizmos.DrawSphere(transform.position + _gridPoint, gridPointRadius);
         }
      }
   }
   public Vector3 GetSnapedPosition(Vector3 _position)
   {
      Vector3 _positionToSnap = _position - transform.position;
      float _x = Mathf.RoundToInt(_positionToSnap.x / gap) * gap;
      float _xLimit = Extent.x;
      _x = Mathf.Clamp(_x , -_xLimit + 1, _xLimit - 1);

      float _z = Mathf.RoundToInt(_positionToSnap.z / gap) * gap;
      float _zLimit = Extent.z;
      _z = Mathf.Clamp(_z, -_zLimit + 1, _zLimit - 1);

      return transform.position + new Vector3(_x, _positionToSnap.y, _z);
   }
   public Quaternion GetSnapedRotation(Quaternion _rotation)
   {
      Vector3 _currentRotation = _rotation.eulerAngles;
      _currentRotation.y = Mathf.Round(_currentRotation.y / 90.0f) * 90.0f;
      return Quaternion.Euler(_currentRotation);
   }
}

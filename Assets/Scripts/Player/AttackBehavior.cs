using UnityEngine;

namespace Player
{
    public class AttackBehavior : MonoBehaviour
    {
        private bool canDrop = true;

        [SerializeField, Range(0.0f, 60.0f)]
        private float cooldown = 5.0f;
        
        [SerializeField]
        private GameObject bomb = null;

        [SerializeField]
        private Grid grid = null;
    
        private Quaternion BombRotation => bomb ? bomb.transform.rotation : Quaternion.identity;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DropBomb();
            }
        }
        private void DropBomb()
        {
            if (!canDrop || !bomb || !grid) return;
            
            Instantiate(bomb, grid.GetSnapedPosition(transform.position), grid.GetSnapedRotation(transform.rotation) * BombRotation);
            canDrop = false;
            Invoke(nameof(SwitchDropStatus), cooldown);
        }
        private void SwitchDropStatus()
        {
            canDrop = !canDrop;
        }
    }
}
using Cinemachine;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class FirstPersonController : MonoBehaviour
    {
        public Vector3 MoveDirection;
    
        private CharacterController _character;
        private CinemachineVirtualCamera _virtualCamera;
        private readonly Collider[] _cachedColliders = new Collider[16];

        public LayerMask GroundLayer;
        public float MoveSpeed = 1f;

        private void Start()
        {
            _character = GetComponent<CharacterController>();
            _virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();

            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            #region Movement
        
            var velocity = MoveDirection * (MoveSpeed * Time.deltaTime);
            // Ground Detection
            var overlapCount = Physics.OverlapSphereNonAlloc(transform.position - Vector3.up * 0.7f, 0.4f, _cachedColliders, GroundLayer);
            if (overlapCount <= 0)
            {
                velocity = Physics.gravity * Time.deltaTime;
            }
        
            _character.Move(velocity);
        
            #endregion
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position - Vector3.up * 0.7f, 0.35f);
        }
    }
}

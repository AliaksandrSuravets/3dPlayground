using Playground.Game.Player;
using UnityEngine;

namespace Playground.Game.Level
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private Vector3 _position;
        
        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.TryGetComponent(out PlayerMovement component);
            component?.Teleport(_position);
        }
    }
}

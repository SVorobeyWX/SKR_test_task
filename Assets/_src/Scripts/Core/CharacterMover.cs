using UnityEngine;
using UnityEngine.AI;

namespace Core {
    public class CharacterMover : MonoBehaviour {
        [SerializeField] private Transform[] wayPoints;
        [SerializeField] private NavMeshAgent navMeshAgent;

        private int _currentIndex;

        public void Move() {
            navMeshAgent.SetDestination(wayPoints[_currentIndex].position);
            _currentIndex = _currentIndex == wayPoints.Length - 1 ? 0 : _currentIndex + 1;
        }
    }
}
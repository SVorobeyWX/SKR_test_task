using Unity.AI.Navigation;
using UnityEngine;

namespace Core {
    [RequireComponent(typeof(MeshFilter), typeof(NavMeshSurface))]
    public abstract class ObjectDeformationBase : MonoBehaviour {
        private protected Mesh Mesh;
        private protected NavMeshSurface NavMeshSurface;

        protected virtual void Awake() {
            Mesh = GetComponent<MeshFilter>().mesh;
            NavMeshSurface = GetComponent<NavMeshSurface>();
        }
    }
}
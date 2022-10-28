using UnityEngine;

namespace Core {
    [CreateAssetMenu(fileName = "PlaneData", menuName = "SO/PlaneData", order = 1)]
    public class PlaneDeformationData : ScriptableObject{
        [Range(0.5f, 5f)] public float strength = 0.5f;
        [Range(1f, 5f)]public float area = 2f;
        [Range(1f, 5f)]public float smoothing = 2f;
    }
}
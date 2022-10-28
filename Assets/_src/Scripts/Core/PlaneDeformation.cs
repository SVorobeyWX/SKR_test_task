using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core {
    public class PlaneDeformation : ObjectDeformationBase, IDragHandler, IPointerClickHandler {
        [SerializeField] private PlaneDeformationData data;

        private Vector3[] _vertices;
        private Camera _camera;

        private float _strength;
        private float _area;
        private float _smoothing;

        protected override void Awake() {
            base.Awake();

            _camera = Camera.main;
            if (_camera == null) {
                throw new NullReferenceException("Camera main not found!");
            }

            ConfigureSettings();
            _vertices = Mesh.vertices;
        }

        public void ConfigureSettings() {
            _strength = data.strength;
            _area = data.area;
            _smoothing = data.smoothing;
        }

        public void OnPointerClick(PointerEventData eventData) {
            HandleUserInput();
        }
        

        public void OnDrag(PointerEventData eventData) {
            HandleUserInput();
        }

        public void ResetPlane() {
            for (var i = 0; i < _vertices.Length; i++) {
                var vertexPosition = _vertices[i];
                vertexPosition.y = 0;
                _vertices[i] = vertexPosition;
            }
            
            Mesh.MarkDynamic();
            Mesh.SetVertices(_vertices);
            Mesh.RecalculateNormals();
            NavMeshSurface.BuildNavMesh();
        }

        private void GenerateForm(Vector3 point) {
            for (var i = 0; i < _vertices.Length; i++) {
                var vertexPosition = _vertices[i];
                var distance = vertexPosition - point;
                
                if (distance.magnitude <= _area) {
                    vertexPosition += _strength * Vector3.up / _smoothing;
                    _vertices[i] = vertexPosition;
                    continue;
                }
                
                if (distance.magnitude > _area) {
                    vertexPosition.y = 0;
                    _vertices[i] = vertexPosition;
                }
            }

            Mesh.MarkDynamic();
            Mesh.SetVertices(_vertices);
            Mesh.RecalculateNormals();
            NavMeshSurface.BuildNavMesh();
        }
        
        private void HandleUserInput() {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit, Mathf.Infinity)) {
                return;
            }

            GenerateForm(hit.point);
        }
    }
}
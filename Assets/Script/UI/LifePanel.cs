using MyPlatformer.com;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer.ui
{
    public class LifePanel : MonoBehaviour
    {
        [SerializeField] private GameObject heart= default;
        [SerializeField] private float stepX=40;
        [SerializeField] private float positionX = default;

        private List<GameObject> _objs = new List<GameObject>();
        private Transform parent= default;
        private void Awake()
        {
            parent = this.GetComponent<Transform>();
        }
        public void Create(int value = 0)
        {
            for (int i = 0; i < value; i++)
            {
                GameObject view = GameObject.Instantiate(heart);
                view.transform.SetParent(parent);
                view.transform.localPosition = new Vector3(positionX, 0f, 0f);
                positionX += stepX;
                _objs.Add(view);
            }
        }
        public void Add()
        {
            Create(1);
        }

        public void Dell()
        {
            Destroy(_objs[_objs.Count - 1]);
            _objs.Remove(_objs[_objs.Count - 1]);
            positionX -= stepX;
        }
    }

}
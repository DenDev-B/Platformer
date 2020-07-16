using MyPlatformer.com;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "NewBlock", menuName = "SO/NewBlock", order = 51)]
    public class Block : ScriptableObject
    {
          [Header("Box")]
          public List<Line> map= default;
          public List <GameObject> prefabs= default;
          [Header("Trap")]
          public List<Traps> traps= default;
         [Header("Coins")]
         public List<Coins> coinsXY= default;
          public GameObject prefab_coins= default;
}

    [Serializable]
    public class Line
    {
        public List<int> line
        {
            get
            {
                return _line;
            }
        }
        [SerializeField]
        private List<int> _line = default;
    }

    [Serializable]
    public class Traps
    {
        public GameObject go= default;
        public float speed=1f;
        public float x=0f;
        public float y=0f;

    }
[Serializable]
public class Coins
{
    public float x = 0f;
    public float y = 0f;
    public int Random = 100;
}
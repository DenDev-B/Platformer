using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyPlatformer.ui
{
    public class CoinsPanel : MonoBehaviour
    {
        [SerializeField] private Text text= default;
        public void Add(string value)
        {
            text.text = value;
        }
    }
}

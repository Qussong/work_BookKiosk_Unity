using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GH_Search
{
    public class View : MonoBehaviour
    {
        [Header("Canvas")]
        [SerializeField] private List<Canvas> canvasList;
        public List<Canvas> CanvasList => canvasList;


        private void Awake()
        {
            
        }

        private void Start()
        {
            
        }

    }

}

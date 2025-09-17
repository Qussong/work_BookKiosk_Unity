using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GH_Search
{
    public class Controller : MonoBehaviour
    {
        [field: Header("MVC")]
        [SerializeField] public Model model { get; private set; }
        [SerializeField] public View view { get; private set; }


    }
}

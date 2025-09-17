using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GH_Search
{
    public class View : MonoBehaviour
    {
        [Header("Canvas")]
        [SerializeField] private List<Canvas> canvasList;
        public List<Canvas> CanvasList => canvasList;

        
        /// <summary>
        /// 
        /// </summary>
        #region Home Page

        [Header("Home")]
        // �˻� ��ư
        [SerializeField] private Button btnSearch;
        // getter
        public Button BtnSearch => btnSearch;
        // ���� ����Ʈ 10 ��ư
        [SerializeField] private Button btnLoanBest;
        // getter
        public Button BtnLoanBest => btnLoanBest;
        // �ð� ����Ʈ 10 ��ư
        [SerializeField] private Button btnNewBest;
        // getter
        public Button BtnNewBest => btnNewBest;

        #endregion


        /// <summary>
        /// 
        /// </summary>
        #region Result Page

        [Header("Result")]
        // �ڷΰ��� ��ư
        [SerializeField] private Button btnBack;
        // getter
        public Button BtnBack => btnBack;

        #endregion

        private void Awake()
        {
            if (canvasList.Count <= 0 || canvasList.Count > (int)ECanvas.MaxCnt) Debug.LogWarning("canvasList ���� ����");
            // ��� Canvas�� Panel�� raycastTarget off
            foreach (Canvas canvas in canvasList)
            {
                GameObject panelObj = canvas.GetComponentInChildren<PanelMarker>().gameObject;
                panelObj.GetComponent<Image>().raycastTarget = false;
            }

            #region Home

            if (null == btnSearch) Debug.LogWarning("btnSearch �̼���");
            if (null == btnLoanBest) Debug.LogWarning("btnLoanBest �̼���");
            if (null == btnNewBest) Debug.LogWarning("btnNewBest �̼���");

            #endregion

            #region Result

            if (null == btnBack) Debug.LogWarning("btnBack �̼���");

            #endregion


        }

        private void Start()
        {
            
        }

        public void SetCanvasActive(ECanvas canvas, bool flag)
        {
            canvasList[(int)canvas].gameObject.SetActive(flag);
        }

    }

}

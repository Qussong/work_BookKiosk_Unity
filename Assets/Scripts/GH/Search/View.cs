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
        // 검색 버튼
        [SerializeField] private Button btnSearch;
        // getter
        public Button BtnSearch => btnSearch;
        // 대출 베스트 10 버튼
        [SerializeField] private Button btnLoanBest;
        // getter
        public Button BtnLoanBest => btnLoanBest;
        // 시간 베스트 10 버튼
        [SerializeField] private Button btnNewBest;
        // getter
        public Button BtnNewBest => btnNewBest;

        #endregion


        /// <summary>
        /// 
        /// </summary>
        #region Result Page

        [Header("Result")]
        // 뒤로가기 버튼
        [SerializeField] private Button btnBack;
        // getter
        public Button BtnBack => btnBack;

        #endregion

        private void Awake()
        {
            if (canvasList.Count <= 0 || canvasList.Count > (int)ECanvas.MaxCnt) Debug.LogWarning("canvasList 설정 문제");
            // 모든 Canvas의 Panel의 raycastTarget off
            foreach (Canvas canvas in canvasList)
            {
                GameObject panelObj = canvas.GetComponentInChildren<PanelMarker>().gameObject;
                panelObj.GetComponent<Image>().raycastTarget = false;
            }

            #region Home

            if (null == btnSearch) Debug.LogWarning("btnSearch 미설정");
            if (null == btnLoanBest) Debug.LogWarning("btnLoanBest 미설정");
            if (null == btnNewBest) Debug.LogWarning("btnNewBest 미설정");

            #endregion

            #region Result

            if (null == btnBack) Debug.LogWarning("btnBack 미설정");

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

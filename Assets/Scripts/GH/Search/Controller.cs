using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GH_Search
{
    public enum ECanvas
    {
        Base,
        Popup,
        Home,
        Result,
        FindLocation,
        MaxCnt, // 5
    }


    public class Controller : MonoBehaviour
    {
        [field: Header("MVC")]
        [field: SerializeField] public Model model { get; private set; }
        [field: SerializeField] public View view { get; private set; }


        private void Awake()
        {
            if (null == model) Debug.LogWarning("model 설정 안됨");
            if (null == view) Debug.LogWarning("view 설정 안됨");
        }

        private void Start()
        {
            InitUI();
        }

        private void InitUI()
        {
            // 모든 Canvas 비활성화
            for (int i = 0; i < view.CanvasList.Count; ++i)
            {
                view.SetCanvasActive((ECanvas)i, false);
            }

            // Base 와 Home Canvas만 활성화
            view.SetCanvasActive(ECanvas.Base, true);
            view.SetCanvasActive(ECanvas.Home, true);

            InitHome();
            InitResult();
        }

        #region Home Page

        private void InitHome()
        {
            // 책 검색 버튼 초기 설정
            view.BtnSearch.onClick.RemoveAllListeners();
            view.BtnSearch.onClick.AddListener(ClickSeach);
            // 도서 대출 베스트 버튼 초기 설정
            view.BtnLoanBest.onClick.RemoveAllListeners();
            view.BtnLoanBest.onClick.AddListener(ClickLoanBest);
            // 신간 도서 베스트 버튼 초기 설정
            view.BtnNewBest.onClick.RemoveAllListeners();
            view.BtnNewBest.onClick.AddListener(ClickNewBest);

        }

        private void ClickSeach()
        {
            view.SetCanvasActive(ECanvas.Home, false);
            view.SetCanvasActive(ECanvas.Result, true);
        }

        private void ClickLoanBest()
        {
            view.SetCanvasActive(ECanvas.Home, false);
            view.SetCanvasActive(ECanvas.Result, true);
        }

        private void ClickNewBest()
        {
            view.SetCanvasActive(ECanvas.Home, false);
            view.SetCanvasActive(ECanvas.Result, true);
        }

        #endregion

        #region Result Page

        private void InitResult()
        {
            view.BtnBack.onClick.RemoveAllListeners();
            view.BtnBack.onClick.AddListener(ClickBackBtn);

        }

        private void ClickBackBtn()
        {
            view.SetCanvasActive(ECanvas.Result, false);
            view.SetCanvasActive(ECanvas.Home, true);
        }

        #endregion
    }
}

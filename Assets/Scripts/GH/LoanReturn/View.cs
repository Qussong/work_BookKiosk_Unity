using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GH_LoanReturn
{
    public class View : MonoBehaviour
    {
        [field: Header("Canvas")]
        [SerializeField] private List<Canvas> canvasList;
        public List<Canvas> CanvasList => canvasList;


        /// <summary>
        /// 
        /// </summary>
        #region Popup Page Field

        [field: Header("Popup")]
        [SerializeField] private List<GameObject> popupList;
        public List<GameObject> PopupList => popupList;

        #endregion


        /// <summary>
        /// 
        /// </summary>
        #region Home Page Field

        [field: Header("Home")]
        // 대출 일자
        [field: SerializeField] public GameObject HomePageLoanDate { get; private set; }
        // 반납 일자
        [field: SerializeField] public GameObject HomePageReturnDate { get; private set; }
        // 대출 일자의 Text 객체들 (0 : 제목, 1 : Year, 2 : Month + Day)
        private List<TMP_Text> homePageLoanDateTxtList;
        public List<TMP_Text> HomePageLoanDateTxtList => homePageLoanDateTxtList;
        // 반납 일자의 Text 객체들 (0 : 제목, 1 : Year, 2 : Month + Day)
        private List<TMP_Text> homePageReturnDateTxtList;
        public List<TMP_Text> HomePageReturnDateTxtList => homePageReturnDateTxtList;

        #endregion


        /// <summary>
        /// 
        /// </summary>
        #region Loan Page Field

        [field: Header("Loan")]
        // 책 리스트에서 책 이름 Text 객체들을 담고 있는 컨테이너 오브젝트
        [field: SerializeField] public GameObject LoanBookTitleContainer { get; private set; }
        // 책 리스트에서 책 상태 Text 객체들을 담고 있는 컨테이너 오브젝트
        [field: SerializeField] public GameObject LoanBookStateContainer { get; private set; }
        // 책 리스트에서 책 이름 Text 리스트
        private List<TMP_Text> loanBookTitleList;
        // getter
        public List<TMP_Text> LoanBookTitleList => loanBookTitleList;
        // 책 리스트에서 책 상태 Text 리스트
        private List<TMP_Text> loanBookStateList;
        // getter
        public List<TMP_Text> LoanBookStateList => loanBookStateList;
        // 대출 버튼 상단 알림 메세지 객체
        [SerializeField] private GameObject loanInfoContainer;
        // 알림 메세지 객체의 텍스트 리스트
        public List<TMP_Text> LoanInfoTextList { get; private set; }
        // 대출 가능권수, 추가 대출 가능 권수, 인식 된 권수, 대출 된 권수 나타내는 오브젝트 리스트 (0 : 좌측, 1 : 우측)
        [SerializeField] private List<GameObject> bookLoanStatusObjList;
        // getter
        public List<GameObject> BookLoanStatusObjectList => bookLoanStatusObjList;
        // 대출 가능권수, 추가 대출 가능 권수 의 Text 객체들 (0 : 제목, 1 : 권 수)
        private List<TMP_Text> bookLoanStatusTitleList = new List<TMP_Text>();
        // getter
        public List<TMP_Text> BookLoanStatusTitleList => bookLoanStatusTitleList;
        // 인식 된 권수, 대출 된 권수 의 Text 객체들 (0 : 제목, 1 : 권 수)
        private List<TMP_Text> bookLoanStatusCountList = new List<TMP_Text>();
        // getter
        public List<TMP_Text> BookLoanStatusCountList => bookLoanStatusCountList;
        // 대출 버튼
        [field: SerializeField] public Button BtnLoan { get; private set; }
        // 대출 일자
        [field: SerializeField] public GameObject LoanPageLoanDate { get; private set; }
        // 반납 일자
        [field: SerializeField] public GameObject LoanPageReturnDate { get; private set; }
        // 대출 일자의 Text 객체들 (0 : 제목, 1 : Year, 2 : Month + Day)
        private List<TMP_Text> loanPageLoanDateTxtList;
        // getter
        public List<TMP_Text> LoanPageLoanDateTxtList => loanPageLoanDateTxtList;
        // 반납 일자의 Text 객체들 (0 : 제목, 1 : Year, 2 : Month + Day)
        private List<TMP_Text> loanPageReturnDateTxtList;
        // getter
        public List<TMP_Text> LoanPageReturnDateTxtList => loanPageReturnDateTxtList;

        #endregion


        /// <summary>
        /// 
        /// </summary>
        #region Return Page Field

        [field: Header("Return")]
        // 반납 일자
        [field: SerializeField] public GameObject ReturnPageReturnDate { get; private set; }
        // 반납 일자의 Text 객체들 (0 : 제목, 1 : Year, 2 : Month + Day)
        private List<TMP_Text> returnPageReturnDateTxtList;
        public List<TMP_Text> ReturnPageReturnDateTxtList => returnPageReturnDateTxtList;
        // 책 리스트에서 책 이름 Text 객체들을 담고 있는 컨테이너 오브젝트
        [field: SerializeField] public GameObject ReturnBookTitleContainer { get; private set; }
        // 책 리스트에서 책 이름 Text 리스트
        private List<TMP_Text> returnBookTitleList;
        // getter
        public List<TMP_Text> ReturnBookTitleList => returnBookTitleList;
        // 책 리스트에서 책 상태 Text 객체들을 담고 있는 컨테이너 오브젝트
        [field: SerializeField] public GameObject ReturnBookStateContainer { get; private set; }
        // 책 리스트에서 책 상태 Text 리스트
        private List<TMP_Text> returnBookStateList;
        // getter
        public List<TMP_Text> ReturnBookStateList => returnBookStateList;

        // 인식 된 권수, 반납 완료 권수 나타내는 오브젝트
        [SerializeField] private GameObject bookReturnStatusObj;
        // getter
        public GameObject BookReturnStatusObj => bookReturnStatusObj;
        // 인식 된 권수, 반납 완료 권수 의 Text 객체들 (0 : 제목, 1 : 권 수)
        private List<TMP_Text> bookReturnStatusTitleList = new List<TMP_Text>();
        // getter
        public List<TMP_Text> BookReturnStatusTitleList => bookReturnStatusTitleList;


        // 반납 버튼
        [field: SerializeField] public Button BtnReturn { get; private set; }


        #endregion

        private void Awake()
        {
            if (canvasList.Count < 0 || canvasList.Count > (int)ECanvas.MaxCnt) return;
            if (popupList.Count < 0 || popupList.Count > (int)EPopup.MaxCnt) return;

            DeActiveAllCanvas();
            DeActiveAllPopup();

            #region Home 

            // idx -> 0 : Name , 1 : Year , 2 : MonthDay
            if (null == HomePageLoanDate || null == HomePageReturnDate) return;
            homePageLoanDateTxtList = new List<TMP_Text>(HomePageLoanDate.GetComponentsInChildren<TMP_Text>());
            homePageReturnDateTxtList = new List<TMP_Text>(HomePageReturnDate.GetComponentsInChildren<TMP_Text>());

            #endregion

            #region Loan

            if (null == LoanBookTitleContainer) Debug.LogWarning("LoanBookTitleContainer 미설정");
            TMP_Text[] loanTitleArray = LoanBookTitleContainer.GetComponentsInChildren<TMP_Text>();
            if (0 < loanTitleArray.Length) loanBookTitleList = new List<TMP_Text>(loanTitleArray);

            if (null == LoanBookStateContainer) Debug.LogWarning("LoanBookStateContainer 미설정");
            TMP_Text[] loanStateArray = LoanBookStateContainer.GetComponentsInChildren<TMP_Text>();
            if (0 < loanTitleArray.Length) loanBookStateList = new List<TMP_Text>(loanStateArray);

            if (null == loanInfoContainer) Debug.LogWarning("loanInfoContainer 미설정");
            TMP_Text[] loanInfoArray = loanInfoContainer.GetComponentsInChildren<TMP_Text>();
            if (0 < loanInfoArray.Length) LoanInfoTextList = new List<TMP_Text>(loanInfoArray);

            // BookLoanStatusTitle/CountList -> idx:0 = 좌측, idx:1 = 우측
            foreach(GameObject obj in bookLoanStatusObjList)
            {
                TMP_Text[] arrTxt = obj.GetComponentsInChildren<TMP_Text>();
                bookLoanStatusTitleList.Add(arrTxt[0]);
                bookLoanStatusCountList.Add(arrTxt[1]);
            }

            if (null == BtnLoan) Debug.LogWarning("BtnLoan 미설정");

            // idx -> 0 : Name , 1 : Year , 2 : MonthDay
            if (null == LoanPageLoanDate || null == LoanPageReturnDate) return;
            loanPageLoanDateTxtList = new List<TMP_Text>(LoanPageLoanDate.GetComponentsInChildren<TMP_Text>());
            loanPageReturnDateTxtList = new List<TMP_Text>(LoanPageReturnDate.GetComponentsInChildren<TMP_Text>());

            #endregion

            #region Return

            // idx -> 0 : Name , 1 : Year , 2 : MonthDay
            if (null == ReturnPageReturnDate) Debug.LogWarning("ReturnPageReturnDate 미설정");
            returnPageReturnDateTxtList = new List<TMP_Text>(ReturnPageReturnDate.GetComponentsInChildren<TMP_Text>());

            if (null == ReturnBookTitleContainer) Debug.LogWarning("ReturnBookTitleContainer 미설정");
            TMP_Text[] returnTitleArray = ReturnBookTitleContainer.GetComponentsInChildren<TMP_Text>();
            if (0 < returnTitleArray.Length) returnBookTitleList = new List<TMP_Text>(returnTitleArray);

            if (null == ReturnBookStateContainer) Debug.LogWarning("ReturnBookStateContainer 미설정");
            TMP_Text[] returnStateArray = ReturnBookStateContainer.GetComponentsInChildren<TMP_Text>();
            if (0 < returnStateArray.Length) returnBookStateList = new List<TMP_Text>(returnStateArray);

            if (null == bookReturnStatusObj) Debug.LogWarning("bookReturnStatusObj 미설정");
            bookReturnStatusTitleList = new List<TMP_Text>(bookReturnStatusObj.GetComponentsInChildren<TMP_Text>());

            if (null == BtnReturn) Debug.LogWarning("BtnReturn 미설정");

            #endregion

        }

        void Start()
        {
            // Panel 의 RaycastTarget : true -> false (off)
            RaycastTargetOff();
        }

        private void RaycastTargetOff()
        {
            foreach (Canvas canvas in canvasList)
            {
                GameObject panel = canvas.gameObject.GetComponentInChildren<PanelMarker>().gameObject;
                panel.GetComponent<Image>().raycastTarget = false;
            }
        }

        private void DeActiveAllCanvas()
        {
            foreach (Canvas canvas in canvasList)
            {
                canvas.gameObject.SetActive(false);
            }
        }
        
        public void ControlLoanBookList(int idx, string title, string state)
        {
            if (idx >= loanBookTitleList.Count) return;

            loanBookTitleList[idx].text = title;
            loanBookStateList[idx].text = state;
        }

        public void ActiveControlCanvas(ECanvas target, bool flag)
        {
            canvasList[(int)target].gameObject.SetActive(flag);
        }

        private void DeActiveAllPopup()
        {
            foreach (GameObject obj in popupList)
            {
                obj.SetActive(false);
            }
        }

        public void ActiveControlPopup(EPopup target, bool flag)
        {
            canvasList[(int)ECanvas.Popup].gameObject.SetActive(flag);
            popupList[(int)target].SetActive(flag);
        }

        public void ControlReturnBookList(int idx, string title, string state)
        {
            if (idx >= returnBookTitleList.Count) return;

            returnBookTitleList[idx].text = title;
            returnBookStateList[idx].text = state;
        }


    }
}

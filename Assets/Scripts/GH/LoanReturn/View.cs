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
        // ���� ����
        [field: SerializeField] public GameObject HomePageLoanDate { get; private set; }
        // �ݳ� ����
        [field: SerializeField] public GameObject HomePageReturnDate { get; private set; }
        // ���� ������ Text ��ü�� (0 : ����, 1 : Year, 2 : Month + Day)
        private List<TMP_Text> homePageLoanDateTxtList;
        public List<TMP_Text> HomePageLoanDateTxtList => homePageLoanDateTxtList;
        // �ݳ� ������ Text ��ü�� (0 : ����, 1 : Year, 2 : Month + Day)
        private List<TMP_Text> homePageReturnDateTxtList;
        public List<TMP_Text> HomePageReturnDateTxtList => homePageReturnDateTxtList;

        #endregion


        /// <summary>
        /// 
        /// </summary>
        #region Loan Page Field

        [field: Header("Loan")]
        // å ����Ʈ���� å �̸� Text ��ü���� ��� �ִ� �����̳� ������Ʈ
        [field: SerializeField] public GameObject LoanBookTitleContainer { get; private set; }
        // å ����Ʈ���� å ���� Text ��ü���� ��� �ִ� �����̳� ������Ʈ
        [field: SerializeField] public GameObject LoanBookStateContainer { get; private set; }
        // å ����Ʈ���� å �̸� Text ����Ʈ
        private List<TMP_Text> loanBookTitleList;
        // getter
        public List<TMP_Text> LoanBookTitleList => loanBookTitleList;
        // å ����Ʈ���� å ���� Text ����Ʈ
        private List<TMP_Text> loanBookStateList;
        // getter
        public List<TMP_Text> LoanBookStateList => loanBookStateList;
        // ���� ��ư ��� �˸� �޼��� ��ü
        [SerializeField] private GameObject loanInfoContainer;
        // �˸� �޼��� ��ü�� �ؽ�Ʈ ����Ʈ
        public List<TMP_Text> LoanInfoTextList { get; private set; }
        // ���� ���ɱǼ�, �߰� ���� ���� �Ǽ�, �ν� �� �Ǽ�, ���� �� �Ǽ� ��Ÿ���� ������Ʈ ����Ʈ (0 : ����, 1 : ����)
        [SerializeField] private List<GameObject> bookLoanStatusObjList;
        // getter
        public List<GameObject> BookLoanStatusObjectList => bookLoanStatusObjList;
        // ���� ���ɱǼ�, �߰� ���� ���� �Ǽ� �� Text ��ü�� (0 : ����, 1 : �� ��)
        private List<TMP_Text> bookLoanStatusTitleList = new List<TMP_Text>();
        // getter
        public List<TMP_Text> BookLoanStatusTitleList => bookLoanStatusTitleList;
        // �ν� �� �Ǽ�, ���� �� �Ǽ� �� Text ��ü�� (0 : ����, 1 : �� ��)
        private List<TMP_Text> bookLoanStatusCountList = new List<TMP_Text>();
        // getter
        public List<TMP_Text> BookLoanStatusCountList => bookLoanStatusCountList;
        // ���� ��ư
        [field: SerializeField] public Button BtnLoan { get; private set; }
        // ���� ����
        [field: SerializeField] public GameObject LoanPageLoanDate { get; private set; }
        // �ݳ� ����
        [field: SerializeField] public GameObject LoanPageReturnDate { get; private set; }
        // ���� ������ Text ��ü�� (0 : ����, 1 : Year, 2 : Month + Day)
        private List<TMP_Text> loanPageLoanDateTxtList;
        // getter
        public List<TMP_Text> LoanPageLoanDateTxtList => loanPageLoanDateTxtList;
        // �ݳ� ������ Text ��ü�� (0 : ����, 1 : Year, 2 : Month + Day)
        private List<TMP_Text> loanPageReturnDateTxtList;
        // getter
        public List<TMP_Text> LoanPageReturnDateTxtList => loanPageReturnDateTxtList;

        #endregion


        /// <summary>
        /// 
        /// </summary>
        #region Return Page Field

        [field: Header("Return")]
        // �ݳ� ����
        [field: SerializeField] public GameObject ReturnPageReturnDate { get; private set; }
        // �ݳ� ������ Text ��ü�� (0 : ����, 1 : Year, 2 : Month + Day)
        private List<TMP_Text> returnPageReturnDateTxtList;
        public List<TMP_Text> ReturnPageReturnDateTxtList => returnPageReturnDateTxtList;
        // å ����Ʈ���� å �̸� Text ��ü���� ��� �ִ� �����̳� ������Ʈ
        [field: SerializeField] public GameObject ReturnBookTitleContainer { get; private set; }
        // å ����Ʈ���� å �̸� Text ����Ʈ
        private List<TMP_Text> returnBookTitleList;
        // getter
        public List<TMP_Text> ReturnBookTitleList => returnBookTitleList;
        // å ����Ʈ���� å ���� Text ��ü���� ��� �ִ� �����̳� ������Ʈ
        [field: SerializeField] public GameObject ReturnBookStateContainer { get; private set; }
        // å ����Ʈ���� å ���� Text ����Ʈ
        private List<TMP_Text> returnBookStateList;
        // getter
        public List<TMP_Text> ReturnBookStateList => returnBookStateList;

        // �ν� �� �Ǽ�, �ݳ� �Ϸ� �Ǽ� ��Ÿ���� ������Ʈ
        [SerializeField] private GameObject bookReturnStatusObj;
        // getter
        public GameObject BookReturnStatusObj => bookReturnStatusObj;
        // �ν� �� �Ǽ�, �ݳ� �Ϸ� �Ǽ� �� Text ��ü�� (0 : ����, 1 : �� ��)
        private List<TMP_Text> bookReturnStatusTitleList = new List<TMP_Text>();
        // getter
        public List<TMP_Text> BookReturnStatusTitleList => bookReturnStatusTitleList;


        // �ݳ� ��ư
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

            if (null == LoanBookTitleContainer) Debug.LogWarning("LoanBookTitleContainer �̼���");
            TMP_Text[] loanTitleArray = LoanBookTitleContainer.GetComponentsInChildren<TMP_Text>();
            if (0 < loanTitleArray.Length) loanBookTitleList = new List<TMP_Text>(loanTitleArray);

            if (null == LoanBookStateContainer) Debug.LogWarning("LoanBookStateContainer �̼���");
            TMP_Text[] loanStateArray = LoanBookStateContainer.GetComponentsInChildren<TMP_Text>();
            if (0 < loanTitleArray.Length) loanBookStateList = new List<TMP_Text>(loanStateArray);

            if (null == loanInfoContainer) Debug.LogWarning("loanInfoContainer �̼���");
            TMP_Text[] loanInfoArray = loanInfoContainer.GetComponentsInChildren<TMP_Text>();
            if (0 < loanInfoArray.Length) LoanInfoTextList = new List<TMP_Text>(loanInfoArray);

            // BookLoanStatusTitle/CountList -> idx:0 = ����, idx:1 = ����
            foreach(GameObject obj in bookLoanStatusObjList)
            {
                TMP_Text[] arrTxt = obj.GetComponentsInChildren<TMP_Text>();
                bookLoanStatusTitleList.Add(arrTxt[0]);
                bookLoanStatusCountList.Add(arrTxt[1]);
            }

            if (null == BtnLoan) Debug.LogWarning("BtnLoan �̼���");

            // idx -> 0 : Name , 1 : Year , 2 : MonthDay
            if (null == LoanPageLoanDate || null == LoanPageReturnDate) return;
            loanPageLoanDateTxtList = new List<TMP_Text>(LoanPageLoanDate.GetComponentsInChildren<TMP_Text>());
            loanPageReturnDateTxtList = new List<TMP_Text>(LoanPageReturnDate.GetComponentsInChildren<TMP_Text>());

            #endregion

            #region Return

            // idx -> 0 : Name , 1 : Year , 2 : MonthDay
            if (null == ReturnPageReturnDate) Debug.LogWarning("ReturnPageReturnDate �̼���");
            returnPageReturnDateTxtList = new List<TMP_Text>(ReturnPageReturnDate.GetComponentsInChildren<TMP_Text>());

            if (null == ReturnBookTitleContainer) Debug.LogWarning("ReturnBookTitleContainer �̼���");
            TMP_Text[] returnTitleArray = ReturnBookTitleContainer.GetComponentsInChildren<TMP_Text>();
            if (0 < returnTitleArray.Length) returnBookTitleList = new List<TMP_Text>(returnTitleArray);

            if (null == ReturnBookStateContainer) Debug.LogWarning("ReturnBookStateContainer �̼���");
            TMP_Text[] returnStateArray = ReturnBookStateContainer.GetComponentsInChildren<TMP_Text>();
            if (0 < returnStateArray.Length) returnBookStateList = new List<TMP_Text>(returnStateArray);

            if (null == bookReturnStatusObj) Debug.LogWarning("bookReturnStatusObj �̼���");
            bookReturnStatusTitleList = new List<TMP_Text>(bookReturnStatusObj.GetComponentsInChildren<TMP_Text>());

            if (null == BtnReturn) Debug.LogWarning("BtnReturn �̼���");

            #endregion

        }

        void Start()
        {
            // Panel �� RaycastTarget : true -> false (off)
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

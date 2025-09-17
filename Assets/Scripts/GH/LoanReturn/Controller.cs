using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GH_LoanReturn
{
    public enum ECanvas
    {
        Base,
        Popup,
        Home,
        Loan,
        Return,
        MaxCnt = 5,
    }

    public enum EPopup
    {
        Membership,
        Password,
        Loading,
        MaxCnt = 3,
    }

    public class Controller : MonoBehaviour
    {
        [field: Header("MVC")]
        [field: SerializeField] public Model model { get; private set; }
        [field: SerializeField] public View view { get; private set; }

        private bool bStartRecogBook;

        private void Awake()
        {
            if (null == model) { Debug.LogError("Model 객체가 설정되지 않았습니다."); return; }
            if (null == view) { Debug.LogError("View 객체가 설정되지 않았습니다."); return; }

            bStartRecogBook = false;
        }

        void Start()
        {
            // 반납/대출 화면 초기세팅
            InitUI();
        }

        /// <summary>
        /// 
        /// </summary>
        #region Home Page

        private void InitUI()
        {
            InitHomePage();

            view.ActiveControlCanvas(ECanvas.Base, true);
            view.ActiveControlCanvas(ECanvas.Home, true);
        }

        private void InitHomePage()
        {
            // 대출 반납일 설정
            SetLoanReturnDate(view.HomePageLoanDateTxtList, view.HomePageReturnDateTxtList);
        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        #region Loan Page

        public void ClickMoveLoanPage()
        {
            view.ActiveControlPopup(EPopup.Membership, true);

            // 대출/반납 페이지 초기세팅
            InitLoanPage();

            StartCoroutine(CheckMembership());
        }

        private void InitLoanPage()
        {
            // 책목록 초기화
            for (int i = 0; i < view.LoanBookTitleList.Count; ++i)
                view.ControlLoanBookList(i, "-", "-");

            // 안내메세지 멘트 초기설정
            view.LoanInfoTextList[0].text = model.LoanInfoStringList[0];
            view.LoanInfoTextList[0].fontSize = 18;
            view.LoanInfoTextList[1].text = model.LoanInfoStringList[1];

            // 책 대출 정보 초기 설정
            view.BookLoanStatusTitleList[0].text = "대출 가능 권수";
            view.BookLoanStatusCountList[0].text = "-권";
            view.BookLoanStatusTitleList[1].text = "인식 된 권수";
            view.BookLoanStatusCountList[1].text = "-권";

            // 대출 버튼 초기 설정
            view.BtnLoan.GetComponentInChildren<TMP_Text>().text = "대출 하기";
            view.BtnLoan.onClick.RemoveAllListeners();
            view.BtnLoan.onClick.AddListener(ClickTryLoan);

            // 대출 반납일 설정
            SetLoanReturnDate(view.LoanPageLoanDateTxtList, view.LoanPageReturnDateTxtList);
        }

        private void SetLoanReturnDate(List<TMP_Text> loanList, List<TMP_Text> returnList)
        {
            DateTime now = DateTime.Now;
            loanList[0].text = "대출 일자"; // name
            loanList[1].text = $"{now.Year}.";  // year
            loanList[2].text = $"{now.Month}.{now.Day}";  // moth+day
            DateTime future = now.AddDays(7);
            returnList[0].text = "반납 일자"; // name
            returnList[1].text = $"{future.Year}.";  // year
            returnList[2].text = $"{future.Month}.{future.Day}";  // moth+day
        }

        private IEnumerator CheckMembership()
        {
            // 키 입력이 들어올 때까지 대기
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));

            // 회원카드 인식 후 API 통신으로 회원확인하는 로직 추가 예정

            // 키가 눌리면 실행
            view.ActiveControlPopup(EPopup.Membership, false);
            view.ActiveControlCanvas(ECanvas.Home, false);
            view.ActiveControlCanvas(ECanvas.Loan, true);

            // 책 인식 시작
            bStartRecogBook = true;
            StartCoroutine(RecogBook());
        }

        private IEnumerator RecogBook()
        {
            // 책을 인식하는 로직 추가 예정
            Debug.Log("책 인식 시작");

            while (bStartRecogBook)
            {
                Debug.Log("책 인식중...");
                yield return null;
            }

            Debug.Log("책 인식 종료");
        }

        private void ClickTryLoan()
        {
            // 책 인식 종료
            bStartRecogBook = false;

            view.ActiveControlPopup(EPopup.Password, true);

            StartCoroutine(CheckPassword());
        }

        private IEnumerator CheckPassword()
        {
            // API 통신을 통해 입력 받은 패스워드가 맞는지 확인하는 로직 추가 예정

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));

            view.ActiveControlPopup(EPopup.Password, false);
            view.ActiveControlPopup(EPopup.Loading, true);

            StartCoroutine(ProcessLoan());
        }

        private IEnumerator ProcessLoan()
        {
            // API 통신을 통해 책 대출하는 로직 추가 예정

            yield return null;
            //Debug.Log(Input.GetKeyDown(KeyCode.Q));

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));

            view.ActiveControlPopup(EPopup.Loading, false);

            // 대출 안내 메세지 변경 로직 추가 예정
            view.LoanInfoTextList[0].text = model.LoanInfoStringList[2];
            view.LoanInfoTextList[0].fontSize = 20; // font size : 18 -> 20
            view.LoanInfoTextList[1].text = "";

            // 
            view.BookLoanStatusTitleList[0].text = "추가 대출 가능 권수";
            view.BookLoanStatusCountList[0].text = "-권";
            view.BookLoanStatusTitleList[1].text = "대출 완료 권수";
            view.BookLoanStatusCountList[1].text = "-권";

            // 대출 버튼 변경 : "대출 하기" -> "완료 하기" 
            view.BtnLoan.GetComponentInChildren<TMP_Text>().text = "완료 하기";
            view.BtnLoan.onClick.RemoveAllListeners();
            view.BtnLoan.onClick.AddListener(ClickEndLoan);
        }

        private void ClickEndLoan()
        {
            view.ActiveControlCanvas(ECanvas.Home, true);
            view.ActiveControlCanvas(ECanvas.Loan, false);
        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        #region Return Page
        public void ClickMoveReturnPage()
        {
            InitReturnPage();

            view.ActiveControlCanvas(ECanvas.Home, false);
            view.ActiveControlCanvas(ECanvas.Return, true);

        }

        private void InitReturnPage()
        {
            // 반납일 설정
            DateTime future = DateTime.Now.AddDays(7);
            view.ReturnPageReturnDateTxtList[0].text = "반납 일자"; // name
            view.ReturnPageReturnDateTxtList[1].text = $"{future.Year}.";  // year
            view.ReturnPageReturnDateTxtList[2].text = $"{future.Month}.{future.Day}";  // moth+day

            // 책목록 초기화
            for (int i = 0; i < view.LoanBookTitleList.Count; ++i)
                view.ControlReturnBookList(i, "-", "-");

            // 인식 된 권수
            view.BookReturnStatusTitleList[0].text = "인식 된 권수";
            view.BookReturnStatusTitleList[1].text = "-권";

            // 반납 버튼 초기 설정
            view.BtnReturn.onClick.RemoveAllListeners();
            view.BtnReturn.GetComponentInChildren<TMP_Text>().text = "반납 하기";
            view.BtnReturn.onClick.AddListener(ClickTryReturn);
        }

        private void ClickTryReturn()
        {
            view.ActiveControlPopup(EPopup.Loading, true);
            StartCoroutine(ProcessReturn());
        }

        private IEnumerator ProcessReturn()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));

            view.ActiveControlPopup(EPopup.Loading, false);

            // 인식 된 권수
            view.BookReturnStatusTitleList[0].text = "반납 완료 권수";
            view.BookReturnStatusTitleList[1].text = "-권";

            // 반납 버튼 설정
            view.BtnReturn.onClick.RemoveAllListeners();
            view.BtnReturn.GetComponentInChildren<TMP_Text>().text = "완료 하기";
            view.BtnReturn.onClick.AddListener(ClickEndReturn);
        }

        private void ClickEndReturn()
        {
            view.ActiveControlCanvas(ECanvas.Home, true);
            view.ActiveControlCanvas(ECanvas.Return, false);
        }

        #endregion

    }
}

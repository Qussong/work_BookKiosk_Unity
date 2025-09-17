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
            if (null == model) { Debug.LogError("Model ��ü�� �������� �ʾҽ��ϴ�."); return; }
            if (null == view) { Debug.LogError("View ��ü�� �������� �ʾҽ��ϴ�."); return; }

            bStartRecogBook = false;
        }

        void Start()
        {
            // �ݳ�/���� ȭ�� �ʱ⼼��
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
            // ���� �ݳ��� ����
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

            // ����/�ݳ� ������ �ʱ⼼��
            InitLoanPage();

            StartCoroutine(CheckMembership());
        }

        private void InitLoanPage()
        {
            // å��� �ʱ�ȭ
            for (int i = 0; i < view.LoanBookTitleList.Count; ++i)
                view.ControlLoanBookList(i, "-", "-");

            // �ȳ��޼��� ��Ʈ �ʱ⼳��
            view.LoanInfoTextList[0].text = model.LoanInfoStringList[0];
            view.LoanInfoTextList[0].fontSize = 18;
            view.LoanInfoTextList[1].text = model.LoanInfoStringList[1];

            // å ���� ���� �ʱ� ����
            view.BookLoanStatusTitleList[0].text = "���� ���� �Ǽ�";
            view.BookLoanStatusCountList[0].text = "-��";
            view.BookLoanStatusTitleList[1].text = "�ν� �� �Ǽ�";
            view.BookLoanStatusCountList[1].text = "-��";

            // ���� ��ư �ʱ� ����
            view.BtnLoan.GetComponentInChildren<TMP_Text>().text = "���� �ϱ�";
            view.BtnLoan.onClick.RemoveAllListeners();
            view.BtnLoan.onClick.AddListener(ClickTryLoan);

            // ���� �ݳ��� ����
            SetLoanReturnDate(view.LoanPageLoanDateTxtList, view.LoanPageReturnDateTxtList);
        }

        private void SetLoanReturnDate(List<TMP_Text> loanList, List<TMP_Text> returnList)
        {
            DateTime now = DateTime.Now;
            loanList[0].text = "���� ����"; // name
            loanList[1].text = $"{now.Year}.";  // year
            loanList[2].text = $"{now.Month}.{now.Day}";  // moth+day
            DateTime future = now.AddDays(7);
            returnList[0].text = "�ݳ� ����"; // name
            returnList[1].text = $"{future.Year}.";  // year
            returnList[2].text = $"{future.Month}.{future.Day}";  // moth+day
        }

        private IEnumerator CheckMembership()
        {
            // Ű �Է��� ���� ������ ���
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));

            // ȸ��ī�� �ν� �� API ������� ȸ��Ȯ���ϴ� ���� �߰� ����

            // Ű�� ������ ����
            view.ActiveControlPopup(EPopup.Membership, false);
            view.ActiveControlCanvas(ECanvas.Home, false);
            view.ActiveControlCanvas(ECanvas.Loan, true);

            // å �ν� ����
            bStartRecogBook = true;
            StartCoroutine(RecogBook());
        }

        private IEnumerator RecogBook()
        {
            // å�� �ν��ϴ� ���� �߰� ����
            Debug.Log("å �ν� ����");

            while (bStartRecogBook)
            {
                Debug.Log("å �ν���...");
                yield return null;
            }

            Debug.Log("å �ν� ����");
        }

        private void ClickTryLoan()
        {
            // å �ν� ����
            bStartRecogBook = false;

            view.ActiveControlPopup(EPopup.Password, true);

            StartCoroutine(CheckPassword());
        }

        private IEnumerator CheckPassword()
        {
            // API ����� ���� �Է� ���� �н����尡 �´��� Ȯ���ϴ� ���� �߰� ����

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));

            view.ActiveControlPopup(EPopup.Password, false);
            view.ActiveControlPopup(EPopup.Loading, true);

            StartCoroutine(ProcessLoan());
        }

        private IEnumerator ProcessLoan()
        {
            // API ����� ���� å �����ϴ� ���� �߰� ����

            yield return null;
            //Debug.Log(Input.GetKeyDown(KeyCode.Q));

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));

            view.ActiveControlPopup(EPopup.Loading, false);

            // ���� �ȳ� �޼��� ���� ���� �߰� ����
            view.LoanInfoTextList[0].text = model.LoanInfoStringList[2];
            view.LoanInfoTextList[0].fontSize = 20; // font size : 18 -> 20
            view.LoanInfoTextList[1].text = "";

            // 
            view.BookLoanStatusTitleList[0].text = "�߰� ���� ���� �Ǽ�";
            view.BookLoanStatusCountList[0].text = "-��";
            view.BookLoanStatusTitleList[1].text = "���� �Ϸ� �Ǽ�";
            view.BookLoanStatusCountList[1].text = "-��";

            // ���� ��ư ���� : "���� �ϱ�" -> "�Ϸ� �ϱ�" 
            view.BtnLoan.GetComponentInChildren<TMP_Text>().text = "�Ϸ� �ϱ�";
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
            // �ݳ��� ����
            DateTime future = DateTime.Now.AddDays(7);
            view.ReturnPageReturnDateTxtList[0].text = "�ݳ� ����"; // name
            view.ReturnPageReturnDateTxtList[1].text = $"{future.Year}.";  // year
            view.ReturnPageReturnDateTxtList[2].text = $"{future.Month}.{future.Day}";  // moth+day

            // å��� �ʱ�ȭ
            for (int i = 0; i < view.LoanBookTitleList.Count; ++i)
                view.ControlReturnBookList(i, "-", "-");

            // �ν� �� �Ǽ�
            view.BookReturnStatusTitleList[0].text = "�ν� �� �Ǽ�";
            view.BookReturnStatusTitleList[1].text = "-��";

            // �ݳ� ��ư �ʱ� ����
            view.BtnReturn.onClick.RemoveAllListeners();
            view.BtnReturn.GetComponentInChildren<TMP_Text>().text = "�ݳ� �ϱ�";
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

            // �ν� �� �Ǽ�
            view.BookReturnStatusTitleList[0].text = "�ݳ� �Ϸ� �Ǽ�";
            view.BookReturnStatusTitleList[1].text = "-��";

            // �ݳ� ��ư ����
            view.BtnReturn.onClick.RemoveAllListeners();
            view.BtnReturn.GetComponentInChildren<TMP_Text>().text = "�Ϸ� �ϱ�";
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

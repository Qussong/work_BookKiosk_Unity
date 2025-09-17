using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GH_LoanReturn
{
    public class Model : MonoBehaviour
    {
        #region Loan Page

        private List<string> loanInfoStringList = new List<string>();
        public List<string> LoanInfoStringList => loanInfoStringList;

        #endregion

        private void Awake()
        {
            SetLoanPageString();
        }

        private void SetLoanPageString()
        {
            // 대출 안내
            LoanInfoStringList.Add("대출할 책을 모두 스캔하였으면 [대출] 버튼을 눌러주세요");
            LoanInfoStringList.Add("책 상태가 대출 불가능인 경우 포데스크에 문의해주세요.");
            LoanInfoStringList.Add("대출이 완료 되었습니다. 반납 예정일을 확인하세요.");
        }

    }
}

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
            // ���� �ȳ�
            LoanInfoStringList.Add("������ å�� ��� ��ĵ�Ͽ����� [����] ��ư�� �����ּ���");
            LoanInfoStringList.Add("å ���°� ���� �Ұ����� ��� ������ũ�� �������ּ���.");
            LoanInfoStringList.Add("������ �Ϸ� �Ǿ����ϴ�. �ݳ� �������� Ȯ���ϼ���.");
        }

    }
}

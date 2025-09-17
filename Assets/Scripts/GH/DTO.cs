using UnityEngine;

namespace CheckInOut
{ 

    public class DTO : MonoBehaviour { }

    #region API

    // ȸ�� �α���
    namespace UserLogin
    {
        [System.Serializable]
        public class Root
        {
            public string RESULT_INFO;  // SUCCESS, ERROR
            public UserData USER_DATA;
            public string RESULT_MESSAGE;
        }

        [System.Serializable]
        public class UserData
        {
            public string REC_KEY;
            public string USER_NO;
            public string NAME;
            public string USER_ID;
            public string USER_CLASS;
            public string USER_CLASS_CODE;
            public string KL_MEMBER_YN;
            public string USER_POSITION_CODE;
            public string USER_MANAGE_CODE;
            public string SELF_LOAN_STATION_LIMIT;
            public string HANDPHONE;
            public string SMS_USE_YN;
            public string E_MAIL; // null�̸� C#���� null�� ���ɴϴ�.
            public string MAILING_USE_YN;
            public string SCHOOL;
            public string GRADE;
            public string SCHOOL_CLASS;
            public string CLASS_NO;
            public string PW_RENEWAL_DATE;   // "2025/08/07"�� �������ô� �ڵ� ó����
            public string KEYWORD_ALARM_YN;
            public string NON_CONTACT_CNT;
            public string NON_CONTACT_MAX_CNT;
            public string SECOND_CONTACT;
            public string SAFE_USER_NO;
            public string DLS_ID;
            public string CARD_PASSWORD_YN;
            public string FAMILY_ID;
            public string LOAN_STOP_DATE;
            public int OVERDUE_CNT;       // JSON���� ���ڸ� int�� �޾Ƶ� OK
            public int LOCAL_LOANABLE_CNT;
            public int UNITY_LOANABLE_CNT;
            public int LOCAL_LOAN_CNT;
            public int UNITY_LOAN_CNT;
            public string LOST_CARD_YN;
            public string MEMBER_CLASS;
            public int USER_CLASS_BOOKABLE_CNT;
            public string BIRTHDAY;          // "2003/05/01"
            public string GPIN_SEX;
            public string CERT_YN;
            public string AGREEMENT_YN;
            public string STATEMENT_ALIAS;
            public string AGREE_DATE;        // "2025/08/11"
            public string EXPIRE_DATE;       // "2027/08/11"
            public string EXPIREDATE_YN;
            public string AGREE_YN;
            public string ACCOUNT_NO;
            public int LILL_EXPIRE_RETURN_CNT;
            public string PW_RENEWAL_YN;
        }
    }

    // ���� ���δ��� ���� ���� Ȯ��
    namespace UnmannedLoanCheck
    {
        [System.Serializable]
        public class Root
        {
            public string RESULT_INFO;  // OK, ERROR
            public string RESULT_CODE;
            public string RESULT_MESSAGE;
        }
    }

    // ���� ���ιݳ� ���� ���� Ȯ��
    namespace UnmannedReturnCheck
    {
        [System.Serializable]
        public class Root
        {
            public string RESULT_INFO;  // OK, ERROR
            public string RESULT_CODE;
            public string RESULT_MESSAGE;
        }
    }

    // ���� ����
    namespace UnmannedLoan
    {
        [System.Serializable]
        public class Root
        {
            public string RESULT_INFO;  // SUCCESS, ERROR
            public string LOAN_KEY;
            public string RETURN_PLAN_DATE; // "2025/09/16 23:59:59"
            public string RESULT_CODE;
            public string RESULT_MESSAGE;
        }
    }

    // ���� �ݳ�
    namespace UnmannedReturn
    {
        [System.Serializable]
        public class Root
        {
            public string RESULT_INFO;  // SUCCESS, ERROR
            public string USER_NO;
            public string NAME;
            public string LOAN_KEY;
            public string RESULT_CODE;
            public string RESULT_MESSAGE;
        }
    }

    #endregion

    #region CSV

    namespace CSV
    {
        public class StringTable
        {
            public string Key;
            public string kr;
            public string en;
            public string jp;
            public string cn;
        }
    }

    #endregion

    /*#region Time

    namespace Time
    {
        [System.Serializable]
        public class TimeTable
        {
            public int year;   // ��
            public int month;  // ��
            public int day;    // ��
            public int hour;   // ��
            public int min;    // ��
            public int sec;    // ��

            public string GetCurrentTime()
            {
                return $"{year}-{month}-{day} {hour}:{min}:{sec}";
            }
        }
    }

    #endregion*/

}
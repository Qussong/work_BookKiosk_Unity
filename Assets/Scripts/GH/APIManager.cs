using System;
using System.Collections;
using System.IO;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Networking;

namespace CheckInOut
{
    public class APIManager : MonoBehaviour
    {
        //[SerializeField] public Model model;
        [field: SerializeField, ReadOnly] public string SubURL { get; private set; }

        private void Start()
        {
            // http://las.daegu.go.kr:8081/kdotapi/ksearchapi/
            //SubURL = model.Protocol + "://" + model.Domain + ":" + model.Port + "/" + model.Path + "/";
            
        }

        private IEnumerator WebRequestGet<T>(string url, Action<T> action)
        {
            // GET 요청
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                //Debug.Log("request GET");

                // 요청 보냄 (비동기 = Unity 메인 스레드 멈추지 않음)
                yield return request.SendWebRequest();

                // 응답 확인 (변수 response 에 값 저장)
                //if (request.isNetworkError || request.isHttpError)
                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Error : {request.error}");
                }
                else
                {
                    // 서버에서 받은 응답 출력
                    //Debug.Log($"Response : {request.downloadHandler.text}");
                    //Debug.Log("Success");
                }
                T response = JsonUtility.FromJson<T>(request.downloadHandler.text);

                //
                action?.Invoke(response);
            }
        }

        public void TestCall()
        {
        }

        public void CheckIn()
        {
        }

        public void CheckOut()
        {
        }

        // 30) 회원 로그인 (userlogin)
        // Parameter : option, user_no, api_key
        #region UserLogin
        public void UserLogin()
        {
            string request = "userlogin";
            string option = "3";
            // string URL = SubURL + $"{request}?option={option}&user_no={model.UserNo}&api_key={model.APIKey}";
            // StartCoroutine(WebRequestGet<UserLogin.Root>(URL, UserLoginFunc));
        }

        private void UserLoginFunc(UserLogin.Root response)
        {
            if("SUCCESS" == response.RESULT_INFO)
            {
                string userKey = response.USER_DATA.REC_KEY;
                string userName = response.USER_DATA.NAME;
                Debug.Log($"user key : {userKey}, user name : {userName}");
            }
            // ERROR
            else
            {
                Debug.LogWarning(response.RESULT_MESSAGE);
            }
        }
        #endregion

        // 57) 무인대출 가능여부 확인 (unmannedloancheck)
        // Parameter : manage_code, userkey, reg_no, device_name, client_ip
        #region UnmannedLoanCheck
        public void UnmannedLoanCheck()
        {
            string request = "unmannedloancheck";
            // string URL = SubURL + $"{request}?manage_code={model.ManageCode}&userkey={model.UserKey}&reg_no={model.RegNo}&device_name={model.DeviceName}&client_ip={model.ClientIP}";
            // StartCoroutine(WebRequestGet<UnmannedLoanCheck.Root>(URL, UnmannedLoanCheckFunc));

        }

        private void UnmannedLoanCheckFunc(UnmannedLoanCheck.Root response)
        {
            if("OK" == response.RESULT_INFO)
            {
                Debug.Log("대출 가능");
            }
            // ERROR
            else
            {
                Debug.LogWarning(response.RESULT_MESSAGE);
            }

        }
        #endregion

        // 58) 무인반납 가능여부 확인 (unmannedreturncheck)
        // Parameter : manage_code, reg_no, device_name, client_ip
        #region UnmannedReturnCheck
        public void UnmannedReturnCheck()
        {
            string request = "unmannedreturncheck";
            // string URL = SubURL + $"{request}?manage_code={model.ManageCode}&reg_no={model.RegNo}&device_name={model.DeviceName}&client_ip={model.ClientIP}";
            // StartCoroutine(WebRequestGet<UnmannedReturnCheck.Root>(URL, UnmannedReturnCheckFun));
        }

        private void UnmannedReturnCheckFun(UnmannedReturnCheck.Root response)
        {
            if("OK" == response.RESULT_INFO)
            {
                Debug.Log("반납 가능");
            }
            // ERROR
            else
            {
                Debug.LogWarning(response.RESULT_MESSAGE);
            }
        }

        #endregion

        // 50) 무인 대출 (unmannedloan)
        // Parameter : manage_code, userkey, reg_no, device_name, client_ip
        #region UnmannedLoan
        public void UnmannedLoan()
        {
            string request = "unmannedloan";
            // string URL = SubURL + $"{request}?manage_code={model.ManageCode}&userkey={model.UserKey}&reg_no={model.RegNo}&device_name={model.DeviceName}&client_ip={model.ClientIP}";
            // StartCoroutine(WebRequestGet<UnmannedLoan.Root>(URL, UnmannedLoanFunc));
        }

        private void UnmannedLoanFunc(UnmannedLoan.Root response)
        {
            if("SUCCESS" == response.RESULT_INFO)
            {

            }
            // ERROR
            else
            {
                Debug.LogWarning(response.RESULT_MESSAGE);
            }
        }

        #endregion

        // 51) 무인 반납 (unmannedreturn)
        // Parameter : manage_code, reg_no, device_name, client_ip
        #region UnmannedReturn
        public void UnmannedReturn()
        {
            string request = "unmannedreturn";
            // string URL = SubURL + $"{request}?client_ip={model.ClientIP}&manage_code={model.ManageCode}&reg_no={model.RegNo}&device_name={model.DeviceName}";
            // StartCoroutine(WebRequestGet<UnmannedReturn.Root>(URL, UnmannedReturnFunc));
        }

        private void UnmannedReturnFunc(UnmannedReturn.Root response)
        {
            if("SUCCESS" == response.RESULT_INFO)
            {
                Debug.Log("반납 완료");
            }
            // ERROR
            else
            {
                Debug.LogWarning(response.RESULT_MESSAGE);
            }
        }

        #endregion

    }

}

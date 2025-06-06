using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBank : MonoBehaviour
{
    [Header("입장 및 퇴장")]
    public GameObject deposit;
    public GameObject withdraw;
    public GameObject sendPanel;

    [Header("금액변경관련")]
    public TextMeshProUGUI balance;
    public TextMeshProUGUI money;
    public TMP_InputField inputText;
    public TMP_InputField outputText;
    
    [Header("오류")]
    public GameObject popupError;
    public GameObject outPutError;
    
    [Header("송금")]
    public TMP_InputField sendTargetIdInput;
    public TMP_InputField sendAmountInput;
    public GameObject sendErrorPanel;
    public TMP_Text sendErrorText;
    
    
    //누름으로서 줄어들고 늘어난 숫자를 UI에 반영해야해
    public void ResetUI()
    {
        balance.text = GameManager.Instance.userData.Balance.ToString("N0");
        money.text = GameManager.Instance.userData.Money.ToString("N0");
    }
    
    #region 입장버튼 & 퇴장버튼

    public void OnClickInDeposit()
    {
        deposit.SetActive(true);
    }

    public void OnClickInWithdraw()
    {
        withdraw.SetActive(true);
    }

    public void OnClickOutDeposit()
    {
        deposit.SetActive(false);
    }

    public void OnClickOutWithdraw()
    {
        withdraw.SetActive(false);
    }

    public void OnClickEnterSend()
    {
        sendPanel.SetActive(true);
    }

    public void OnclickExitSend()
    {
        sendPanel.SetActive(false);
    }

    #endregion

    #region 입금
    
    //정해진 숫자로의 입금이 아닌 타이핑을 통한 입금은?
    //일단 해당 칸에 입력을 하겠지. 옆에 버튼을 누르면. 입력된 값을 비교해서 처리해야겠는데
    //입력한 값을 inputText라고 했고.
    //이걸 amount로 변환해서 . 비교하기.
    //그리고 해당겂으로 더하고 빼기.
    
    public void OnClickInput()
    { 
        string text = inputText.text;
        if (ulong.TryParse(text, out ulong number))
        {
            if (GameManager.Instance.userData.Balance >= number)
            {
                GameManager.Instance.userData.Balance -= number;
                GameManager.Instance.userData.Money += number;

                GameManager.Instance.SaveUserData();
            }
            else
            {
                popupError.SetActive(true);
            }
        }
        else
        {
            Debug.Log("변환 실패");
        }
        
        ResetUI();
    }
    
    public void OnClickInput10000()
    {
        if (GameManager.Instance.userData.Balance >= 10000)
        {
            GameManager.Instance.userData.Balance -= 10000;
            GameManager.Instance.userData.Money += 10000;
            
            GameManager.Instance.SaveUserData();
        }
        else
        {
            popupError.SetActive(true);
        }
        
        Debug.Log("누르긴 눌렀음");
        ResetUI();
    }
    public void OnClickInput30000()
    {
        if (GameManager.Instance.userData.Balance >= 30000)
        {
            GameManager.Instance.userData.Balance -= 30000;
            GameManager.Instance.userData.Money += 30000;
            
            GameManager.Instance.SaveUserData();
        }
        else
        {
            popupError.SetActive(true);
        }
        
        ResetUI();
    }
    public void OnClickInput50000()
    {
        if (GameManager.Instance.userData.Balance >= 50000)
        {
            GameManager.Instance.userData.Balance -= 50000;
            GameManager.Instance.userData.Money += 50000;
            
            GameManager.Instance.SaveUserData();
        }
        else
        {
            popupError.SetActive(true);
        }
        
        ResetUI();
    }

    #endregion

    #region 출금

    public void OnClickOutput()
    { 
        string outText = outputText.text;
        if (ulong.TryParse(outText, out ulong number))
        {
            if (GameManager.Instance.userData.Money >= number)
            {
                GameManager.Instance.userData.Balance += number;
                GameManager.Instance.userData.Money -= number;
                
                GameManager.Instance.SaveUserData();
            }
            else
            {
                outPutError.SetActive(true);
            }
        }
        else
        {
            Debug.Log("변환 실패");
        }
        
        ResetUI();
    }
    public void OnClickOutput10000()
    {
        if (GameManager.Instance.userData.Money >= 10000)
        {
            GameManager.Instance.userData.Balance += 10000;
            GameManager.Instance.userData.Money -= 10000;
            
            GameManager.Instance.SaveUserData();
        }
        else
        {
            outPutError.SetActive(true);
        }
        
        ResetUI();
    }
    public void OnClickOutput30000()
    {
        if (GameManager.Instance.userData.Money >= 30000)
        {
            GameManager.Instance.userData.Balance += 30000;
            GameManager.Instance.userData.Money -= 30000;
            
            GameManager.Instance.SaveUserData();
        }
        else
        {
            outPutError.SetActive(true);
        }
        ResetUI();
    }
    public void OnClickOutput50000()
    {
        if (GameManager.Instance.userData.Money >= 50000)
        {
            GameManager.Instance.userData.Balance += 50000;
            GameManager.Instance.userData.Money -= 50000;
            
            GameManager.Instance.SaveUserData();
        }
        else
        {
            outPutError.SetActive(true);
        }
            
        ResetUI();
    }

    #endregion

    #region 에러 창

       public void OnClickRemoveInputError()
        {
            popupError.SetActive(false);
        }

        public void OnclickRemoveOutputError()
        {
            outPutError.SetActive(false);
        }
    

    #endregion

    #region 송금

    public void OnClickSend()
    {
        string targetId = sendTargetIdInput.text.Trim();
        string amount = sendAmountInput.text.Trim();
        //해당칸 비어있을때,
        if (string.IsNullOrEmpty(targetId))
        {
            ShowSendError("송금 대상을 입력해주세요");
            return;
        }

        if (string.IsNullOrEmpty(amount))
        {
            ShowSendError("송금 금액을 입력해주세요");
            return;
        }
        //해당 숫자 형식에 맞지 않으면 
        if (!ulong.TryParse(amount, out ulong number))
        {
            ShowSendError("송금 형식 맞지 않습니다.");
            return;
        }
        //저장된 아이디가 없을때
        if (!PlayerPrefs.HasKey($"{targetId}/Balance"))
        {
            ShowSendError("존재하지 않는 ID입니다.");
        }
        
        //현재 잔액을 불러오는부분
        ulong mybalance = GameManager.Instance.userData.Balance;
        
        // 만약에 내가 보내려는 금액보다 부족한경우
        if (mybalance < number)
        {
            ShowSendError("잔액이 부족합니다.");
            return;
        }
        //보내주려는 사람의 잔액을 불러와야겠지?
        ulong targetBalance = ulong.Parse(PlayerPrefs.GetString($"{targetId}/Balance","0"));
        
        // 내 잔액 빼기, 그리고 보내는 사람 더해주기
        mybalance -= number;
        targetBalance += number;
        
        //업데이트해주고 저장해주고
        GameManager.Instance.userData.Balance = mybalance;
        GameManager.Instance.SaveUserData();
        
        //PlayerPrefs에도 저장.
        PlayerPrefs.SetString($"{targetId}/Balance", targetBalance.ToString());
        PlayerPrefs.Save();
        
        Debug.Log($"송금 완료 : {number} -> {targetId}에게 송금이요");
        
        ResetUI();
        ShowSendError($"송금완료 {number}원 송금");
    }
    //글씨로 오브젝트 만들기 귀찮으니까 코드로 입력시키기
    public void ShowSendError(string error)
    {
        sendErrorText.text = error;
        sendErrorPanel.SetActive(true);
    }

    public void OnClickExitSendError()
    {
        sendErrorPanel.SetActive(false);
    }

    #endregion

}

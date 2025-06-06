using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PopupLogin : MonoBehaviour
{
    [Header("UI 키고 끄기")]
    public GameObject loginPanel;
    public GameObject mainPanel;
    public GameObject signUpPanel;
    
    public GameObject idErrorPanel;
    public GameObject psErrorPanel;
    
    
    [Header("내부 내용 변경 & 확인")]
    public TMP_InputField idText;
    public TMP_InputField nameText;
    public TMP_InputField psText;
    public TMP_InputField psConfirmText;
    public TMP_Text errorText;

    [Header("로그인 입력")] 
    public TMP_InputField loginIdInput;
    public TMP_InputField loginPsInput;
    
    //로그인버튼을 누르면 UI 일단 변경
    public void OnclickLogin()
    {
        string id = loginIdInput.text.Trim();
        string ps = loginPsInput.text.Trim();

        //ID비워져있으면,
        if (string.IsNullOrEmpty(id))
        {
            Debug.Log("여기가 문제니?");
            idErrorPanel.SetActive(true);
            return;
        }
        
        //비밀번호 비워져있으면
        if (string.IsNullOrEmpty(ps))
        {
            psErrorPanel.SetActive(true);
            return;
        }

        //만약 ID/Ps키가 있는지 확인
        if (PlayerPrefs.HasKey($"{id}/PassWord"))
        {
            //있으면 가져와
            string saveps = PlayerPrefs.GetString($"{id}/PassWord");
            
            //비교해 내가 친 비밀번호가 맞는지
            if (ps == saveps)
            {
                Debug.Log($"로그인 성공 ID : {id}");
                
                //여기에서 현재 로그인한 ID의 데이터 불러오기
                GameManager.Instance.LoadUserDataForId(id);
                
                loginPanel.SetActive(false);
                mainPanel.SetActive(true);
            }
            else
            {
                psErrorPanel.SetActive(true);
            }
        }
        else
        {
            Debug.Log("여기가 문제니2");
            idErrorPanel.SetActive(true);
        }
        
    }

    //회원가입창으로 이동
    public void OnclickSignUpPopup()
    {
        signUpPanel.SetActive(true);
    }

    //회원가입창에서 로그인창으로 이동
    public void OnClickExitSignUp()
    {
        signUpPanel.SetActive(false);
    }

    //회원가입 버튼을 눌렀을때 반응
    public void OnclickSignUp()
    {
        string id = idText.text.Trim();
        string name = nameText.text.Trim();
        string ps =  psText.text.Trim();
        string psConfirm = psConfirmText.text.Trim();

        Debug.Log("아직 멀었다.");
        
        //칸 하나씩의 상태를 확인해주고 싶어서
        if (string.IsNullOrEmpty(id))
        {
            Debug.Log("들오긴했니?");
            ShowError("ID를 입력해주세요");
            return;
        }
        
        if (string.IsNullOrEmpty(name))
        {
            ShowError("이름을 입력해주세요");
            return;
        }
        
        if (string.IsNullOrEmpty(ps)||string.IsNullOrEmpty(psConfirm))
        {
            ShowError("비밀번호를 입력해주세요");
            return;            
        }
        
        
        //비밀번호가 다르면 
        if (ps != psConfirm)
        {
            ShowError("비밀번호가 서로 다릅니다.");
        }
        else
        {
            //같으면 신호만 주기 // 저장은 밑에서
            ShowError("회원가입이 완료 되었습니다.");
        }
        
        //저장하기
        PlayerPrefs.SetString($"{id}/Name", name);
        PlayerPrefs.SetString($"{id}/PassWord", ps);
        // PlayerPrefs.SetString($"{id}/Money", "90000");
        // PlayerPrefs.SetString($"{id}/Balance", "90000");
        PlayerPrefs.Save();
        
        Debug.Log($"저장완료 id : {id}, name : {name}");
    }

    public void ShowError(string error)
    {
        errorText.text = error;
    }
    
    //아이디 에러 UI
    public void OnClickExitErrorID()
    {
        idErrorPanel.SetActive(false);
    }
    //비밀번호 에러 UI
    public void OnClickExitErrorPs()
    {
        psErrorPanel.SetActive(false);
    }
    
}

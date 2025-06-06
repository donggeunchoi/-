using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData userData;

    //UI 오브젝트 들고 오려구
    public GameObject nameObject;
    public GameObject moneyObject;
    public GameObject balanceObject;

    //텍스트 컴포넌트 저장하기위해서
    private TextMeshProUGUI _nameText;
    private TextMeshProUGUI _moneyText;
    private TextMeshProUGUI _balanceText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        userData = new UserData("최동근", 90000, 90000);
    }

    void Start()
    {
        //게임오브젝트에서 태스트 컴포넌트 가져올려고
        _nameText = nameObject.GetComponent<TextMeshProUGUI>();
        _moneyText = moneyObject.GetComponent<TextMeshProUGUI>();
        _balanceText = balanceObject.GetComponent<TextMeshProUGUI>();

        LoadUserData();

        Refresh();

        if (!PlayerPrefs.HasKey("test/Balance"))
        {
            PlayerPrefs.SetString("test/Name","test");
            PlayerPrefs.SetString("test/PassWord","aaaa");
            PlayerPrefs.SetString("test/Balance","5000");
            PlayerPrefs.Save();
            
            Debug.Log("테스트용 유저 생성 완료");
        }
    }

    public void Refresh()
    {
        if (_nameText != null)
        {
            _nameText.text = userData.Name;
            Debug.Log(userData.Name);
        }

        if (_moneyText != null)
        {
            _moneyText.text = userData.Money.ToString("N0");
        }

        if (_balanceText != null)
        {
            _balanceText.text = userData.Balance.ToString("N0");
        }


    }

    public void SaveUserData()
    {
        PlayerPrefs.SetString("SaveName", userData.Name);
        PlayerPrefs.SetString("SaveMoney", userData.Money.ToString());
        PlayerPrefs.SetString("SaveBalance", userData.Balance.ToString());

        Debug.Log($"저장 완료 이름{userData.Name},Money : {userData.Money}, Balance : {userData.Balance}");

    }

    public void LoadUserData()
    {
        if (PlayerPrefs.HasKey("SaveMoney") && PlayerPrefs.HasKey("SaveBalance"))
        {
            userData.Name = PlayerPrefs.GetString("SaveName", "최동근");
            
            //이렇게 작성하니 ","에 대한 내용도 같이 불러와져 오류가 생기드라 그라믄 분리해서 불러오게 해야겠지?
            // userData.Money = ulong.Parse(PlayerPrefs.GetString("SaveMoney", "90000"));
            // userData.Balance = ulong.Parse(PlayerPrefs.GetString("SaveMoney", "90000"));

            //불러오는건 고대로 문자로 불러오는데
            string saveMoney = PlayerPrefs.GetString("SaveMoney", "90000");
            string saveBalance = PlayerPrefs.GetString("SaveBalance", "90000");

            //여기에서 숫자로 넘겨와야하니까 "," 없애버리기
            userData.Money = ulong.Parse(saveMoney.Replace(",", ""));
            userData.Balance = ulong.Parse(saveBalance.Replace(",", ""));

            Debug.Log($"로드 완료 이름:{userData.Name},Money : {userData.Money}, Balance : {userData.Balance}");
        }
    }

    public void LoadUserDataForId(string id)
    {
        userData.Name = PlayerPrefs.GetString($"{id}/Name", "Unknown");
        userData.Money = ulong.Parse(PlayerPrefs.GetString($"{id}/Money", "90000"));
        userData.Balance = ulong.Parse(PlayerPrefs.GetString($"{id}/Balance", "90000"));

        Debug.Log($"[ID:{id}] 데이터 로드 완료 → Name:{userData.Name}, Money:{userData.Money}, Balance:{userData.Balance}");

        Refresh();
    }
}
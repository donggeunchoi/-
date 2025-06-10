# 💻 Unity 과제 모음

두 가지 Unity 과제를 수행하며 **C# 프로그래밍**, **UGUI 시스템**, **OOP 설계** 등에 대해 학습하였습니다.


각 ATM Scene 과 Inventory Scene으로 구분하여 제작하였습니다.

---

## 🏧 과제 1: ATM 만들기

### 🔹 주요 기능
#### 필수 기능
- ATM화면 구성
- 유저 데이터 제작
- 게임 메니저 제작
- 데이터와 UI연동
- 입금 UI제작
- 출금 UI제작
- 입출금 창 이동
- 입금 기능 만들기
- 출금 기능 만들기
- 저장 및 로그 기능

#### 도전기능
- 로그인창 만들기
- 회원가입 만들기
- 로그인 하기
- 송금 하기
  

### 🔹 구현 포인트
- UserData클래스 작성하여 해당 유저 이름과 현금, 통장 잔액 생성
- 게임 매니저 싱글톤을 생성하여 어디서든 사용할 수 있게 구현
- PlayerPrefs를 활용하여 저장 및 로드 구현

- 관련 트러블 슈팅(https://blog.naver.com/PostView.naver?blogId=gxxnn__&logNo=223889902245&categoryNo=39&parentCategoryNo=0&viewDate=&currentPage=1&postListTopCurrentPage=1&from=postView&userTopListOpen=true&userTopListCount=5&userTopListManageOpen=false&userTopListCurrentPage=1)

---

## 🎮 과제 2: 인벤토리 만들기

### 🔹 주요 기능
- 스크롤 가능한 인벤토리 UI
- 아이템 장착 / 해제 기능
- 장착 여부에 따른 캐릭터 스탯 변화
- 장착 시 마커 UI 활성화
- 동적 슬롯 생성 및 이미지 반영

### 🔹 기술 스택
- Unity UGUI (ScrollView, Button, Image 등)
- 프리팹을 활용한 슬롯 동적 생성
- 캐릭터 클래스와 아이템 클래스 분리
- 상태 반영을 위한 UIManager, InventoryManager 활용


### 🔹 추가 학습
- `List<T>`, `Instantiate`, `SerializeField` 사용법
- `싱글톤 패턴`과 `디버깅 로그(Debug.Log)` 활용
- 장착 아이템 1개 제한 로직 구현
- 트러블슈팅: 장착 마커 UI 갱신 문제 해결


- 관련 트러블 슈팅 : (https://blog.naver.com/PostView.naver?blogId=gxxnn__&logNo=223893682456&categoryNo=39&parentCategoryNo=0&viewDate=&currentPage=1&postListTopCurrentPage=1&from=postView&userTopListOpen=true&userTopListCount=5&userTopListManageOpen=false&userTopListCurrentPage=1)

---

## ✨ 느낀 점
- 콘솔과 GUI를 활용한 과제를 병행하며 **로직과 인터페이스의 연결**을 이해하게 되었습니다.
- 특히 인벤토리 과제를 통해 **동적 UI 생성, 오브젝트 간 통신 구조**, **클래스 분리의 중요성**을 체감했습니다.

---

## 🧠 참고
- UI 작업 시 Image 컴포넌트의 Sprite 연동
- Scroll View에서 Content 설정 주의
- Equip 마커 동기화 문제는 `RefreshAllSlots()`로 해결


프로젝트 소개
- 적을 피하면서 동전을 모으는 간단한 규칙의 캐주얼 게임입니다.

# 프로젝트 구조 및 핵심 설계 요약

---

## 스크립트 구조

```
├── Chapter                    # 챕터별 고유 이벤트 관리
│   └── InGameManager
│
├── Enemy                      # 적 행동 스크립트
│   └── Enemy
│
├── Item                      # 아이템 관련
│   ├── Coin
│   ├── Spawner
│   └── Teleport
│
├── Managers                    # 툴 및 시스템 관리 매니저
│   ├── Core
│   │   ├── InputManager
│   │   ├── Poolable
│   │   ├── PoolManager
│   │   ├── ResourceManager
│   │   ├── SceneManagerEx
│   │   └── SoundManager
│   └── ManagerObject
│
├── Player                     # 플레이어 관련 스크립트
│   ├── Player
│   └── CameraMove
│
└── UI                         # UI 캔버스 및 컨트롤러
    ├── InGameUI
    └── TitleUI
```

---

## 사용 기술 및 설계 원칙

### **UI 버튼 이벤트 처리 자동화**
- childsmapping 함수로 **enum ↔ Button** 매핑
- eventmapping 함수로 **button 별 이벤트** 매핑
- GameObject 이름 참조 X → **enum 기반 참조로 안정성 강화**
- 오타나 참조 오류 발생률 감소

---

### **event / Action 기반 클래스 역할 분리**
- **직접 참조 없이** Action으로 통신
- 높은 응집도, 낮은 결합도 유지
- **스파게티 코드 방지**

---

### **Manager Object 기반 싱글톤 매니저 활용**
- 공통 매니저들(`SoundManager`, `SceneManager` 등)을 **ManagerObject** 기준으로 통합 관리
- 직접 변수 참조가 아닌, **이벤트 및 Action** 기반으로 연결
- 유지보수성과 구조적 확장성 확보

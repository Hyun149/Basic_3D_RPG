# 🎮 Slimeventure: A TPS Slime RPG

Unity 2022.3 LTS 기반으로 제작된 밝고 귀여운 슬라임 RPG,  
`Input System`, `TPS 카메라`, `점프`, `지면 체크` 등 기본 기능이 포함된  
슬라임의 모험을 위한 컨트롤러 데모입니다.
---

## 🚀 주요 기능 (Features)

- 🎯 **TPS 기반 플레이어 이동 및 점프 시스템**
  - `Input System`을 활용한 WASD 이동 및 Space 점프
  - Rigidbody 기반 점프 물리 처리
  - GroundCheck 시스템을 통한 지면 판별

- 🖱️ **마우스 기반 Look 시스템**
  - 마우스를 통한 시야 회전 구현
  - 마우스 입력 민감도 조절 가능 (향후 옵션 추가 가능)

- 🧱 **씬 및 환경 초기 구성**
  - 캐릭터와 지형, 트로피컬 환경 에셋 포함
  - 초기 위치 배치 및 이동 테스트 완료

- 💡 **Unity URP 적용**
  - 프로젝트 설정에 URP (Universal Render Pipeline) 구성 완료
  - 머티리얼 자동 변환 도구 사용

---

## 🏗️ 프로젝트 구조
![image](https://github.com/user-attachments/assets/39bd7a16-04b1-425d-93b6-ce55918599f6)

---

## ⚙️ 설치 및 실행 방법

1. Unity Hub에서 `Unity 2022.3.17f1 LTS` 버전 설치
2. 이 프로젝트를 열고, `MainScene` 씬을 실행
3. WASD로 이동, 마우스로 시야 회전, Space 키로 점프 테스트

---

## 📸 스크린샷 (예정)

> 추후 기획된 캐릭터 모델 또는 환경이 적용된 후 스크린샷 추가 예정

---

## 🔧 추후 개발 예정 사항

- ✅ **점프 이펙트 및 사운드 추가**
- ✅ **카메라 충돌 및 회전 제한 시스템**
- ⏳ **에임 시스템 및 TPS 타겟팅**
- ⏳ **멀티 플랫폼 입력 대응 (모바일, 게임패드 등)**

---

## 🤝 기여

기여를 원하시면 PR 전에 이슈를 등록해주세요.  
코드 스타일 및 커밋 메시지는 아래 규칙을 따릅니다:

- 커밋 메시지: `feat:`, `fix:`, `refactor:` 등의 prefix 사용
- PR 단위는 기능별로 구분

---

## 🧠 커밋 이력 요약

| 날짜 | 주요 커밋 메시지 |
|------|------------------|
| 2025-05-24 | `feat: 점프 기능 개선 및 GroundCheck 시스템 도입` |
| 2025-05-23 | `feat: 슬라임 이동 및 점프 시스템 구현 (Input System 연동)` |
| 2025-05-23 | `feat: 프로젝트 초기 세팅 및 URP 환경 구성 완료` |

---

### 🔧 Troubleshooting

| 문제 상황 | 원인 | 해결 방법 |
|-----------|------|-----------|
| 캐릭터가 점프하지 않음 | GroundCheck가 지면을 인식하지 못함 | `groundLayer`에 올바른 Layer가 설정되어 있는지, `groundCheck` 위치가 지면 근처에 있는지 확인 |
| 이동이 먹히지 않음 | Input System 연동 실패 | PlayerInput 컴포넌트가 존재하는지, Action Asset이 연결되어 있는지 확인 |
| 마우스 Look이 작동하지 않음 | PlayerLook 스크립트 비활성화 또는 민감도 문제 | Look 처리 컴포넌트가 활성화되어 있고, `OnLook()`이 Input System에 바인딩되어 있는지 확인 |
| URP 머티리얼이 깨짐 | 기존 머티리얼이 URP용으로 변환되지 않음 | Edit > Render Pipeline > URP > Upgrade Project Materials 메뉴 사용 |
| 씬 실행 시 캐릭터가 안 보임 | 카메라 초기 위치 오류 또는 오브젝트 비활성화 | 카메라가 캐릭터를 비추는 위치에 있는지, 캐릭터 오브젝트가 `Active` 상태인지 확인 |



## SlimeKing

**프로젝트 개요**

플레이어는 슬라임 캐릭터를 컨트롤하여 좌우로 이동하고 점프할 수 있습니다. 

점프키를 오래 누를수록 점프를 높게 뛸 수 있으며, 방향키로 좌우 방향 조정이 가능합니다.

게임의 핵심 목표는 레벨의 끝에 있는 목표지점. 슬라임 퀸을 만나는 것입니다.

슬라임 캐릭터, 블록 일부분은 직접 디자인해서 제작하였으며, 배경 등은 에셋을 활용했습니다.

게임은 안드로이드 플랫폼에서 플레이할 수 있도록 제작되었습니다.

--------------------------------------------------------

**사용한 기술 정보**

C++, Unity

--------------------------------------------------------

**구동 스크린샷**

![image](https://github.com/GH1014/SlimeKing/assets/95550744/1c26fe52-3807-45bf-a1f0-cf398cab8dcb)

![image](https://github.com/GH1014/SlimeKing/assets/95550744/cac27f04-e4cf-418d-a0f2-dcb271afaec6)

![image](https://github.com/GH1014/SlimeKing/assets/95550744/e436f978-7842-4c75-b47d-7ea974b122b7)

![image](https://github.com/GH1014/SlimeKing/assets/95550744/2e48f703-7739-481c-b108-0403e5f82a5f)

![image](https://github.com/GH1014/SlimeKing/assets/95550744/968f6b51-6539-48ee-b861-4df5c63c1d8d)

![image](https://github.com/GH1014/SlimeKing/assets/95550744/f5f2190f-f7f4-4659-afdd-f73341d1fa61)

![image](https://github.com/GH1014/SlimeKing/assets/95550744/cac27f04-e4cf-418d-a0f2-dcb271afaec6)



--------------------------------------------------------

**주요 코드**

점프 시 효과음과 점프 키를 누른 시간에 비례하여 점프 높이가 상승하고,

보고 있는 방향으로 점프하는 함수입니다.

```c++
AudioChange(AudioJump, AudioSource);

rigid.AddForce(Vector2.up * jumpPower * Mathf.Clamp(time, 1, 2.5f), ForceMode2D.Impulse);

if (inputLeft)
{
    rigid.AddForce(Vector2.left * jumpPower/2 * Mathf.Clamp(time, 1, 2.5f), ForceMode2D.Impulse);

}
else if(inputRight)
{
    rigid.AddForce(Vector2.right * jumpPower/2 * Mathf.Clamp(time, 1, 2.5f), ForceMode2D.Impulse);
}
```

--------------------------------------------------------



 

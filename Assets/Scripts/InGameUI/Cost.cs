using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [Header("Cost System")]
    public Slider slider;
    public float fillDuration = 3f; // add 1 per 3 second
    private int maxValue = 10;
    [SerializeField] private TextMeshProUGUI sliderValueText; // 슬라이더 값을 표시할 텍스트
    public TextMeshProUGUI timerText;
    public int startMinutes = 10; // start minute
    public float timeRemaining; // remain second
    private bool isRunning = false;
    
    [Header("Button System")]
    [SerializeField] private BaseStatusData baseStatusDataA;
    [SerializeField] private BaseStatusData baseStatusDataB;
    [SerializeField] private BaseStatusData baseStatusDataC;

    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
// ---------------------------------------------------------
    void Start()
    {
        StartCoroutine(FillSlider());

        timeRemaining = startMinutes * 60; // 10분을 초로 변환
        StartCoroutine(TimerCountdown());
        
        // 초기 슬라이더 값 표시
        UpdateSliderValueText();
        
    }
// ---------------------------------------------------------
    // 슬라이더 값을 텍스트로 표시하는 메서드
    private void UpdateSliderValueText()
    {
        if (sliderValueText != null)
        {
            sliderValueText.text = Mathf.FloorToInt(slider.value).ToString();
        }
    }
// ---------------------------------------------------------
    IEnumerator FillSlider()
    {
        while (true)
        {
            float startValue = slider.value;
            float endValue = Mathf.Min(startValue + 1, maxValue); // 최대값 초과 방지
            float elapsedTime = 0f;

            while (elapsedTime < fillDuration)
            {
                slider.value = Mathf.Lerp(startValue, endValue, elapsedTime / fillDuration);
                UpdateSliderValueText(); // 슬라이더 값 업데이트
                elapsedTime += Time.deltaTime;
// ---------------------------------------------------------
                // 버튼 A 클릭 체크
                if (buttonA != null && baseStatusDataA != null)
                {
                    buttonA.onClick.RemoveAllListeners(); // 기존 리스너 제거
                    buttonA.onClick.AddListener(() =>
                    {
                        // 비용 체크를 여기서 수행
                        if (slider.value >= baseStatusDataA.cost)
                        {
                            slider.value -= baseStatusDataA.cost;
                            Debug.Log($"A 버튼 클릭 감지: 슬라이더 값 {baseStatusDataA.cost} 감소");

                            // 감소 후 다시 증가하도록 변수 재설정
                            startValue = slider.value;
                            endValue = Mathf.Min(startValue + 1, maxValue);
                            elapsedTime = 0f;

                            UpdateSliderValueText(); // 슬라이더 값 감소 후 업데이트
                        }
                        else
                        {
                            Debug.Log("비용이 부족합니다.");
                            // 선택적: 비용 부족 시 사용자에게 알림
                        }
                    });
                }

                if (buttonB != null && baseStatusDataB != null)
                {
                    buttonB.onClick.RemoveAllListeners(); // 기존 리스너 제거
                    buttonB.onClick.AddListener(() =>
                    {
                        // 비용 체크를 여기서 수행
                        if (slider.value >= baseStatusDataB.cost)
                        {
                            slider.value -= baseStatusDataB.cost;
                            Debug.Log($"B 버튼 클릭 감지: 슬라이더 값 {baseStatusDataB.cost} 감소");

                            // 감소 후 다시 증가하도록 변수 재설정
                            startValue = slider.value;
                            endValue = Mathf.Min(startValue + 1, maxValue);
                            elapsedTime = 0f;

                            UpdateSliderValueText(); // 슬라이더 값 감소 후 업데이트
                        }
                        else
                        {
                            Debug.Log("비용이 부족합니다.");
                            // 선택적: 비용 부족 시 사용자에게 알림
                        }
                    });
                }

                if (buttonC != null && baseStatusDataC != null)
                {
                    buttonC.onClick.RemoveAllListeners(); // 기존 리스너 제거
                    buttonC.onClick.AddListener(() =>
                    {
                        // 비용 체크를 여기서 수행
                        if (slider.value >= baseStatusDataC.cost)
                        {
                            slider.value -= baseStatusDataC.cost;
                            Debug.Log($"C 버튼 클릭 감지: 슬라이더 값 {baseStatusDataC.cost} 감소");

                            // 감소 후 다시 증가하도록 변수 재설정
                            startValue = slider.value;
                            endValue = Mathf.Min(startValue + 1, maxValue);
                            elapsedTime = 0f;

                            UpdateSliderValueText(); // 슬라이더 값 감소 후 업데이트
                        }
                        else
                        {
                            Debug.Log("비용이 부족합니다.");
                        }
                    });
                }
// ------------------------------------------------------------
                if (timeRemaining == 590)
                {
                    fillDuration = 1.5f;
                }

                yield return null;
            }

            slider.value = endValue; // 보정
            UpdateSliderValueText(); // 최종 값 업데이트

            yield return new WaitForSeconds(0.1f); // delay
        }
    }
// ---------------------------------------------------------
    IEnumerator TimerCountdown() // timer coroutine
    {
        isRunning = true;

        while (timeRemaining > 0)
        {
            UpdateTimerText();
            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }

        timeRemaining = 0;
        UpdateTimerText(); // 00:00 표시
        isRunning = false;
    }
// ---------------------------------------------------------
    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
// ---------------------------------------------------------
     // 버튼 클릭 시 실행될 메서드
    void UseSkill(BaseStatusData baseStatusData)
    {
        if (baseStatusData != null && slider.value >= baseStatusData.cost)
        {
            slider.value -= baseStatusData.cost;
            Debug.Log($"버튼 클릭 감지: 슬라이더 값 {baseStatusData.cost} 감소");

            UpdateSliderValueText(); // 슬라이더 값 감소 후 업데이트
        }
    }
// ---------------------------------------------------------
}

using UnityEngine;
using UnityEngine.UI;

public class PanaelManager : MonoBehaviour
{
    private Button button;
    private RectTransform rectTransform;

    [Header("Animations")]
    public float animationDuration = 0.5f;
    public float startYOffset = -300f;
    private Vector2 originalPosition;

    private float animationTimer = 0f;
    private bool isAnimating = false;

    private float activationTimer = 0f;
    private bool isWaitingForEnable = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        button = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();

        originalPosition = rectTransform.anchoredPosition;
    }

        // Update is called once per frame
    void Update()
    {
        if(isAnimating)
        {
            animationTimer += Time.unscaledDeltaTime;

            float ratio = animationTimer / animationDuration;
            Vector2 startPos = originalPosition + new Vector2(0, startYOffset);
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, originalPosition, ratio);

            if (ratio >= 1.0f)
            {
                rectTransform.anchoredPosition = originalPosition;
                isAnimating = false;
            }
        }

        if(isWaitingForEnable)
        {
            activationTimer += Time.unscaledDeltaTime;

            if(activationTimer >= 1.0f)
            {
                button.interactable = true;
                isWaitingForEnable = false;
            }
        }
    }


    void OnEnable()
    {
        if (button == null || rectTransform == null) return;

        button.interactable = false;

        rectTransform.anchoredPosition = originalPosition + new Vector2(0, startYOffset);

        animationTimer = 0f;
        isAnimating = true;

        activationTimer = 0f;
        isWaitingForEnable = true;

    }
}

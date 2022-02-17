using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayAnimationButton : MonoBehaviour
{
    private Animator animator;
    private string animationName;
    private TextMeshProUGUI nameText;
    private Button button;

    private void Awake()
    {
        nameText = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnClick);
    }

    public void Setup(Animator animator, string animationName)
    {
        this.animator = animator;
        this.animationName = animationName;

        nameText.text = animationName;
    }

    private void OnClick()
    {
        animator.Play(animationName);
    }
}
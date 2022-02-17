using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterAnimationSelector : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string[] animationsName;
    
    private UIPlayAnimationButton[] buttons;

    private void Awake()
    {
        buttons = GetComponentsInChildren<UIPlayAnimationButton>();

        if (buttons.Length != animationsName.Length)
            throw new System.Exception("La cantidad de botones no es igual a la de animaciones. Animaciones: " + animationsName.Length + ", botones: " + buttons.Length);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].Setup(animator, animationsName[i]);
        }
    }

}

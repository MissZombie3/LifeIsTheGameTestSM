using UnityEngine;

public class CharacterLastAnimationPlayer : MonoBehaviour
{
    private void Awake()
    {
        string lastAnimationName = PlayerPrefs.GetString("ANIMATION");

        if (!string.IsNullOrEmpty(lastAnimationName))
            GetComponent<Animator>().Play(lastAnimationName);
    }
}

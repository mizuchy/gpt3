using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bot : MonoBehaviour
{
    [SerializeField] Sprite _positive;
    [SerializeField] Sprite _neutral;
    [SerializeField] Sprite _negative;

    [SerializeField] Image imageToDispaly;
    private void Awake()
    {
        if (!_positive || !_negative || !_neutral)
        {
            Debug.LogError("Missing one sprite");
            return;
        }

        imageToDispaly.sprite = _neutral;

    }

    public void ChangeEmotion(int state)
    {
        if (state == 1)
        {
            imageToDispaly.sprite = _positive;
        } else if (state == -1)
        {
            imageToDispaly.sprite = _negative;
        } else
        {
            imageToDispaly.sprite = _neutral;
        }
    }
}

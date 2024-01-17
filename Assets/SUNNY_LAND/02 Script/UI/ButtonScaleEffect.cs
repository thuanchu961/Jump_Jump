
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ButtonScaleEffect : MonoBehaviour
{
    public Button yourButton;
    public float scaleDuration = 0.5f;
    public Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f);

    private void Awake()
    {
        yourButton = GetComponent<Button>();
    }
    void Start()
    {
        if (yourButton == null)
        {
            Debug.LogError("Please set the Button in the Inspector!");
            return;
        }

        // Th�m v?ng l?p v� h?n cho Button
        yourButton.transform.DOScale(targetScale, scaleDuration)
            .SetEase(Ease.OutBack)
            .SetLoops(-1, LoopType.Yoyo); // V?ng l?p v� h?n v?i ki?u loop Yoyo (Scale to v� sau �� Scale back)
    }
}

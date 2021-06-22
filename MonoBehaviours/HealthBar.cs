using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HitPoints hitPoints;
    float maxHitPoints;

    [HideInInspector]
    public Player character;

    public Image meterImage;
    public Text hpText;

    

    // Start is called before the first frame update
    void Start()
    {
        //TODO : 캐릭터랑 연동하기
        maxHitPoints = character.maxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        meterImage.fillAmount = hitPoints.value / maxHitPoints;
        hpText.text = $"HP:{meterImage.fillAmount * 100}";
    }
}

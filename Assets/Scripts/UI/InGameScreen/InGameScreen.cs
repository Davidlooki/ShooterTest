using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameScreen : Singleton<InGameScreen>
{
    [SerializeField]
    private TMP_Text txtWeakKilledAmount;

    [SerializeField]
    private TMP_Text txtStrongKilledAmount;

    [SerializeField]
    private RectTransform lifeBar;


    private float originalLifeBarWidth;
    // Start is called before the first frame update
    void Start()
    {
        originalLifeBarWidth = lifeBar.sizeDelta.x;
        
        SetPlayerLifeBar(1200);
    }

    public void SetPlayerLifeBar(int _life)
    {
        Vector2 _widthLifeBar = new Vector2(0, lifeBar.sizeDelta.y);
        
        _widthLifeBar.x = (_life * originalLifeBarWidth) / 2700;

        lifeBar.sizeDelta = _widthLifeBar;
    }

    public void SetWeakEnemyKills()
    {

    }

    public void SetStrongEnemyKills()
    {

    }
}
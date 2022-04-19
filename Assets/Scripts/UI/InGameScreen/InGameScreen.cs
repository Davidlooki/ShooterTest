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

    private Image lifeBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayerLifeBar(int _lifeAmount)
    {
        
    }
}
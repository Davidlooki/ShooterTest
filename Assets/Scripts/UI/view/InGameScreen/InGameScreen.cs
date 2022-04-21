using System.Collections;
using UnityEngine;

using TMPro;

using Internal.Singleton;

namespace UI.InGameScreen
{
    public class InGameScreen : Singleton<InGameScreen>
    {
        [SerializeField]
        private TMP_Text txtWeakKilledAmount;

        [SerializeField]
        private TMP_Text txtStrongKilledAmount;

        [SerializeField]
        private RectTransform lifeBar;

        [SerializeField]
        private TMP_Text txtKillAlert;

        [SerializeField]
        private TMP_Text txtWeaponName;
        
        float originalLifeBarWidth;

        // Start is called before the first frame update
        void Start()
        {
            originalLifeBarWidth = lifeBar.sizeDelta.x;

            txtKillAlert.gameObject.SetActive(false);
        }

        public void SetPlayerLifeBar(int _life)
        {
            Vector2 _widthLifeBar = new Vector2(0, lifeBar.sizeDelta.y);

            _widthLifeBar.x = (_life * originalLifeBarWidth) / 2700;

            lifeBar.sizeDelta = _widthLifeBar;
            Debug.Log("Set Life");
        }

        public void SetWeaponName(string _name)
        {
            if (txtWeaponName)
                txtWeaponName.text = _name;
        }

        public void SetWeakEnemyKills(int _killed)
        {
            if (txtWeakKilledAmount)
                txtWeakKilledAmount.text = _killed.ToString("000");

            KillAlert();
        }

        public void SetStrongEnemyKills(int _killed)
        {
            if (txtStrongKilledAmount)
                txtStrongKilledAmount.text = _killed.ToString("000");

            KillAlert();
        }

        public void KillAlert()
        {
            StartCoroutine(CoroutineKillAlert(1f));
        }

        private IEnumerator CoroutineKillAlert(float _activeTime)
        {
            if (txtKillAlert)
            {
                txtKillAlert.gameObject.SetActive(true);

                yield return new WaitForSeconds(_activeTime);

                txtKillAlert.gameObject.SetActive(false);
            }
            StopCoroutine("CoroutineKillAlert");
        }
    }
}
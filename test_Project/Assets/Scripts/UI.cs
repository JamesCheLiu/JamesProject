using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public TMP_Text Healthtext;
    public TMP_Text BossHealthText;
    public GameObject player;
    private Playermanager playermanager;
    public GameObject boss;
    private Health bosshealth;

    // Start is called before the first frame update
    void Start()
    {
        playermanager = player.GetComponent<Playermanager>();
        bosshealth = boss.GetComponent<Health>();
        Healthtext.text += playermanager.health;
        BossHealthText.text += bosshealth.healthfull;
    }

    // Update is called once per frame
    void Update()
    {
        Healthtext.text = "               HEALTH:" + playermanager.currenthealth;
        BossHealthText.text = "        BOSS:" + bosshealth.healthfull;
    }
}

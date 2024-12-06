using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Blackhole_HotKet_Controller : MonoBehaviour
{
    private SpriteRenderer sr;
    private KeyCode myHotKey;
    private TextMeshProUGUI myText;

    private Transform myEnemy;
    private Blackhole_Skill_Controller blackHole;

    public void SetupHotKey(KeyCode _mynewHotKey,Transform _myEnemy,Blackhole_Skill_Controller _myBlackHole)
    {
        sr =GetComponent<SpriteRenderer>();
        myText = GetComponentInChildren<TextMeshProUGUI>();

        myEnemy = _myEnemy;
        blackHole = _myBlackHole;

        myHotKey = _mynewHotKey;
        myText.text = _mynewHotKey.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(myHotKey))
        {
            blackHole.AddEnemyToList(myEnemy);

            myText.color = Color.clear;
            sr.color = Color.clear;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class AchimentPanelContorller : MonoBehaviour
{
    public TextMeshProUGUI AchimentTitle;

    // Start is called before the first frame update

    void OnEnable()
    {
        Event.Achim_Toilet += ShowToiletAchiment;
        Event.Achim_Bed += ShowBedAchiment;
        Event.Achim_Apple += ShowAppleAchiment;
        Event.Achim_Truck += ShowTrucktAchiment;
        Event.Achim_ToothBrush += ShowToothBrushAchiment;
        Event.Achim_Football += ShowFootballAchiment;
        Event.Achim_MagicHat += ShowMagicHatAchiment;
        Event.Achim_Time += ShowTimeAchiment;
        Event.Achim_ToiletPluger += ShowToiletPlugerAchiment;
        Event.Achim_TheGray += ShowTheGrayAchiment;
        Event.Achim_Phonograph += ShowPhonographAchiment;
        Event.Achim_Slipper += ShowSlipperAchiment;
        Event.Achim_Shower += ShowShowerAchiment;
        Event.Achim_Mushroom += ShowMushroomAchiment;
    }

    void ShowMushroomAchiment()
    {
        AchimentTitle.text = "I don't think you should took that";
        StartCoroutine(PopThePanel());
    }
    void ShowShowerAchiment()
    {
        AchimentTitle.text = "Publicarea still,";
        StartCoroutine(PopThePanel());
    }
    void ShowTheGrayAchiment()
    {
        AchimentTitle.text = "The everything started";
        StartCoroutine(PopThePanel());
    }

    void ShowPhonographAchiment()
    {
        AchimentTitle.text = "Loyal listeners";
        StartCoroutine(PopThePanel());
    }

    void ShowSlipperAchiment()
    {
        AchimentTitle.text = "Take it away!!!";
        StartCoroutine(PopThePanel());
    }

    void ShowToiletPlugerAchiment()
    {
        AchimentTitle.text = "Plunging into the Unknown";
        StartCoroutine(PopThePanel());
    }

    void ShowTimeAchiment()
    {
        AchimentTitle.text = "Time is an Illusion";
        StartCoroutine(PopThePanel());
    }
    void ShowMagicHatAchiment()
    {
        AchimentTitle.text = "Abracadabra!";
        StartCoroutine(PopThePanel());
    }
    void ShowFootballAchiment()
    {
        AchimentTitle.text = "Goal!";
        StartCoroutine(PopThePanel());
    }

    void ShowToothBrushAchiment()
    {
        AchimentTitle.text = "Very decent, huh?";
        StartCoroutine(PopThePanel());
    }
    void ShowTrucktAchiment()
    {
        AchimentTitle.text = "The Elephant in the Room";
        StartCoroutine(PopThePanel());
    }
        void ShowToiletAchiment()
    {
        AchimentTitle.text = "You won't use it here.... right?";
        StartCoroutine(PopThePanel());
    }
    void ShowAppleAchiment()
    {
        AchimentTitle.text = "An apple a day keeps the doctor away";
        StartCoroutine(PopThePanel());
    }
    void ShowBedAchiment()
    {
        AchimentTitle.text = "Night Night";
        StartCoroutine(PopThePanel());
    }


    void Start()
    {
    }

    IEnumerator PopThePanel()
    {
        float percent = 0;
        float amount = 120;

        while (percent < 1)
        {
            percent += Time.deltaTime / 1f;
            transform.position += Vector3.up * amount * Time.deltaTime/1f;
            
            yield return null;
        }

        yield return new WaitForSeconds(3);

        percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime / 1f;
            transform.position += Vector3.down * amount * Time.deltaTime/1f;
            
            yield return null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

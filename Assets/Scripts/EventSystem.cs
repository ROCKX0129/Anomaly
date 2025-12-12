using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class Event{

    
    private static int Bedcounter = 0;
    private static int Toiletcounter = 0;
    private static int Applecounter = 0;
    private static int Truckcounter = 0;
    private static int ToothBrushcounter = 0;
    private static int ToiletPlugercounter = 0;
    private static int Timecounter = 0;
    private static int Footballcounter = 0;
    private static int Magichatcounter = 0;
    private static int TheGraycounter = 0;
    private static int Phonographcounter = 0;
    private static int Slippercounter = 0;
    private static int Showercounter = 0;
    private static int Mushroomcounter = 0;


    public static event Action AnomolyFound;
    public static event Action Achim_Toilet;
    public static event Action Achim_Bed;
    public static event Action Achim_Apple;
    public static event Action Achim_Truck;
    public static event Action Achim_ToothBrush;
    public static event Action Achim_ToiletPluger;
    public static event Action Achim_Time;
    public static event Action Achim_Football;
    public static event Action Achim_MagicHat;
    public static event Action Achim_TheGray;
    public static event Action Achim_Phonograph;
    public static event Action Achim_Slipper;
    public static event Action Achim_Shower;
    public static event Action Achim_Mushroom;
    public static void TimeAnomolyFound(){
        AnomolyFound?.Invoke();
    }

    public static void AchimShowerTriger(){
        if (Showercounter < 1)
        {
            Achim_Shower?.Invoke();
            Showercounter++;
            return;
        }
    }
    public static void AchimMushroomTriger(){
        if (Mushroomcounter < 1)
        {
            Achim_Mushroom?.Invoke();
            Mushroomcounter++;
            return;
        }
    }

    public static void AchimToiletTriger(){
        if (Toiletcounter < 1)
        {
            Achim_Toilet?.Invoke();
            Toiletcounter++;
            return;
        }
    }

    public static void AchimBedTriger()
    {

        if (Bedcounter < 1)
        {
            Achim_Bed?.Invoke();
            Bedcounter++;
            return;
        }
    }

    public static void AchimAppleTriger()
    {

        if (Applecounter < 1)
        {
            Achim_Apple?.Invoke();
            Applecounter++;
            return;
        }
    }

    public static void AchimTruckTriger()
    {

        if (Truckcounter < 1)
        {
            Achim_Truck?.Invoke();
            Truckcounter++;
            return;
        }
    }

    public static void AchimToothBrushTriger()
    {
        if (ToothBrushcounter < 1)
        {
            Achim_ToothBrush?.Invoke();
            Truckcounter++;
            return;
        }
        
    }

    public static void AchimToiletPlugerTriger()
    {
        if (ToiletPlugercounter < 1)
        {
            Achim_ToiletPluger?.Invoke();
            ToiletPlugercounter++;
            return;
        }
    }

    public static void AchimTimeTriger()
    {
        if (Timecounter < 1)
        {
            Achim_Time?.Invoke();
            Timecounter++;
            return;
        }
    }
    public static void AchimFootballTriger()
    {
        if (Footballcounter < 1)
        {
            Achim_Football?.Invoke();
            Footballcounter++;
            return;
        }
    }

    public static void AchimMagicHatTriger()
    {
        if (Magichatcounter < 1)
        {
            Achim_MagicHat?.Invoke();
            Magichatcounter++;
            return;
        }
    }
    public static void AchimTheGrayTriger()
    {
        if (TheGraycounter < 1)
        {
            Achim_TheGray?.Invoke();
            TheGraycounter++;
            return;
        }
    }
    public static void AchimPhonographTriger()
    {
        if (Phonographcounter < 1)
        {
            Achim_Phonograph?.Invoke();
            Phonographcounter++;
            return;
        }
    }
    public static void AchimSlipperTriger()
    {
        if (Slippercounter < 1)
        {
            Achim_Slipper?.Invoke();
            Slippercounter++;
            return;
        }
    }
}
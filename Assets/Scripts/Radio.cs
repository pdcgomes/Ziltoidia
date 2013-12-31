using UnityEngine;
using System.Collections;

public enum RadioFrequency 
{
    RadioFrequencyOff = 0,
    RadioFrequencyHumanFaction,
    RadioFrequencyAlienFaction,
    RadioFrequencyBroadcast,
}

public enum RadioMessage
{
    RadioMessageUnderAttack,
    RadioMessageMayday,
    RadioMessageRequestAssistance,
    RadioMessageDismissPrevious,
    RadioMessageRoger,
}

public class Radio : MonoBehaviour
{
    public RadioFrequency frequency;

    void Start()
    {

    }

    public void TransmitMessage(string message)
    {

    }

    public void TransmitMessage(RadioMessage message)
    {

    }

    public void TransmitMessage(RadioMessage message, IDictionary info)
    {

    }
}


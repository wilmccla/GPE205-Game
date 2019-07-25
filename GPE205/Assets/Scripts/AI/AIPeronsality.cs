using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPeronsality : MonoBehaviour
{
    public AIPersonality Personality;
    public GameObject Ship;

    public enum AIPersonality
    {
        Adaptive, Agressive, Neutral, Passive
    }

    void Start()
    {
        Ship = this.gameObject;

        if (Personality == AIPersonality.Adaptive)
        {
            Ship.AddComponent<AdaptiveAIController>();
        }
    }
}

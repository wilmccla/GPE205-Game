using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPeronsality : MonoBehaviour
{
    public AIPersonality Personality;
    public GameObject Ship;
    public Renderer shipColor;

    public enum AIPersonality
    {
        Adaptive, Agressive, Passive, BountyHunter
    }

    void Start()
    {
        Ship = this.gameObject;

        if (Personality == AIPersonality.Adaptive)
        {
            Ship.AddComponent<AdaptiveAIController>();
        }

        if (Personality == AIPersonality.Agressive)
        {
            Ship.AddComponent<AgressiveAIController>();
        }

        if (Personality == AIPersonality.Passive)
        {
            Ship.AddComponent<PassiveAIController>();
        }

        if (Personality == AIPersonality.BountyHunter)
        {

        }
    }
}

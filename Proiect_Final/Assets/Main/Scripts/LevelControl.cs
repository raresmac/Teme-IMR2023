using UnityEngine;

public static class LevelControl
{
    public static int currentLevel = 0;
    public static float speed = 10.5f;
    public static bool debugDeath = false;
    public static int maxSections = 15;
    public static float speedMultiplier = 0.15f;
    public static float generateMultiplier = 21.0f;

    public static void Initialize(){
        speed = 10.5f;
        speedMultiplier = 0.15f;
        maxSections = 15;
    }

    public static void UpdateSpeed(){
        speed += Time.deltaTime * speedMultiplier;
    }
}

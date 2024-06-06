using UnityEngine;

public static class LevelControl
{
    public static int currentLevel = 0;
    public static float speed = 7.5f;
    public static bool debugDeath = true;
    public static int maxSections = 15;
    public static float speedMultiplier = 0.2f;
    public static float generateMultiplier = 21.0f;

    public static void Initialize(){
        speed = 7.5f;
        maxSections = 10;
    }

    public static void UpdateSpeed(){
        speed += Time.deltaTime * speedMultiplier;
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "ScoreScriptableObject", menuName = "ScriptableObjects/Score")]
public class ScoreScriptableObject : ScriptableObject
{
    public int tubs = 0;
    public int beds = 0;
    public int windows = 0;
    public int doors = 0;
    public int tvs = 0;
    public int lights = 0;
    public int cakes = 0;
}

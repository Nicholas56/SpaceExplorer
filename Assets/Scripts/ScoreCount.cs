using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public int score;

    public void AddScore() { score++; }
    public void SubScore() { score--; }
    public void ClearScore() { score = 0; }
}

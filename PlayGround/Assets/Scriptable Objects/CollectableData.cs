using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collectable", menuName = "Collectable")]
public class CollectableData : ScriptableObject
{
    public Mesh mesh;
    public Color color;
    public float scale;
    public float spin_speed;
    public int points;

    public void PrintPoints()
    {
        Debug.Log("You got " + points + " points!");
    }


}

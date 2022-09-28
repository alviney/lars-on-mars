using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, BoardItem
{
   public Vector3 Position
    {
        get => this.transform.position;
    }
}

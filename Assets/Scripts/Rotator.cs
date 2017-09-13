using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Rotator : MonoBehaviour
    {
        void Update()
        {
            transform.Rotate(new Vector3(15, 25, 35) * Time.deltaTime); // just rotatin, so it looks good
        }
    }
}
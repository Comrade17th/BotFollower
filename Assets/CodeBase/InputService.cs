using UnityEngine;

namespace CodeBase
{
    public class InputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        
        public Vector2 Axis => 
            new(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
    }
}
using UnityEngine;

namespace SDA.Generation
{
    public class Knife : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D rigidbody2D;

        public Rigidbody2D Rigidbody2D => rigidbody2D;

        [SerializeField]
        private float speed;

        public void ThrowKnife()
        {
            rigidbody2D.AddForce(Vector2.up * (speed * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }
    }
}

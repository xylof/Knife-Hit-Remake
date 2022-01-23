using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Generation
{
    public abstract class BaseShield : MonoBehaviour
    {
        [SerializeField]
        protected ShieldMovementStep[] movementScheme;

        private List<Knife> knivesInShield = new List<Knife>();

        public abstract void Initialize();
        public abstract void Rotate();

        public void OnTriggerEnter2D(Collider2D other)
        {
            Knife knife = other.GetComponent<Knife>();

            knife.Rigidbody2D.velocity = Vector2.zero;
            knife.transform.position = new Vector3(0f, 0.2f, 0f);
            knivesInShield.Add(knife);
            knife.transform.SetParent(this.transform);
        }
    } 
}

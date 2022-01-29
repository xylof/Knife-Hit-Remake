using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SDA.Generation
{
    public abstract class BaseShield : MonoBehaviour
    {
        private UnityAction onShieldHit;
        private UnityAction onWin;

        [SerializeField]
        private int knivesToWin;

        public int KnivesToWin => knivesToWin;

        [SerializeField]
        protected ShieldMovementStep[] movementScheme;

        private List<Knife> knivesInShield = new List<Knife>();

        public virtual void Initialize(UnityAction onShieldHitCallback, UnityAction onWinCallback)
        {
            onShieldHit = onShieldHitCallback;
            onWin = onWinCallback;
        }

        public abstract void Rotate();

        public virtual void Dispose()
        {
            for (int i = knivesInShield.Count - 1; i >= 0; i--) // Iterujemy od ty³u, poniewa¿ nasza lista bêdzie modyfikowana
            {
                Knife knife = knivesInShield[i];
                Destroy(knife.gameObject);
                knivesInShield.Remove(knife);
            }

            knivesInShield.Clear();
            onShieldHit = null;
            onWin = null;

            Destroy(this.gameObject);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            Knife knife = other.GetComponentInParent<Knife>();
            knife.Rigidbody2D.velocity = Vector2.zero;
            //knife.transform.rotation = Quaternion.identity; // Byæ mo¿e niepotrzebne, Quaternion.identity to wyzerowana rotacja dla Quaterniona
            knife.Rigidbody2D.isKinematic = true; // tryb Kinematic powoduje, ¿e inne elementy uderzaj¹ce w nó¿ nie mog¹ go ruszyæ
            knife.transform.position = new Vector3(0f, 0.1f, 0f);
            knivesInShield.Add(knife);
            knife.transform.SetParent(this.transform);

            onShieldHit.Invoke();

            if (knivesInShield.Count == knivesToWin)
            {
                onWin.Invoke();
            }
        }
    } 
}

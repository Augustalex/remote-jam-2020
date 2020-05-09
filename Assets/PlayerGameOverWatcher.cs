using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerGameOverWatcher : MonoBehaviour
    {
        private Carrier _carrier;
        public bool GameOver { get; set; }

        private void Awake()
        {
            _carrier = GetComponent<Carrier>();
        }

        void Update()
        {
            Debug.Log("_carrier.Infected: " + _carrier.Infected);
            if (_carrier.Infected)
            {
                GameOver = true;
            }
        }
    }
}
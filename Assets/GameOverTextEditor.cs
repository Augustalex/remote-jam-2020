using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameOverTextEditor : MonoBehaviour
    {
        private GameObject _winner;
        private bool _tie;

        void Update()
        {
            if (_tie)
            {
                GetComponent<Text>().text = "It's a tie!";
            }
            else if (_winner)
            {
                GetComponent<Text>().text = _winner.GetComponent<PlayerName>().Text + " won!";
            }
            else
            {
                checkForNewWinner();
            }
        }

        public bool GameIsOver()
        {
            return _winner || _tie;
        }

        private void checkForNewWinner()
        {
            var players = GameObject.FindGameObjectsWithTag("Player");
            var numberOfInfectedPlayers = players.Count(p => p.GetComponent<PlayerGameOverWatcher>().GameOver);
            if (numberOfInfectedPlayers >= players.Length - 1)
            {
                if (numberOfInfectedPlayers == players.Length - 1)
                {
                    _winner = players.First(p => !p.GetComponent<PlayerGameOverWatcher>().GameOver);
                }
                else
                {
                    _tie = true;
                }

                GetTryAgainButton().Show();
            }
        }
     
        public TryAgainButton GetTryAgainButton()
        {
            return GameObject.FindGameObjectWithTag("TryAgainButton").GetComponent<TryAgainButton>();
        }
    }
}
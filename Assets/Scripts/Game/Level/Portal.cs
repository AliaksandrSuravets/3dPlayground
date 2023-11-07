using System;
using UnityEngine;

namespace Playground.Game.Level
{
    public class Portal : MonoBehaviour
    {
        #region Unity lifecycle

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("You Win!!!! Please wait for the update");
        }

        #endregion
    }
}
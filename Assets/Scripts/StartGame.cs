using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class StartGame : MonoBehaviour
    {
        

        public void startGame()
        {
            SceneManager.LoadScene("FirstLevel");
        }
    }
}

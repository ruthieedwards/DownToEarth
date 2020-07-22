  using UnityEngine;
  using System.Collections;
  using UnityEngine.SceneManagement;
  
  public class PlayGameButton : MonoBehaviour
  {

      public void playGame()
      {
          SceneManager.LoadScene(1);
      }

  
  }
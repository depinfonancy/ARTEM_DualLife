using UnityEngine;

/// <summary>
/// Script de l'écran titre
/// </summary>
public class MenuScript : MonoBehaviour
{
  private GUISkin skin;

  void Start()
  {
	// Chargement de l'apparence
    skin = Resources.Load("GUISkin") as GUISkin;
  }

  void OnGUI()
  {
    const int buttonWidth = 84;
    const int buttonHeight = 60;

    GUI.skin = skin;

    // Affiche un bouton pour démarrer la partie
    if (
      GUI.Button(
        // Centré en x, 2/3 en y
        new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (2 * Screen.height / 3) - (buttonHeight / 2),
          buttonWidth,
          buttonHeight
        ),
        "Start !"
      )
    )
    {
      // Sur le clic, on démarre le premier niveau
      // "TutoScene_AvecSprites" est le nom de la première scène que nous avons créés.
      Application.LoadLevel("TutoScene_AvecSprites");
    }
    if (
      GUI.Button(
        // Centré en x, 1/3 en y
        new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (5 *Screen.height / 6) - (buttonHeight / 2),
          buttonWidth,
          buttonHeight
        ),
        "Quit !"
      )
    )
    {
      // Sur le clic, on ferme le jeu
      Application.Quit();
    }
  }
}

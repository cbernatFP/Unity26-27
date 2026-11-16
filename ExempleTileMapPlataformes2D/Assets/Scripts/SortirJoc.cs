using UnityEngine;

// Tanca el joc quan es prem la tecla Esc.
// No cal posar-lo a cap objecte de l'escena: es crea sol en arrencar el joc.
public class SortirJoc : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void Crear()
    {
        GameObject obj = new GameObject("SortirJoc");
        obj.AddComponent<SortirJoc>();
        DontDestroyOnLoad(obj); // Es manté encara que canviem d'escena
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            // A l'editor, Application.Quit() no fa res: aturem el mode Play
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
[InitializeOnLoad]
#endif
public class MouseLookPrefsProcessor : InputProcessor<Vector2> {
    public float MinSensMultiplier = 0.1f;
    public float MaxSensMultiplier = 1.5f;
#if UNITY_EDITOR
    static MouseLookPrefsProcessor() {
        Initialize();
    }
#endif
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize() {
        InputSystem.RegisterProcessor<MouseLookPrefsProcessor>();
    }
    public override Vector2 Process(Vector2 value, InputControl control) {



        float mlookSensPref = (float)_GAME.Data.GetActiveProfile().Get<double>(Pref.Sensitivity_Mouse);
        bool inv = _GAME.Data.GetActiveProfile().Get<bool>(Pref.Inversion_Mouse);





        float effectiveSensMulti = MinSensMultiplier + ((MaxSensMultiplier - MinSensMultiplier) * mlookSensPref);

        value *= effectiveSensMulti;

        if (!inv) {
            value.y *= -1;
        }


        return value;

    }
}

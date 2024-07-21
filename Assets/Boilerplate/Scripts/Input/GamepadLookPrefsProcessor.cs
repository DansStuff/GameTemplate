using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
[InitializeOnLoad]
#endif
public class GamepadLookPrefsProcessor : InputProcessor<Vector2> {
    public float MinDegPerSecond = 50f;
    public float MaxDegPerSecond = 600f;

#if UNITY_EDITOR
    static GamepadLookPrefsProcessor() {
        Initialize();
    }
#endif
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize() {
        InputSystem.RegisterProcessor<GamepadLookPrefsProcessor>();
    }
    public override Vector2 Process(Vector2 value, InputControl control) {

        float glookSensPref = _GAME.Data.GetActiveProfile().Get<float>(Pref.Sensitivity_Controller);
        bool inv = _GAME.Data.GetActiveProfile().Get<bool>(Pref.Inversion_Controller);


        float effectiveSensMulti = MinDegPerSecond + ((MaxDegPerSecond - MinDegPerSecond) * glookSensPref);

        value *= effectiveSensMulti;

        if (!inv) {
            value.y *= -1;
        }

        value *= Time.unscaledDeltaTime;


        return value;



    }
}

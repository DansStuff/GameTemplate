using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class _GAME : MonoBehaviour {

    private static _GAME _instance = null;


    private PersistentDataManager _data;
    public static PersistentDataManager Data {
        get { return get()._data; }
    }


    private UIManager _ui;
    public static UIManager UI {
        get { return get()._ui; }
    }

    void Awake() {

        if (_instance != null) {
            _instance.transientInit();
            Destroy(this.gameObject);

        } else {

            _instance = this;
            _instance.permanentInit();
            _instance.transientInit();
            DontDestroyOnLoad(gameObject);
        }

    }
    //happens when _GAME awakes for the first time
    private void permanentInit() {
        /*
		_audio              = GetComponentInChildren<AudioManager>();
		_constants          = GetComponentInChildren<Constants>();
		_input              = GetComponentInChildren<InputManager>();
		_players            = GetComponentInChildren<PlayerManager>();
		*/
        _data = GetComponentInChildren<PersistentDataManager>();
        _ui = GetComponentInChildren<UIManager>();
    }

    //happens when _GAME awakes subsequent times (on new scene loads)
    private void transientInit() {

    }

    public static _GAME get() {

        //instance was lost somehow, just search for it in currently loaded scene
        if (_instance == null) {
            _instance = GameObject.Find("_GAME").GetComponent<_GAME>();
        }

        return _instance;
    }
}

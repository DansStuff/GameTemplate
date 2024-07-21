using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileResetter : MonoBehaviour {

    public virtual void ResetProfile(SerializableDataStore profile) {

        profile.Clear();
        profile.Set(Pref.Volume_Master, 1f);
        profile.Set(Pref.Volume_Music, 0.5f);
        profile.Set(Pref.Volume_SFX, 0.5f);

        profile.Set(Pref.Sensitivity_Controller, 0.5f);
        profile.Set(Pref.Sensitivity_Mouse, 0.5f);

        profile.Set(Pref.Inversion_Controller, true);
        profile.Set(Pref.Inversion_Mouse, false);

    }

}

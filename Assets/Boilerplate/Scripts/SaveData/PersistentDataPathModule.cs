using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistentDataPathModule : SaveDataSourceModule {

    public string ProfilesFilename = "/playerprofiles.json";

    private JsonSerializerSettings jsonSettings;

    void Awake() {
        jsonSettings = new JsonSerializerSettings();
        jsonSettings.TypeNameHandling = TypeNameHandling.Auto;


        jsonSettings.FloatParseHandling = FloatParseHandling.Double;
    }

    public override PlayerProfiles LoadProfiles() {
        if (File.Exists(Application.persistentDataPath + ProfilesFilename)) {
            string serial = File.ReadAllText(Application.persistentDataPath + ProfilesFilename);
            object deserial = null;
            try {
                deserial = JsonConvert.DeserializeObject(serial, typeof(PlayerProfiles), jsonSettings);
            } catch (System.Exception e) {
                Debug.LogError(e);
            }
            return (PlayerProfiles)deserial;
        } else {
            Debug.Log("File did not exist: " + Application.persistentDataPath + ProfilesFilename);
            return null;
        }
    }

    public override bool SaveProfiles(PlayerProfiles profiles) {

        if (profiles == null) {
            Debug.LogError("Attempted to save null object");
            return false;
        }




        string serial = JsonConvert.SerializeObject(profiles, Formatting.Indented, jsonSettings);

        try {
            File.WriteAllText(Application.persistentDataPath + ProfilesFilename, serial);
        } catch (System.Exception e) {
            Debug.LogError("Error while saving profiles: " + e);
            return false;
        }
        return true;

    }


}

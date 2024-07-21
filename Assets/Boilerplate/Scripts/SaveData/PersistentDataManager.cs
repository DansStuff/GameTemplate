using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class PersistentDataManager : MonoBehaviour {


    private PlayerProfiles playerProfiles;


    private SerializableDataStore currentProfile;

    private ProfileResetter resetter;
    private SaveDataSourceModule dataSourceModule;

    private SaveDataSourceModule getDataSourceModule() {
        if (dataSourceModule == null) {
            dataSourceModule = GetComponentInChildren<SaveDataSourceModule>();
        }
        return dataSourceModule;
    }

    private ProfileResetter getProfileResetter() {
        if (resetter == null) {
            resetter = GetComponentInChildren<ProfileResetter>();
        }
        return resetter;
    }

    void OnEnable() {

        LoadProfilesData();

    }

    public void ResetProfile(SerializableDataStore profile) {
        getProfileResetter().ResetProfile(profile);

    }

    //todo: this needs more flexibility, cant be overwriting all profile data every time theres an error loading
    private void LoadProfilesData() {
        playerProfiles = getDataSourceModule().LoadProfiles();
        if (playerProfiles != null) {
            currentProfile = playerProfiles.defaultProfile;
        } else {
            Debug.Log("Failed to load player profiles, creating defaults...");
            playerProfiles = new PlayerProfiles();
            getProfileResetter().ResetProfile(playerProfiles.defaultProfile);
            SaveProfilesData();
            currentProfile = playerProfiles.defaultProfile;
        }
    }

    private void SaveProfilesData() {
        getDataSourceModule().SaveProfiles(playerProfiles);
    }

    public SerializableDataStore GetActiveProfile() {
        return currentProfile;
    }

    void OnDisable() {
        SaveProfilesData();
    }

}

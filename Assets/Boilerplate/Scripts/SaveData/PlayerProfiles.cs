using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfiles {

    public SerializableDataStore defaultProfile = new SerializableDataStore();

    public List<SerializableDataStore> profiles = new List<SerializableDataStore>();


}

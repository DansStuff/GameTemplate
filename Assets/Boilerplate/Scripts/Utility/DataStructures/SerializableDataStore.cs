using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDataStore {

    [JsonProperty]
    private Dictionary<string, Dictionary<string, object>> typeDicts =
        new Dictionary<string, Dictionary<string, object>>();


    public void Clear() {
        typeDicts.Clear();

    }

    public void Set<T>(string key, T value) {


        string typeName = typeof(T).ToString();
        if (typeName.Equals("System.Single")) {
            Debug.LogError("error setting: " + key + " use double instead of float");
        }

        if (!typeDicts.ContainsKey(typeName)) {
            typeDicts[typeName] = new SerializableDictionary<string, object>();
            typeDicts[typeName][key] = value;

        } else {

            typeDicts[typeName][key] = value;
        }
    }

    public void Set(string key, float value) {
        Set<double>(key, (double)value);
    }

    public T Get<T>(string key) {

        string typeName;

        if (typeof(T) == typeof(float)) {
            typeName = typeof(double).ToString();
        } else {
            typeName = typeof(T).ToString();
        }

        if (typeDicts.ContainsKey(typeName)) {

            if (typeDicts[typeName].ContainsKey(key)) {
                return (T)typeDicts[typeName][key];
            }

        }
        Debug.Log("could not find key: " + key);
        return default;
    }



}
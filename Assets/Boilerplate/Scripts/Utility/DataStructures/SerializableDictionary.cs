using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver {


    [SerializeField]
    private List<SerializableKVP<TKey, TValue>> Data = new List<SerializableKVP<TKey, TValue>>();

    // save the dictionary to lists
    public void OnBeforeSerialize() {
        Debug.Log("on before serialize");

        Data.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this) {

            Data.Add(new SerializableKVP<TKey, TValue> {
                key = pair.Key,
                value = pair.Value

            });
        }
    }

    // load dictionary from lists
    public void OnAfterDeserialize() {
        Debug.Log("on after serialzie");

        this.Clear();

        for (int i = 0; i < Data.Count; i++) {
            Add(Data[i].key, Data[i].value);
        }
    }
}

[Serializable]
public struct SerializableKVP<TKey, TValue> {

    public TKey key;
    public TValue value;


}

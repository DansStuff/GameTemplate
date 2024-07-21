using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SaveDataSourceModule : MonoBehaviour {



    public abstract PlayerProfiles LoadProfiles();

    public abstract bool SaveProfiles(PlayerProfiles profiles);

}

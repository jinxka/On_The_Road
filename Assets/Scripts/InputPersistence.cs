using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPersistence : MonoBehaviour {

    #region UnityCompliant Singleton
    public static InputPersistence Instance
    {
        get;
        private set;
    }

    public virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            return;
        }
        Destroy(gameObject);
    }

    #endregion
}

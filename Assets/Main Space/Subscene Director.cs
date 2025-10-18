using Unity.Entities;
using Unity.Scenes;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class SubsceneDirector : MonoBehaviour {
    public SubScene DestroyedDemo;
    public SubScene RestoredDemo;

    public SubScene subSceneToLoad;
    private Entity subScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //FlipSwitch(false);
        LoadSubScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            LoadSubScene();
            Debug.Log($"Loading subscene: {RestoredDemo.name}");
        }

        if (Gamepad.current.buttonWest.wasPressedThisFrame)
        {
            UnLoadSubScene();
            Debug.Log($"Unloading subscene: {RestoredDemo.name}");
        }
    }

    private void LoadSubScene()
    {
        var loadParameters = new SceneSystem.LoadParameters
        {
            Flags = SceneLoadFlags.NewInstance
        };

        subScene = SceneSystem.LoadSceneAsync(World.DefaultGameObjectInjectionWorld.Unmanaged, subSceneToLoad.SceneGUID, loadParameters);

        StartCoroutine(CheckScene());
    }

    private void UnLoadSubScene()
    {
        // Specify unload parameters, you can adjust these based on your requirements.
        var unloadParameters = SceneSystem.UnloadParameters.DestroyMetaEntities;
        SceneSystem.UnloadScene(World.DefaultGameObjectInjectionWorld.Unmanaged, subScene, unloadParameters);
    }

    IEnumerator CheckScene()
    {
        while (!SceneSystem.IsSceneLoaded(World.DefaultGameObjectInjectionWorld.Unmanaged, subScene))
        {
            yield return null;
        }
    }


    //void FlipSwitch(bool trueIfRestored)
    //{
    //    SceneSystem sceneSystem = World.GetOrCreateSystemManaged<SceneSystem>();

    //    if (trueIfRestored)
    //    {
    //        sceneSystem.LoadSceneAsync(RestoredDemo.SceneGUID);
    //        Debug.Log($"Loading subscene: {RestoredDemo.name}");
    //        sceneSystem.UnloadScene(DestroyedDemo.SceneGUID);
    //        Debug.Log($"Unloading subscene: {DestroyedDemo.name}");
    //    }
    //    else { }
    //    sceneSystem.LoadSceneAsync(DestroyedDemo.SceneGUID);
    //    Debug.Log($"Loading subscene: {DestroyedDemo.name}");
    //    sceneSystem.UnloadScene(RestoredDemo.SceneGUID);
    //    Debug.Log($"Unloading subscene: {RestoredDemo.name}");
    //}
}

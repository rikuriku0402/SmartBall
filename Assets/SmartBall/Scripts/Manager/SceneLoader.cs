using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// シーンを変えるための関数
    /// </summary>
    /// <param name="scene">シーン名</param>
    public static void SceneChange(string scene) => SceneManager.LoadSceneAsync(scene);
}

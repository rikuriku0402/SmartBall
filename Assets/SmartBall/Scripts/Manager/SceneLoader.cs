using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    [Header("シーンリセットボタン")]
    private Button _button;
    
    void Start() => _button.onClick.AddListener(() => SceneChange("Main"));
    

    private void SceneChange(string scene) => SceneManager.LoadSceneAsync(scene);
    
}

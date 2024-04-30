#if(UNITY_EDITOR)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[ExecuteInEditMode]
public class ChangeScriptableObjectsBack : MonoBehaviour
{
    public SoundClip[] clips;

    private void Update()
    {
        if(!EditorApplication.isPlayingOrWillChangePlaymode && EditorApplication.isPlaying)
        {
            for(int i = 0; i < clips.Length; i++)
            {
                clips[i].volume = clips[i].originalVolume;
                print(clips[i].clipName + " has been changed back to original volume");
            }
        }
    }
}
#endif
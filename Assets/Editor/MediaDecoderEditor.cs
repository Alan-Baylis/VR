using UnityEngine;
using System.Collections;
using UnityEditor;
using HTC.UnityPlugin.Multimedia;
using UnityEngine.UI;
using UnityEngine.Events;

[CustomEditor(typeof(MediaDecoder))]
public class MediaDecoderEditor : Editor {
    MediaDecoder mDecoder;

    void OnEnable()
    {
        // Get MediaDecoder       
        mDecoder = (MediaDecoder)target;
    }

    // Override normal inspector
    public override void OnInspectorGUI()
    {
        
        // Video file extensions for file selection (can be cleaned if wanted to)
        string[] extensions = { "Video files",
                    "webm,mkv,flv,vob,ogv,ogg,drc,gif,gifv,mng,avi,mov,qt,wmv,yuv,rm,rmvb,asf,amv,mp4,m4p,mpg,mp2,mpeg,mpe,mpv,mpg,mpeg,m2v,m4v,svi,3gp,3g2,mxf,nsv,flv,f4v,f4p,f4a,f4b",
                    "All files", "*" };
        
        // Add button for selecting file
        if (GUILayout.Button("Select Video File"))
        {
            mDecoder.mediaPath = EditorUtility.OpenFilePanelWithFilters(
                                                 "Select video",
                                                 "",
                                                 extensions);
        }

        // Show normal inspector (very handy as UnityEvents are pain in the ass to make in Custom Inspector)
        base.OnInspectorGUI();


    }
}

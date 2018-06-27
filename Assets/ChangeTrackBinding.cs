using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ChangeTrackBinding : MonoBehaviour {

    public PlayableDirector director;
    public GameObject targetInstance;
    public string trackName;

    public void ChangeInstance () {
        TimelineAsset timelineAsset = (TimelineAsset)director.playableAsset;
        if (timelineAsset == null)
            return;
        TrackAsset track = null;
        if( trackName.Length> 0) {
            foreach( TrackAsset t in timelineAsset.GetOutputTracks()) {
                Debug.Log(t.name);
                if (t.name.Equals(trackName))
                    track = t;
            }
        } else {
            track = timelineAsset.GetOutputTrack(0);
        }
        if( track != null) {
            if( track.GetType() == typeof(AnimationTrack))
                director.SetGenericBinding(track, targetInstance.GetComponent<Animator>());
            else
                director.SetGenericBinding(track, targetInstance);
        }
            
	}
	
    private void Start()
    {
        ChangeInstance();
    }

}

using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SubtitleData : PlayableAsset, ITimelineClipAsset
{
    public SubtitleDataPlayable subtitleData = new SubtitleDataPlayable();

    /// <summary>
    /// Create the runtime version of the clip, by creating a copy of the template
    /// </summary>
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        return ScriptPlayable<SubtitleDataPlayable>.Create(graph, subtitleData);
    }

    /// <summary>
    /// This tells the Timeline Editor what features this clip supports
    /// </summary>
    public ClipCaps clipCaps => ClipCaps.Blending | ClipCaps.Extrapolation;
}

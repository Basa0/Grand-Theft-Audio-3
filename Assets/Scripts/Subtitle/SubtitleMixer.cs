using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SubtitleMixer : PlayableBehaviour
{
    /// <summary>
    /// Called each frame the mixer is active, after inputs are processed
    /// </summary>
    public override void ProcessFrame(Playable handle, FrameData info, object playerData)
    {
        var textObject = playerData as Text;
        if (textObject == null) {
            return;
        }

        string text = string.Empty;

        var count = handle.GetInputCount();
        for (var i = 0; i < count; i++) {

            var inputHandle = handle.GetInput(i);
            var weight = handle.GetInputWeight(i);

            if (inputHandle.IsValid()
                && inputHandle.GetPlayState() == PlayState.Playing
                && weight > 0) {
                var data = ((ScriptPlayable<SubtitleDataPlayable>) inputHandle).GetBehaviour();
                if (data != null) {
                    if (weight > 0.5) {
                        text = data.text;
                    }
                }

            }
        }

        textObject.text = text;
    }
}

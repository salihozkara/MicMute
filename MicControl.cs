using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Mixer;

namespace MicMute
{
    internal class MicControl
    {
        public static void MuteOrUnMute()
        {
            var mixerLine = new MixerLine((IntPtr)0,
                0, MixerFlags.WaveIn);
            foreach (var mixerControl in mixerLine.Controls.Where(c=>c.ControlType == MixerControlType.Mute && c is BooleanMixerControl).Cast<BooleanMixerControl>())
            {
                mixerControl.Value = !mixerControl.Value ;
            }
        }

        public static bool MuteStatus()
        {
            var mixerLine = new MixerLine((IntPtr)0,
                0, MixerFlags.WaveIn);
            var controls =
                mixerLine.Controls.Where(c => c.ControlType == MixerControlType.Mute && c is BooleanMixerControl).Cast<BooleanMixerControl>();
            var status= controls.All(c=>c.Value);
            return status;
        }
    }
}

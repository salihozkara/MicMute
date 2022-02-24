using System;
using System.Collections.Generic;
using System.Linq;
using KeyHook;
using NAudio.Mixer;

namespace MicMute
{
    public class KeyHook
    {
        private static int _hookId;
        public static void Key(HashSet<int> hash,Action action)
        {
            GlobalKeyboardHook.Instance.UnHook((int)_hookId);

            _hookId = GlobalKeyboardHook.Instance.Hook(hash, action, out _);
        }
    }
}
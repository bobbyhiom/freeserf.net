using System;
using System.Collections.Generic;

namespace Freeserf
{
    public static class KeyBindings
    {
        private static readonly List<KeyBinding> bindings = new();
        public static IReadOnlyList<KeyBinding> Bindings => bindings;
        static KeyBindings()
        {
            SetDefaultKeys();
        }
        public static void SetDefaultKeys()
        {
            bindings.Clear();

            bindings.Add(new KeyBinding
            {
                friendlyName = "Game Speed Increase",
                settingKey = SettingKey.GameSpeedIncrease,
                character = '+'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Game Speed Decrease",
                settingKey = SettingKey.GameSpeedDecrease,
                character = '-'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Game Speed Reset",
                settingKey = SettingKey.GameSpeedReset,
                character = '0'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Game Speed Max",
                settingKey = SettingKey.GameSpeedMaximum,
                character = '9'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Pause",
                settingKey = SettingKey.Pause,
                character = 'p'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Toggle Sound",
                settingKey = SettingKey.SoundToggle,
                character = 'S'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Toggle Music",
                settingKey = SettingKey.MusicToggle,
                character = 'M'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Message View",
                settingKey = SettingKey.MessageViewer,
                character = Event.SystemKeys.Tab
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Toggle Build Guide",
                settingKey = SettingKey.Build,
                character = 'b'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Go to Castle",
                settingKey = SettingKey.CastleView,
                character = 'h'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Go to Next Player",
                settingKey = SettingKey.ViewNextPlayer,
                character = 'j'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Toggle Map",
                settingKey = SettingKey.ToggleMap,
                character = 'm'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Quit Confirm",
                settingKey = SettingKey.QuitConfirm,
                character = 'Q'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Show Player Faces",
                settingKey = SettingKey.PlayerMap,
                character = 'P'
            });

            bindings.Add(new KeyBinding
            {
                friendlyName = "Demolish",
                settingKey = SettingKey.Demolish,
                character = Event.SystemKeys.Delete
            });
        }

        public static void LoadUserSetKey(string type, string value)
        {
            if (string.IsNullOrEmpty(value))
                return;

            if (Enum.TryParse<SettingKey>(type, out var keyBindingType))
            {
                var binding = bindings.Find(x => x.settingKey == keyBindingType);

                if (binding != null)
                    binding.character = value[0];
            }
        }
    }

    public class KeyBinding
    {
        public string friendlyName {  get; set; }
        public SettingKey settingKey { get; set; }
        public char character { get; set; }
    }

    public enum SettingKey
    {
        // Game speed
        GameSpeedIncrease,
        GameSpeedDecrease,
        GameSpeedReset,
        GameSpeedMaximum,
        Pause,
        // Audio
        SoundToggle,
        MusicToggle,
        //GameControl
        MessageViewer,
        Build,
        CastleView,
        ViewNextPlayer,
        ToggleMap,
        QuitConfirm,
        PlayerMap,
        Demolish
    }
}

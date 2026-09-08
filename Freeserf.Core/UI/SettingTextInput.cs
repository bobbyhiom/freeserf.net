using System;

namespace Freeserf.UI
{
    internal class SettingTextInput : TextInput
    {
        string savedText = "";
        public readonly SettingKey settingKey;

        public SettingTextInput(Interface interf, SettingKey settingKey, int characterGapSize = 9)
            : base(interf, characterGapSize, Render.TextRenderType.LegacySpecialDigits)
        {
            //BackgroundColor = new Render.Color(0x23, 0x43, 0x00);
            //BackgroundFocusColor = new Render.Color(0x23, 0x43, 0x00);
            this.settingKey = settingKey;
            SetFilter(TextInputFilter);
            SetSize(3 * 9 + 8, 3 * 9 + 8 + 1);
            MaxLength = 16;
        }

        static bool TextInputFilter(char key, TextInput textInput)
        {
            //TODO sort this out later
            
            //if (key < '1' || key > '8')
            //{
            //    return false;
            //}

            //if (textInput.Text.Length > 16)
            //{
            //    return false;
            //}

            return true;
        }

        protected override bool HandleKeyPressed(char key, int modifier)
        {
            if(!base.HandleKeyPressed(key, modifier)) 
                return false;

            savedText = Text;

            return true;
        }

        protected override bool HandleFocusLoose()
        {
            base.HandleFocusLoose();

            if (Text.Length < 1 && savedText.Length > 0)
            {
                Text = savedText;
                savedText = "";
            }

            return true;
        }
    }
}

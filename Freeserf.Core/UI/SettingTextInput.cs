using Freeserf.Render;
using SixLabors.ImageSharp.Processing;
using System;

namespace Freeserf.UI
{
    internal class SettingTextInput : TextInput
    {
        string savedText = "";
        public readonly KeyBinding binding;

        public SettingTextInput(Interface interf, KeyBinding binding, int characterGapSize = 9)
            : base(interf, characterGapSize, Render.TextRenderType.NewUI)
        {
            //BackgroundColor = new Render.Color(0x23, 0x43, 0x00);
            //BackgroundFocusColor = new Render.Color(0x23, 0x43, 0x00);
            this.binding = binding;
            SetFilter(TextInputFilter);
            int characterSize = (int)(8*Global.NewUIFontScale);
            SetSize(characterSize, characterSize);
            MaxLength = 1;
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

        protected override bool HandleClickLeft(int x, int y, bool delayed)
        {
            base.HandleClickLeft(x, y, delayed);
            if (!delayed)
            {
                savedText = Text;
                Text = ""; // Remove existing value (It will come back if they dont fill it in. Dont worry)
            }

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

            if (Text.Length != 1)
            {
                Text = savedText;
                savedText = "";
            }

            if (!string.IsNullOrEmpty(Text))
            {
                binding.character = Text[0];
            }

            return true;
        }
    }
}

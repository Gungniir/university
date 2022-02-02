using System;
using Microsoft.VisualBasic;

namespace test1.consoler
{
    public class Cell
    {
        public enum TextAlignEnum
        {
            Left,
            // ReSharper disable once UnusedMember.Global
            Center,
            Right,
        }

        public enum WidthModeEnum
        {
            // ReSharper disable once UnusedMember.Global
            Auto,
            FitContent,
            Fixed,
        }

        public TextAlignEnum TextAlign { get; set; }
        public WidthModeEnum WidthMode { get; set; }

        public int AvailableWidth { get; set; }
        public int FixedWidth { get; set; }

        public string Text { get; set; }

        public int Width()
        {
            if (WidthMode == WidthModeEnum.Fixed)
            {
                return FixedWidth;
            }

            return Text.Length + 2;
        }

        public override string ToString()
        {
            if (WidthMode == WidthModeEnum.Fixed && Text.Length > FixedWidth - 2)
            {
                return $" {Strings.Left(Text, FixedWidth - 2)} ";
            }
            if (WidthMode == WidthModeEnum.Fixed && Text.Length <= FixedWidth - 2) {
                AvailableWidth = FixedWidth;
            }

            if (WidthMode == WidthModeEnum.FitContent)
            {
                return $" {Text} ";
            }
            
            // WidthMode = auto

            if (TextAlign == TextAlignEnum.Left)
            {
                return $" {Text}{new string(' ', AvailableWidth - 1 - Text.Length)}";
            }

            if (TextAlign == TextAlignEnum.Right)
            {
                return $"{new string(' ', AvailableWidth - 1 - Text.Length)}{Text} ";
            }
            
            // Center

            string leftPadding = new string(' ', (AvailableWidth - Text.Length) / 2);
            string rightPadding = leftPadding + new string(' ', (AvailableWidth - Text.Length) % 2);

            return leftPadding + Text + rightPadding;
        }
    }
}
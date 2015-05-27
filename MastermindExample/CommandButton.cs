/* Copyright 2011 Marco Minerva, marco.minerva@gmail.com

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;

using GT = Gadgeteer;

namespace CommandButtonExample
{
    public class CommandButton : Border
    {
        private Text buttonText;

        public GT.Color BorderColor { get; set; }
        public GT.Color BackgroundColor { get; set; }
        public GT.Color PressedBorderColor { get; set; }
        public GT.Color PressedBackgroundColor { get; set; }

        public event EventHandler Click;

        private Canvas container;
        private int top;
        private int left;

        public CommandButton(Font font, string content)
            : this(font, content, null, 0, 0)
        { }

        public CommandButton(Font font, string content, Canvas canvas, int top, int left)
        {
            BackgroundColor = GT.Color.FromRGB(230, 230, 230);
            BorderColor = GT.Color.DarkGray;
            PressedBorderColor = GT.Color.DarkGray;
            PressedBackgroundColor = GT.Color.LightGray;

            this.HorizontalAlignment = HorizontalAlignment.Center;
            this.Background = new SolidColorBrush(BackgroundColor);
            this.BorderBrush = new SolidColorBrush(BorderColor);
            this.SetBorderThickness(2, 2, 2, 2);
            buttonText = new Text(font, content);
            buttonText.SetMargin(5);
            buttonText.HorizontalAlignment = HorizontalAlignment.Center;
            this.Child = buttonText;

            if (canvas != null)
                this.AddToCanvas(canvas, top, left);
        }

        protected override void OnTouchDown(Microsoft.SPOT.Input.TouchEventArgs e)
        {
            if (container != null)
                Canvas.SetTop(this, top + 1);

            this.Background = new SolidColorBrush(PressedBackgroundColor);
            this.BorderBrush = new SolidColorBrush(PressedBorderColor);
            base.OnTouchDown(e);
        }

        protected override void OnTouchUp(Microsoft.SPOT.Input.TouchEventArgs e)
        {
            if (container != null)
                Canvas.SetTop(this, top - 1);

            this.Background = new SolidColorBrush(BackgroundColor);
            this.BorderBrush = new SolidColorBrush(BorderColor);
            base.OnTouchUp(e);
            OnClick();
        }

        public void AddToCanvas(Canvas canvas, int top, int left)
        {
            this.container = canvas;
            this.top = top;
            this.left = left;

            canvas.Children.Add(this);
            Canvas.SetTop(this, top);
            Canvas.SetLeft(this, left);
        }

        public string Text
        {
            get { return buttonText.TextContent; }
            set { buttonText.TextContent = value; }
        }

        protected virtual void OnClick()
        {
            if (Click != null)
                Click(this, EventArgs.Empty);
        }
    }
}

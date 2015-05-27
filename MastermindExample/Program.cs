using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;
using CommandButtonExample;

namespace MastermindExample
{
    public partial class Program
    {

        Window mainWindow;
        Canvas layout;
        Text label;
        private Text txtMessage;
        


        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            
           SetupUI();
           joystick.JoystickPressed += joystick_JoystickPressed;
           
           Debug.Print(" Started");
        }

        void joystick_JoystickPressed(Joystick sender, Joystick.ButtonState state)
        {
            throw new NotImplementedException();
        }

        void SetupUI()
        {



            // initialize window    
            mainWindow = displayTE35.WPFWindow;

            // setup the layout
            layout = new Canvas();
            Border background = new Border();
            background.Background = new SolidColorBrush(Colors.Black);
            background.Height = 240;
            background.Width = 320;

            layout.Children.Add(background);
            Canvas.SetLeft(background, 0);
            Canvas.SetTop(background, 0);

            // add the text area
            label = new Text("Select Mode");
            label.Height = 240;
            label.Width = 320;
            label.ForeColor = Colors.Orange;
            label.Font = Resources.GetFont(Resources.FontResources.NinaB);
            layout.Children.Add(label);
            Canvas.SetLeft(label, 20);
            Canvas.SetTop(label, 20);


            CommandButton cmdButton = new CommandButton(Resources.GetFont(Resources.FontResources.NinaB), "        1 Player        ");
            cmdButton.AddToCanvas(layout, 50, 20);
            cmdButton.PressedBackgroundColor = GT.Color.Red;

            CommandButton cmdButton2 = new CommandButton(Resources.GetFont(Resources.FontResources.NinaB), "        2 Player        ");
            cmdButton2.AddToCanvas(layout, 100, 20);
            cmdButton2.PressedBackgroundColor = GT.Color.Yellow;



            cmdButton.Click += new EventHandler(cmdButton_Click);
            txtMessage = new Text(Resources.GetFont(Resources.FontResources.NinaB), string.Empty);
            layout.Children.Add(txtMessage);
            Canvas.SetTop(txtMessage, 150);
            Canvas.SetLeft(txtMessage, 20);

            mainWindow.Child = layout;
        }
        private int clicks = 0;

        private void cmdButton_Click(object sender, EventArgs e)
        {
            clicks++;
            txtMessage.TextContent = "You clicked the button " + clicks + " times.";
        }       


        
    }
}

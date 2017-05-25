using System;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Core;

using System.Collections.Generic;
using System.IO;

namespace Shmup {

    // == Program, Entry Point ==

    static class Program {

        // == STATE ==
        // Keep the state of the elements of the game here (variables hold state).


        // == BEHAVIOUR ==

        // This procedure is called (invoked) before the first time onTick is called.
        static void onInit() {

        }

        // Draw on the surface
        // This procedure is called (invoked) on each onTick
        static void onDraw(Surface image) {

            // Put your code to draw on the surface here

            image.Fill(Color.Wheat);

            Line line = new Line(50,50,100,100);
            line.Draw(image,Color.Blue,true);

            Circle circle = new Circle(200,200,50);
            circle.Draw(image,Color.Red,true,true);

            Polygon poly = new Polygon(new short[]{360,380,400,380}, new short[]{400,380,420,440});
            poly.Draw(image,Color.Green,true,true);
          
        }

        // This procedure is called (invoked) for each window refresh
        static void onTick(object sender, TickEventArgs args) {

            // STEP
            // Update the state of the elements here.

            // DRAW
            // Draw the new view based on the state of the elements here.
            onDraw(image);
            video.Blit(image);

            // ANIMATE 
            // Step the animation frames ready for the next tick.

            // REFRESH
            // Tranfer the new view to the screen for the user to see.
            video.Update();

        }

        // this procedure is called when the mouse is moved
        static void onMouseMove(object sender, SdlDotNet.Input.MouseMotionEventArgs args) {

        }

        // this procedure is called when a mouse button is pressed or released
        static void onMouseButton(object sender, SdlDotNet.Input.MouseButtonEventArgs args) {

        }

        // this procedure is called when a key is pressed or released
        static void onKeyboard(object sender, SdlDotNet.Input.KeyboardEventArgs args) {

            if (args.Down) { 

                switch (args.Key) {
                    case SdlDotNet.Input.Key.RightArrow :
                        break;
                    case SdlDotNet.Input.Key.LeftArrow :
                        break;
                    case SdlDotNet.Input.Key.UpArrow :
                        break;
                    case SdlDotNet.Input.Key.Space :
                        break;
                        
                    case SdlDotNet.Input.Key.Escape :
                        Events.QuitApplication();
                        break;
                }

            } else {

                switch (args.Key) {
                    case SdlDotNet.Input.Key.RightArrow :
                    case SdlDotNet.Input.Key.LeftArrow :
                        break;
                }

            }

        }

        // --------------------------
        // ----- GAME Utilities -----  
        // --------------------------

        // -- APPLICATION ENTRY POINT --

        static void Main() {
            //System.Windows.Forms.Cursor.Hide();

            // Create display surface.
            video = Video.SetVideoMode(FRAME_WIDTH, FRAME_HEIGHT, COLOUR_DEPTH, FRAME_RESIZABLE, USE_OPENGL, FRAME_FULLSCREEN, USE_HARDWARE);
            Video.WindowCaption = "Recur";
            Video.WindowIcon(new Icon(@"images/tree-icon.ico"));

            // invoke application initialisation subroutine
            setup();

            // invoke secondary initialisation subroutine
            onInit();

            // register event handler subroutines
            Events.Tick += new EventHandler<TickEventArgs>(onTick);
            Events.Quit += new EventHandler<QuitEventArgs>(onQuit);
            Events.KeyboardDown += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(onKeyboard);
            Events.KeyboardUp += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(onKeyboard);
            Events.MouseButtonDown += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(onMouseButton);
            Events.MouseButtonUp += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(onMouseButton);
            Events.MouseMotion += new EventHandler<SdlDotNet.Input.MouseMotionEventArgs>(onMouseMove);

            // while not quit do process events
            Events.TargetFps = 60;
            Events.Run();
        }

        // This procedure is called after the video has been initialised but before any events have been processed.
        static void setup() {
            image = video.CreateCompatibleSurface();
        }

        // This procedure is called when the event loop receives an exit event (window close button is pressed)
        static void onQuit(object sender, QuitEventArgs args) {
            Events.QuitApplication();
        }

        // -- DATA --

        const int FRAME_WIDTH = 800;
        const int FRAME_HEIGHT = 600;
        const int COLOUR_DEPTH = 32;
        const bool FRAME_RESIZABLE = false;
        const bool FRAME_FULLSCREEN = false;
        const bool USE_OPENGL = false;
        const bool USE_HARDWARE = true;

        static Surface video;  // the window on the display
        static Surface image;

    }
}

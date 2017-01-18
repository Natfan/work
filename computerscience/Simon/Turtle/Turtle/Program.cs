using System;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Core;

using System.Collections.Generic;
using System.IO;

namespace Turtle{

    public class Pen {

        private Surface surface;
        private Color color;
        private bool down;
        private double x;
        private double y;
        private int heading;

        public Pen(Surface surface, Color color, bool down, double x, double y, int heading) {
            this.surface = surface;
            this.color = color;
            this.down = down;
            this.x = x;
            this.y = y;
            this.heading = heading;
        }

        public void penUp() {
            this.down = false;
        }

        public void penDown() {
            this.down = true;
        }

        public void turn(int degrees) {
            heading = (heading - degrees) % 360;
        }

        public void forward(int distance) {

            // do maths in floating point to avoid rounding errors
            double radians = (double)heading * Math.PI / (double)180.0;
            double dx = (double)distance * Math.Cos(radians);
            double dy = (double)distance * Math.Sin(radians);

            if (down) {
                // points (x,y) can only be expressed in whole pixels (integer values)
                // short is a 16bit integer
                Line line = new Line((short)x,(short)y,(short)(x + dx), (short)(y - dy));
                line.Draw(surface, color);
            }

            // update the position of the pen after drawing the line (the pen is now at the end of the line)
            x += dx;
            y -= dy;
        }

    }

    // == Program, Entry Point ==

    static class Program {

        // == STATE ==
        // Keep the state of the elements of the game here (variables hold state).

        public static int detail = 0;

        // == BEHAVIOUR ==

        // This procedure is called (invoked) before the first time onTick is called.
        static void onInit() {
        }

        static void snowflake(int depth, int length, Pen pen) {

            if (depth == 0 || length < 2) {

                pen.forward(length);

            } else {

                snowflake(depth - 1, length / 3, pen);
                
                pen.turn(-60);

                snowflake(depth - 1, length / 3, pen);

                pen.turn(120);

                snowflake(depth - 1, length / 3, pen);

                pen.turn(-60);

                snowflake(depth - 1, length / 3, pen);

            }
        }

        static void tree (int depth, int length, Pen pen) {
            if (depth == 0 || length < 2) {
                pen.forward(length);
            } else {
                //for (int i = 1; i < 50; i++) {
                tree(depth - 1, length / 2, pen);
                pen.turn(1);
                //}
            }
        }

        // Draw on the surface
        // This procedure is called (invoked) on each onTick
        static void onDraw(Surface image) {

            // Put your code to draw on the surface here

            image.Fill(Color.Black);

            Pen pen = new Pen(image, Color.White, true, 400, 500, 90);

            /*
            pen.forward(100); 

            pen.turn(-60);

            pen.forward(100); 

            pen.turn(120);

            pen.forward(100); 

            pen.turn(-60);

            pen.forward(100);*/

            tree(detail,600,pen);
          
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
                        detail++;
                        break;
                    case SdlDotNet.Input.Key.DownArrow :
                        detail--;
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
            Video.WindowCaption = "Turtle";
            Video.WindowIcon(new Icon(@"images/app-icon.ico"));

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
            Events.TargetFps = 30;
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

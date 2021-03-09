using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.CameraType;
using static Raylib_cs.CameraMode;
using static Raylib_cs.Color;

namespace pogcghamp
{
    public class Program
    {
        int windowHeight = 900;
        int windowWidth = 1600;
        string windowTitle = "lmao gg";

        static Vector2 xhairpos;   


        public static void Main(string[] args)
        {
            Program program = new Program();
            program.RunGame();
        }
        void RunGame()
        {
            InitWindow(windowWidth , windowHeight , windowTitle);
            SetTargetFPS(144);

            Camera3D camera = new Camera3D();
            camera.position = new Vector3(4.0f , 2.0f , 4.0f);
            camera.target = new Vector3(0.0f , 1.8f , 0.0f);
            camera.up = new Vector3(0.0f , 1.0f , 0.0f);
            camera.fovy = 60.0f;
            camera.type = CAMERA_PERSPECTIVE;

            LoadGame();

            while (!WindowShouldClose())
            {
                Update();
                Draw();
                HideCursor();
            }
            Raylib.CloseWindow();
        }
        public static void LoadGame()
        {
            Assets.LoadAssets();
            
        }

        public void Update()
        {
            xhairpos = GetMousePosition();
            
        }
        public static void Draw()
        {
            BeginDrawing();
            ClearBackground(Color.BLACK);

            DrawTextureEx(Assets.xhair , xhairpos ,0,(float)0.1, Color.RAYWHITE);

            EndDrawing();
        }
    }
}


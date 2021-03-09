using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.CameraType;
using static Raylib_cs.CameraMode;
using static Raylib_cs.Color;
using static Raylib_cs.KeyboardKey;

namespace Examples
{
    public class core_3d_camera_first_person
    {
        public const int MAX_COLUMNS = 20;

        static Texture2D xhair = LoadTexture("./textures/xhair.png");
        

        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            const int screenWidth = 1600;
            const int screenHeight = 900;

            InitWindow(screenWidth , screenHeight , "raylib [core] example - 3d camera first person");
            Vector2 xhairpos = new Vector2(screenWidth / 2 -11 , screenHeight / 2 -10 );
            // Define the camera to look into our 3d world (position, target, up vector)
            Camera3D camera = new Camera3D();
            camera.position = new Vector3(4.0f , 2.0f , 4.0f);
            camera.target = new Vector3(0.0f , 1.8f , 0.0f);
            camera.up = new Vector3(0.0f , 8.0f , 0.0f);
            camera.fovy = 103.0f;
            camera.type = CAMERA_PERSPECTIVE;

            // Generates some random columns
            float[] heights = new float[MAX_COLUMNS];
            Vector3[] positions = new Vector3[MAX_COLUMNS];
            Color[] colors = new Color[MAX_COLUMNS];

            int jumpCd = 0;
            
            
            SetCameraMode(camera , CAMERA_FREE); // Set a first person camera mode

            SetTargetFPS(90);                           // Set our game to run at 60 frames-per-second
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!WindowShouldClose())                // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                UpdateCamera(ref camera);                  // Update camera
                //----------------------------------------------------------------------------------

                if (jumpCd == 0)
                {
                    if (IsKeyPressed(KEY_SPACE))
                    {

                    }
                }
                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();
                ClearBackground(RAYWHITE);

                BeginMode3D(camera);

                DrawPlane(new Vector3(0.0f , 0.0f , 0.0f) , new Vector2(32.0f , 32.0f) , DARKGRAY); // Draw ground
                DrawCube(new Vector3(-16.5f , 2.5f , 0.0f) , 1.0f , 5.0f , 32.0f , LIGHTGRAY);     // Draw a Color.blue wall
                DrawCubeWires(new Vector3(-16.5f , 2.5f , 0.0f) , 1.0f , 5.0f , 32.0f , BLACK);
                DrawCube(new Vector3(16.5f , 2.5f , 0.0f) , 1.0f , 5.0f , 32.0f , LIGHTGRAY);      // Draw a Color.green wall
                DrawCubeWires(new Vector3(16.5f , 2.5f , 0.0f) , 1.0f , 5.0f , 32.0f , BLACK);
                DrawCube(new Vector3(0.0f , 2.5f , 16.5f) , 32.0f , 5.0f , 1.0f , LIGHTGRAY);      // Draw a Color.yellow wall
                DrawCubeWires(new Vector3(0.0f , 2.5f , 16.5f) , 32.0f , 5.0f , 1.0f , BLACK);
                DrawCube(new Vector3(0.0f , 2.5f , -16.5f) , 32.0f , 5.0f , 1.0f , LIGHTGRAY);      // Draw a Color.yellow wall
                DrawCubeWires(new Vector3(0.0f , 2.5f , -16.5f) , 32.0f , 5.0f , 1.0f , BLACK);
                
                
                

                EndMode3D();

                DrawTextureEx(xhair , (xhairpos) , 0 , 1f , WHITE);

                //DrawLine(screenWidth , screenHeight / 2 , 0, screenHeight / 2, BLACK);    //centralisation lines
                //DrawLine(screenWidth / 2 , screenHeight , screenWidth / 2 , 0 , BLACK);   //centralisation lines

                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            CloseWindow();        // Close window and OpenGL context
            //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
using System.Collections.Generic;

namespace Assets.Puzzle.Scripts.Parameters
{
    public static class Constants
    {
        public class Camera
        {
            public static float RayCastLength = 10f;
        }

        public static Dictionary<string, int> DifficultyDictionary = new Dictionary<string, int> {
            { "Easy", 4 },
            { "Normal", 5 },
            { "Hard", 6 },
        };

        public static string PicturesPath = "EPictures";
        public static string GameOverText = "Your Time is";
        public static float PieceScale = 0.93f;
        public static float OverlapRayCastRange = 50f;
    }
}

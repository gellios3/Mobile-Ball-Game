namespace Services
{
    public class BallsStateService
    {
        public int HitBallsCount { get; set; }

        public int MissBallsCount { get; set; }

        public int StageCount { get; set; }

        public int CurrentStageBallsCount { get; set; }

        public int SpawnCount { get; set; }

        public bool HasPaused;
    }
}
namespace FormulaOne.Entities.DTOs.Requests
{
    public class UpdateDriverAchievementRequest
    {
        public Guid AchievementId { get; set; }
        public int WorldChampionship { get; set; }
        public int FastestLap { get; set; }
        public int PolePositions { get; set; }
        public int Wins { get; set; }
    }
}

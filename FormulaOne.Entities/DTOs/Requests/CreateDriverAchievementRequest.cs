﻿namespace FormulaOne.Entities.DTOs.Requests
{
    public class CreateDriverAchievementRequest
    {
        public Guid DriverId { get; set; }
        public int WorldChampionship { get; set; }
        public int FastestLap { get; set; }
        public int PolePositions { get; set; }
        public int Wins { get; set; }
    }
}

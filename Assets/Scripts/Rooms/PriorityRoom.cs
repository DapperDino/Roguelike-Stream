namespace Roguelike.Rooms
{
    public struct PriorityRoom
    {
        public Room Room { get; }
        public float MinRoomPercentageBeforeSpawn { get; }

        public PriorityRoom(Room room, float minRoomPercentageBeforeSpawn)
        {
            Room = room;
            MinRoomPercentageBeforeSpawn = minRoomPercentageBeforeSpawn;
        }
    }
}
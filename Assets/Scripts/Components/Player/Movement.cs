namespace ToughLife.Components.Player
{
    public class Movement
    {
        public float speed { get; set; }
        public bool rooted { get; set; }

        private ActiveStats ownerStats;

        public Movement(ActiveStats ownerStats)
        {
            this.ownerStats = ownerStats;
        }
    }
}
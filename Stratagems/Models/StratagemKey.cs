namespace Stratagems.Models
{
    public class StratagemKey
    {
        public enum Directions
        {
            Up,
            Down,
            Left,
            Right
        }

        public Directions Direction { get; init; }
        public bool IsHeld { get; private set; }

        #region Constructor
        public StratagemKey(Directions direction)
        {
            this.Direction = direction;
        }
        #endregion

        public void Set()
        {
            this.IsHeld = true;
        }

        public void Unset()
        {
            this.IsHeld = false;
        }
    }
}

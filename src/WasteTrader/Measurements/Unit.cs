namespace WasteTrader.Measurements
{
    public class Unit
    {
        public Unit(string Text, sbyte Offset)
        {
            this.Text = Text;
            this.Offset = Offset;
        }
        public string Text { get; }
        public sbyte Offset { get; }
    }
}

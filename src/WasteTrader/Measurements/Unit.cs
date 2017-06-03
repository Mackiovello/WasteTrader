namespace WasteTrader.Measurements
{
    public class Unit
    {
        public Unit(string Text, int Offset)
        {
            this.Text = Text;
            this.Offset = Offset;
        }
        public string Text { get; }
        public int Offset { get; }
    }
}

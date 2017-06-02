using WasteTrader.Api;

namespace WasteTrader
{
    class Program
    {
        static void Main()
        {
            //Db.Transact(() => 
            //{
            //    Db.SQL("SELECT w FROM WasteTrader.Database.Waste w WHERE w.Description=?", "Betong").First.Delete();
            //});

            var handlers = new IHandler[]
            {
                new MainHandlers(),
                new PartialHandlers(),
                new BlendingHandlers()
            };

            foreach (var handler in handlers)
            {
                handler.Register();
            }
        }
    }
}
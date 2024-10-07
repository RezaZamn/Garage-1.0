
namespace Garage_1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                UI uI = new UI();
                uI.StartProgram();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett oväntad fel inträffade: {ex.Message}");
            }


        }

    }
}

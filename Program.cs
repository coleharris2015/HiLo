using unit02_hilo;

namespace unit02_hilo
{
    class Program
	{
        ///Begins game
        static int Main(string[] args)
		{
            Director director = new Director();
            director.startGame();
            return 0;
        } 
	}
}
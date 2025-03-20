namespace MyFirstProject
{
    public class MenuSupport
    {
        public void MainMenu()
        {
            Console.WriteLine("MENU GŁÓWNE");
            Console.WriteLine("1 -> Oceń grę");
            Console.WriteLine("2 -> Wyświetl statystyki");
            Console.WriteLine("9 -> HELP");
            Console.WriteLine("Q -> Zakończ program");

        }

        public void GameList()
        {
            Console.WriteLine("1 -> Osadnicy Catanu");
            Console.WriteLine("2 -> Wsiąść do pociągu");
            Console.WriteLine("3 -> Potwory w Tokio");
            Console.WriteLine("4 -> Władca Pierścieni - Konfrontacja");
            Console.WriteLine("5 -> Dixit");
            Console.WriteLine("B -> powrót do głónego menu");
        }

        public void TopicOfReviewList()
        {
            Console.WriteLine("1 -> Regrywalność");
            Console.WriteLine("2 -> Aspekty techniczne");
            Console.WriteLine("3 -> Subiektywna odczucie radości z rozgrywki");
            Console.WriteLine("B -> powrót do głónego menu");
        }

        public void YesNoMethode()
        {
            Console.WriteLine("Y -> TAK");
            Console.WriteLine("N -> NIE (powrót do głównego menu)");
        }
    }
}

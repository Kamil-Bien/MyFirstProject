namespace MyFirstProject
{
    public class MenuSupport
    {
        public void PressEnterToStartProgram()
        {
            Console.WriteLine("WITAMY W PROGRAMIE DO OCENY GIER PLANSZOWYCH");
            Console.WriteLine();
            Console.WriteLine("Wciśnij ENTER aby kontynuować");
            Console.ReadLine();
        }

        public void MainMenu()
        {
            Console.WriteLine("MENU GŁÓWNE");
            Console.WriteLine("1 -> Oceń grę");
            Console.WriteLine("2 -> Wyświetl statystyki");
            Console.WriteLine("9 -> Info o programie");
            Console.WriteLine("Q -> Zakończ program");

        }

        public void GameList()
        {
            Console.WriteLine("1 -> Osadnicy Catanu");
            Console.WriteLine("2 -> Wsiąść do pociągu");
            Console.WriteLine("3 -> Potwory w Tokio");
            Console.WriteLine("4 -> Władca Pierścieni - Konfrontacja");
            Console.WriteLine("5 -> Dixit");
        }

        public void TopicOfReviewList()
        {
            Console.WriteLine("1 -> Regrywalność");
            Console.WriteLine("2 -> Aspekty techniczne");
            Console.WriteLine("3 -> Subiektywna odczucie radości z rozgrywki");
        }

        public void YesNoMethode()
        {
            Console.WriteLine("Y -> TAK");
            Console.WriteLine("N -> NIE (powrót do głównego menu)");
        }

        public void InfoOProgramie()
        {
            Console.WriteLine("Program ten pozwala na ocenę gry z poniższej listy:");
            GameList();
            Console.WriteLine();
            Console.WriteLine("Każdą z tych gier można ocenić w następujących kategoriach:");
            TopicOfReviewList();
            Console.WriteLine();
            Console.WriteLine("Ponadto program pozwala na wyświetlenie średniej ocen z każdej kategori");
            Console.WriteLine("a także wskazuje ogólną średnią ocenę gry wyliczaną na podstawie średnich wartości powyższych kategorii.");
            Console.WriteLine("Jeżeli dana gra nie będzie miała ocen w danej kategorii to progam wyliczy średnią na podstawie dostępnych ocen");
            Console.WriteLine();
            Console.WriteLine("Wciśnij ENTER aby kontynuować");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

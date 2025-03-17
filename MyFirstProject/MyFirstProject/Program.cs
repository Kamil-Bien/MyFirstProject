using MyFirstProject;
void EmployeeGradeAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano nową ocenę");
}
MenuSupport MenuSupport = new MenuSupport();
//tworzenie nowych obiektów (pracowników) korzystając z klasy Employee
var BoardGame0 = new BoardGame("Osadnicy Catanu");
var BoardGame1 = new BoardGame("Wsiąść do pociągu");
var BoardGame2 = new BoardGame("Potwory w Tokio");
var BoardGame3 = new BoardGame("Władca Pierścieni - Konfrontacja");
var BoardGame4 = new BoardGame("Dixit");

//worker1.GradeAdded += EmployeeGradeAdded;

List<BoardGame> GamesList = new List<BoardGame>();

GamesList.Add(BoardGame0);
GamesList.Add(BoardGame1);
GamesList.Add(BoardGame2);
GamesList.Add(BoardGame3);
GamesList.Add(BoardGame4);


List<string> TopicsOfRevievList = new List<string>();

TopicsOfRevievList.Add("Replayability");
TopicsOfRevievList.Add("TechnicalMatters");
TopicsOfRevievList.Add("SubjectiveFun");


Console.WriteLine("(Jeżeli chcesz odrazu zakończyć wciśnij Q a następnie ENTER)");
while (true)
{
    Console.WriteLine("METODA MENU");
    var input = Console.ReadLine();

    if ((input == "q") || (input == "Q"))
    {
        break;
    }


    switch (input)
    {
        //Opcja 1 - Ocena wybranej gry
        case var x when x == "1":


            while (input != "b" && input != "B")
            {
                Console.WriteLine("Wybierz gre którą chcesz ocenić");
                Console.WriteLine("METODA LISTA GIER");

                input = Console.ReadLine();


                if (int.TryParse(input, out int selectedGameNumber))
                {
                    selectedGameNumber--; // ze względu na różnice w wyborze z zakresu od 1, a indeksowością listy
                    if (selectedGameNumber >= 0 && selectedGameNumber <= GamesList.Count)
                    {
                        while (input != "b" && input != "B")
                        {

                            Console.WriteLine("Wybierz kategorię oceny");
                            Console.WriteLine("METODA LISTA KATEGORII");
                            input = Console.ReadLine();
                            var AddPiontsFlag = true;


                            switch (input)
                            {
                                case var y when y == "X" || y == "x":
                                    GamesList[selectedGameNumber].FileSelection("Replayability");
                                    break;

                                case var y when y == "Y" || y == "y":
                                    GamesList[selectedGameNumber].FileSelection("TechnicalMatters");
                                    break;

                                case var y when y == "Z" || y == "z":
                                    GamesList[selectedGameNumber].FileSelection("SubjectiveFun");
                                    break;

                                default:
                                    AddPiontsFlag = false;
                                    break;
                            }

                            if (AddPiontsFlag)
                            {
                                do
                                {
                                    Console.WriteLine("Podaj ocenę mieszczącą się w zakresie od 1 do 10 ((B) - powrót do głównego MENU)");
                                    input = Console.ReadLine();

                                    if (input != "b" && input != "B")
                                    {
                                        try
                                        {
                                            GamesList[selectedGameNumber].AddReviewPoints(input);
                                            input = "B";
                                            break;
                                        }
                                        catch (Exception toJestTymczasowaZmienna)
                                        {
                                            Console.WriteLine($"Wykryto wyjątek: {toJestTymczasowaZmienna.Message}");
                                            Console.WriteLine("Spróbój ponownie");
                                            Console.WriteLine();
                                        }
                                    }

                                } while (input != "b" && input != "B");
                            }
                            else if ((input == "b") || (input == "B"))
                            {
                                //do nothing, nastąpi wyjście z pętli while
                            }
                            else
                            {
                                Console.WriteLine("Wybrana przez Ciebie opcja nie istnieje lub jest nie dostępna. Spróbuj wybrać opcje z podanej listy");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Próba wybrania gry z poza listy");
                        Console.WriteLine("Spróbuj ponownie");
                        Console.WriteLine();
                    }
                }
                else if((input == "b") || (input == "B"))
                {
                    //do nothing, nastąpi wyjście z pętli while
                }
                else
                {
                    Console.WriteLine("Błąd rzutowania zmiennej. Wprowadzone dane muszą być liczbą całkowitą");
                    Console.WriteLine("Spróbuj ponownie wg poniższej instrukcji");
                }

            }

            break;

        case var x when x == "2":
            ///////////////////////////////////////////////////////////////////////////opcja 2 - statystyki dla wybranej gry
            break;
        
        default:
            break;



    }
}


try
{
    var statistics = BoardGame1.GetStatistics();
    Console.WriteLine();
    Console.WriteLine($"Średnia wartość ocen tego pracownika wynosi {statistics.Average:N2}pkt");
}
catch (Exception toJestTymczasowaZmienna)
{
    Console.WriteLine($"Wykryto wyjątek: {toJestTymczasowaZmienna.Message}");
}
Console.WriteLine();
Console.WriteLine("DZIĘKUJEMY ZA SKORZYSTANIE Z NASZEGO PROGRAMU");


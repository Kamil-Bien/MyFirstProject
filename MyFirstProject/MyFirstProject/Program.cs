using MyFirstProject;
void EmployeeGradeAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano nową ocenę");
}
MenuSupport MenuSupport = new MenuSupport();

var BoardGame0 = new BoardGame("Osadnicy Catanu");
var BoardGame1 = new BoardGame("Wsiąść do pociągu");
var BoardGame2 = new BoardGame("Potwory w Tokio");
var BoardGame3 = new BoardGame("Władca Pierścieni - Konfrontacja");
var BoardGame4 = new BoardGame("Dixit");

List<BoardGame> GamesList = new List<BoardGame>();
//Lista Gier do oceny
GamesList.Add(BoardGame0);
GamesList.Add(BoardGame1);
GamesList.Add(BoardGame2);
GamesList.Add(BoardGame3);
GamesList.Add(BoardGame4);


List<string> TopicsOfRevievList = new List<string>();
//Lista ocenianych aspektów
TopicsOfRevievList.Add("Replayability");
TopicsOfRevievList.Add("TechnicalMatters");
TopicsOfRevievList.Add("SubjectiveFun");


Console.WriteLine("(Jeżeli chcesz odrazu zakończyć wciśnij Q a następnie ENTER)");
while (true) //pętla głównego menu
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


            while (input != "b" && input != "B") //pętla wyboru gry z listy
            {
                Console.WriteLine("Wybierz gre którą chcesz ocenić");
                Console.WriteLine("METODA LISTA GIER");

                input = Console.ReadLine();


                if (int.TryParse(input, out int selectedGameNumber))
                {
                    selectedGameNumber--; // ze względu na różnice w wyborze z zakresu od 1, a indeksowością listy(od 0)
                    if (selectedGameNumber >= 0 && selectedGameNumber < GamesList.Count)
                    {
                        while (input != "b" && input != "B") // pętla wybrou ocenianej kategorii
                        {

                            Console.WriteLine("Wybierz kategorię oceny");
                            Console.WriteLine("METODA LISTA KATEGORII");
                            input = Console.ReadLine();
                            //var AddPiontsFlag = true;

                            if (int.TryParse(input, out int selectedTopicOfReview))
                            {
                                selectedTopicOfReview--; // ze względu na różnice w wyborze z zakresu od 1, a indeksowością listy(od 0)
                                if (selectedTopicOfReview >= 0 && selectedTopicOfReview <= TopicsOfRevievList.Count)
                                {
                                    GamesList[selectedGameNumber].FileSelection(TopicsOfRevievList[selectedTopicOfReview]);
                                    do //pętla dodania oceny do wybranej wcześniej gry i kategorii
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
            while (input != "b" && input != "B") //pętla wyboru gry z listy
            {
                Console.WriteLine("Wybierz gre dla której chcesz wyświetlić statystyki");
                Console.WriteLine("METODA LISTA GIER");

                input = Console.ReadLine();

                if (int.TryParse(input, out int selectedGameNumber))
                {
                    selectedGameNumber--; // ze względu na różnice w wyborze z zakresu od 1, a indeksowością listy(od 0)
                    if (selectedGameNumber >= 0 && selectedGameNumber < GamesList.Count)
                    {
                        float FinalStatisticalSummary = 0;
                        int CounterForSucessGettingStatistics = 0;
                        foreach (var TopicOfReviev in TopicsOfRevievList)
                        {
                            GamesList[selectedGameNumber].FileSelection(TopicOfReviev);
                            
                            try
                            {
                                var statistics = GamesList[selectedGameNumber].GetStatistics();
                                Console.WriteLine();
                                Console.WriteLine($"Średnia wartość ocen dla gry: {GamesList[selectedGameNumber].BoardGameName} w kategorii {TopicOfReviev} wynosi {statistics.Average:N2}pkt");
                                FinalStatisticalSummary += statistics.Average;
                                CounterForSucessGettingStatistics++;
                            }
                            catch (Exception toJestTymczasowaZmienna)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Wykryto wyjątek dla {GamesList[selectedGameNumber].BoardGameName} w kategorii {TopicOfReviev} : {toJestTymczasowaZmienna.Message}");
                            }
                                                        
                        }

                        if (CounterForSucessGettingStatistics > 0)
                        {
                            var FinalAverage = FinalStatisticalSummary / CounterForSucessGettingStatistics;
                            Console.WriteLine($"Średnia wartość ocey końcowej dla gry: {GamesList[selectedGameNumber].BoardGameName} wynosi {FinalAverage:N2}pkt");
                        }
                        else if (CounterForSucessGettingStatistics == 0)
                        {
                            Console.WriteLine("Niestety wskazana gra nie posiada jeszcze żadnych ocen");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Próba wybrania gry z poza listy");
                        Console.WriteLine("Spróbuj ponownie");
                        Console.WriteLine();
                    }
                }
                else if ((input == "b") || (input == "B"))
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


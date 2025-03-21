using System;
using MyFirstProject;
void ReviewAdded(object sender, EventArgs args)
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


foreach (var Game in GamesList)// dodanie eventu do każdego obiektu z listy
{
    Game.ReviewAdded += EventReviewMethode;
}

void EventReviewMethode(object sender, EventArgs args)
{
    Console.Clear();
    Console.WriteLine("Ocena została dodana prawidłowo");
    Console.WriteLine("powrót do głównego MENU");
    Console.WriteLine();
}

List<string> TopicsOfRevievList = new List<string>();
//Lista ocenianych aspektów
TopicsOfRevievList.Add("Replayability");
TopicsOfRevievList.Add("TechnicalMatters");
TopicsOfRevievList.Add("SubjectiveFun");

Console.Clear();
MenuSupport.PressEnterToStartProgram();

Console.Clear();
while (true) //pętla głównego menu
{
    MenuSupport.MainMenu();
    var input = Console.ReadLine();

    if ((input == "q") || (input == "Q"))
    {
        break;
    }


    switch (input)
    {
        //Opcja 1 - Ocena wybranej gry
        case var x when x == "1":

            Console.Clear();
            while (input != "b" && input != "B") //pętla wyboru gry z listy
            {
                Console.WriteLine("Wybierz gre którą chcesz ocenić");
                MenuSupport.GameList();
                Console.WriteLine("B -> powrót do głónego menu");

                input = Console.ReadLine();


                if (int.TryParse(input, out int selectedGameNumber))
                {
                    selectedGameNumber--; // ze względu na różnice w wyborze z zakresu od 1, a indeksowością listy(od 0)
                    if (selectedGameNumber >= 0 && selectedGameNumber < GamesList.Count)
                    {
                        Console.Clear();
                        while (input != "b" && input != "B") // pętla wybrou ocenianej kategorii
                        {
                            Console.WriteLine("Wybierz kategorię oceny");
                            MenuSupport.TopicOfReviewList();
                            Console.WriteLine("B -> powrót do głónego menu");
                            input = Console.ReadLine();
                            //var AddPiontsFlag = true;

                            if (int.TryParse(input, out int selectedTopicOfReview))
                            {
                                selectedTopicOfReview--; // ze względu na różnice w wyborze z zakresu od 1, a indeksowością listy(od 0)
                                if (selectedTopicOfReview >= 0 && selectedTopicOfReview < TopicsOfRevievList.Count)
                                {
                                    Console.Clear();
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
                                                Console.Clear();
                                                Console.WriteLine($"Wykryto wyjątek: {toJestTymczasowaZmienna.Message}");
                                                Console.WriteLine("Spróbuj ponownie");
                                                Console.WriteLine();
                                            }
                                        }

                                    } while (input != "b" && input != "B");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Wybrana przez Ciebie opcja nie istnieje lub jest nie dostępna. Spróbuj wybrać opcje z podanej listy");
                                    Console.WriteLine();
                                }
                            }
                            else if ((input == "b") || (input == "B"))
                            {
                                Console.Clear();
                                //do nothing, nastąpi wyjście z pętli while
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Wybrana przez Ciebie opcja nie istnieje lub jest nie dostępna. Spróbuj wybrać opcje z podanej listy");
                                Console.WriteLine();
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Próba wybrania gry z poza listy");
                        Console.WriteLine("Spróbuj ponownie");
                        Console.WriteLine();
                    }
                }
                else if((input == "b") || (input == "B"))
                {
                    Console.Clear();
                    //do nothing, nastąpi wyjście z pętli while
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Błąd rzutowania zmiennej. Wprowadzone dane muszą być liczbą całkowitą");
                    Console.WriteLine("Spróbuj ponownie wg poniższej instrukcji");
                    Console.WriteLine();
                }

            }

            break;

        case var x when x == "2":
            Console.Clear();
            ///////////////////////////////////////////////////////////////////////////opcja 2 - statystyki dla wybranej gry
            while (input != "b" && input != "B") //pętla wyboru gry z listy
            {
                Console.WriteLine("Wybierz gre dla której chcesz wyświetlić statystyki");
                MenuSupport.GameList();
                Console.WriteLine("B -> powrót do głónego menu");

                input = Console.ReadLine();

                if (int.TryParse(input, out int selectedGameNumber))
                {
                    selectedGameNumber--; // ze względu na różnice w wyborze z zakresu od 1, a indeksowością listy(od 0)
                    if (selectedGameNumber >= 0 && selectedGameNumber < GamesList.Count)
                    {
                        float FinalStatisticalSummary = 0;
                        int CounterForSucessGettingStatistics = 0;
                        bool ReapetFlag = true;
                        

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
                            Console.WriteLine();
                            Console.WriteLine($"Średnia wartość ocey końcowej dla gry: {GamesList[selectedGameNumber].BoardGameName} wynosi {FinalAverage:N2}pkt");
                            
                        }
                        else if (CounterForSucessGettingStatistics == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Niestety wskazana gra nie posiada jeszcze żadnych ocen");
                        }

                        while (ReapetFlag) //pętla pytania o ponowny wybór gry do wyświetlenia statystyk (lub powrót do MENU)
                        {
                            Console.WriteLine("Czy chcesz ponownie wybrać grę w celu wyświetlenia jej statystyk?");
                            MenuSupport.YesNoMethode();
                            input = Console.ReadLine();
                            if (input != "y" && input != "Y" && input != "n" && input != "N")
                            {
                                Console.Clear();
                                Console.WriteLine("Podano nie poprawną opcję");
                            }
                            else if (input == "n" || input == "N")
                            {
                                input = "B";
                                ReapetFlag = false;
                            }
                            else
                            {
                                ReapetFlag = false;
                            }
                        }
                        Console.Clear();


                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Próba wybrania gry z poza listy");
                        Console.WriteLine("Spróbuj ponownie");
                        Console.WriteLine();
                    }
                }
                else if ((input == "b") || (input == "B"))
                {
                    Console.Clear();
                    //do nothing, nastąpi wyjście z pętli while
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Błąd rzutowania zmiennej. Wprowadzone dane muszą być liczbą całkowitą");
                    Console.WriteLine("Spróbuj ponownie wg poniższej instrukcji");
                }
            }
                break;

        case var x when x == "9":
            MenuSupport.InfoOProgramie();
            break;


        default:
            Console.Clear();
            Console.WriteLine($"Wprowadzono złe dane, brak dostępnej opcji: {input}");
            Console.WriteLine("Spróbuj ponownie wg poniższej instrukcji");
            Console.WriteLine();
            break;
    }
}



Console.Clear();
Console.WriteLine("DZIĘKUJEMY ZA SKORZYSTANIE Z NASZEGO PROGRAMU");


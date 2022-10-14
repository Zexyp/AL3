using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListDiary
{
    class ConsoleDiaryDriver
    {
        public void Start(Diary diary)
        {
            while (true)
            {
                if (diary.CurrentPage != null)
                {
                    Console.WriteLine(new string('-', 32));
                    Console.WriteLine($"Datum: {diary.CurrentPage.Date}");
                    Console.WriteLine($"Text:\n{diary.CurrentPage.Text}");
                    Console.WriteLine(new string('-', 32));
                }
                Console.Write("> ");
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "predchozi":
                        if (!diary.Previous())
                            Console.WriteLine("Nelze");
                        break;
                    case "dalsi":
                        if (!diary.Next())
                            Console.WriteLine("Nelze");
                        break;
                    case "novy":
                        DateTime? date = null;
                        while (true)
                        {
                            Console.Write("Datum: ");
                            string datestr = Console.ReadLine();
                            if (datestr == "")
                                break;
                            if (DateTime.TryParse(datestr, out var founddate))
                            {
                                date = founddate;
                                break;
                            }
                        }

                        date = date ?? DateTime.Now;

                        Console.WriteLine("Text:");
                        StringBuilder sb = new StringBuilder();
                        while (true)
                        {
                            string line = Console.ReadLine();
                            if (line == "uloz")
                                break;
                            sb.Append(line + "\n");
                        }
                        Console.WriteLine("Konec");

                        diary.AddPage(new DiaryPage((DateTime)date, sb.ToString()));
                        Console.WriteLine("Přidáno");
                        break;
                    case "smaz":
                        diary.DropPage();
                        Console.WriteLine("Smazáno");
                        break;
                    case "zavri":
                        Console.WriteLine("Zavřeno");
                        return;
                    case "pomoc":
                        Console.WriteLine(
                            "predchozi - předchozí záznam\n" +
                            "dalsi     - nasledující záznam\n" +
                            "novy      - vytvoří nový záznam v deníku\n" +
                            "uloz      - ukončí zápis do deníku\n" +
                            "smaz      - smaže záznam z deníku\n" +
                            "zavri     - ukončí deník");
                        break;
                    default:
                        Console.WriteLine("Neznámý příkaz. (použij 'pomoc' pro zobrazení dostupných příkazů)");
                        break;
                }
            }
        }
    }
}

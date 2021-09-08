using System;
using System.Collections.Generic;

namespace Intensive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Доброе время суток!");
            Console.WriteLine("Для дальнейшей работы введите ссылку на web-страницу");
            Program prog = new Program();
            prog.Begining();            
            Console.ReadKey();
        }
        void Begining()
        {
            string uRi = Console.ReadLine();
            Dictionary<string, int> DATA;
            Save_html_page project = new Save_html_page(uRi);
            project.Get_data_from_HTML_page();
            Working_with_save_html_file project_ = new Working_with_save_html_file();
            DATA = project_.count_unique_words();
            project_.output(DATA);
            DateBase date = new DateBase(uRi, DATA);
            date.main();
        }
    }
}

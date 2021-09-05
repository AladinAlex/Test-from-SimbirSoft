using System;

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
            Save_html_page project = new Save_html_page();
            project.Get_data_from_HTML_page();
            Working_with_save_html_file project_ = new Working_with_save_html_file();
            project_.count_unique_words();
        }
    }
}

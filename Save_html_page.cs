using System;
using System.Net;

namespace Intensive
{
    class Save_html_page
    {
        public string urI;

        public Save_html_page()
        { 
            
        }
        public Save_html_page(string URI)
        {
            urI = URI;
        }

        string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\download_html_file.html";// { get; set; }
        public string Desktop_path
        {
            get { return desktop_path; }
        }
        public Uri uri;
        internal void Get_data_from_HTML_page()
        {
            WebClient client = new WebClient();         
            try
            {
                uri = new Uri(urI);
                Console.WriteLine("Проверяется URI-адрес");
                client.DownloadFile(uri, desktop_path);
                Console.WriteLine("URI-адрес верный");
                Console.WriteLine("Файл скачан на рабочий стол");
            }
            catch (UriFormatException)
            {
                Console.WriteLine("Введен не верный URI, нажмите любую кнопку, чтобы выйти из программы");
                Console.ReadKey();
                Environment.Exit(1);
            }
            catch (WebException)
            {
                Console.WriteLine("Отсутствует подключение к интернету, либо такого URI не существует, нажмите любую кнопку, чтобы выйти из программы");
                Console.ReadKey();
                Environment.Exit(1);
            }            
        }
    }
}

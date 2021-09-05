using System;
using System.Net;

namespace Intensive
{
    class Save_html_page // сделать проверку URL, если верно, то вывод в консоль
    {
        string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\download_html_file.html";// { get; set; }
        public string Desktop_path
        {
            get { return desktop_path; }
        }
        string Input_link_HTML_page() // метод получения web-страницы от пользователя
        {
            return Console.ReadLine();
        }
        internal void Get_data_from_HTML_page() // скачивание html-страницы на рабочий стол компьютера
        {
            WebClient client = new WebClient();
            Uri uri;
            try
            {
                Console.WriteLine("Проверяется URI-адрес");
                uri = new Uri(Input_link_HTML_page());                              
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

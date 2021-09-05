using System;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;

namespace Intensive
{
    class Working_with_save_html_file // https://www.simbirsoft.com/
    {
        string k;
        void delete_html_code()
        {
                Save_html_page auxiliary = new Save_html_page();
                StreamReader html_file = new StreamReader(auxiliary.Desktop_path);
                k = html_file.ReadToEnd();
                HtmlNode node = HtmlNode.CreateNode(k);
                if (node != null)
                    k = node.InnerText;
                else
                {
                    Console.WriteLine("HTML файл пустой, нажмите любую кнопку, чтобы выйти из программы");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
        }
        string[] delete_char_and_sort(string k)
        {
            string[] mas = k.Split(new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(mas);
            return mas;
        }
        internal void count_unique_words()
        {
            delete_html_code();
            Dictionary<string, int> result = new Dictionary<string, int>();
            string[] result_mas = delete_char_and_sort(k);
            result.Add(result_mas[0], 1);

            for (int i = 1; i < result_mas.Length; i++)
            {
                if (result_mas[i] != result_mas[i - 1])
                    result.Add(result_mas[i], 1);
                else {
                    int value = 0;
                    result.TryGetValue(result_mas[i], out value);
                    result[result_mas[i]] = value + 1; }
            }
            output(result);
        }
        void output(Dictionary<string, int> result)
        {
            foreach (var a in result)
                Console.WriteLine("{0} - {1}", a.Key, a.Value);
        }
    }
}

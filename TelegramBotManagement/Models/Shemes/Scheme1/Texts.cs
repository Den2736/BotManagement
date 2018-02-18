using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Models.Shemes.Scheme1
{
    public class Texts : TextsBase
    {
        public Texts(string filePath)
        {
            FilePath = filePath;
            Lamagna = new Lamagna();
            Trippier = new Trippier();
            MainProduct = new MainProduct();
            Other = new Other();
            var path = Directory.GetCurrentDirectory() + "\\" + FilePath;
            if (!File.Exists(path))
            {
                Store();
            }
            else
            {
                Load();
            }
        }

        protected override string FilePath { get; set; }
        [DisplayName("Лидмагнит")] public Lamagna Lamagna { get; set; }
        [DisplayName("Трипвайер")] public Trippier Trippier { get; set; }
        [DisplayName("Гланвый продукт")] public MainProduct MainProduct { get; set; }
        [DisplayName("Другое")] public Other Other { get; set; }
    }

    [DisplayName("Другое")]
    public class Other
    {
        [DisplayName("Положительный ответ")] public string Positive { get; set; } = "Положительный ответ";
        [DisplayName("Отрицательный ответ")] public string Negative { get; set; } = "Отрицательный ответ";
        [DisplayName("Контакты")] public string Contacts { get; set; } = "Контакты";
    }

    [DisplayName("Лидмагнит")]
    public class Lamagna
    {
        [DisplayName("Приветствие")] public string Greeting { get; set; } = "Приветствие";
        [DisplayName("Текст 1")] public string Text1 { get; set; } = "Текст 1";
        [DisplayName("Текст 2")] public string Text2 { get; set; } = "Текст 2";
        [DisplayName("Текст 3")] public string Text3 { get; set; } = "Текст 3";
        [DisplayName("Текст 4")] public string Text4 { get; set; } = "Текст 4";

        [DisplayName("Кнопка 1")] public string Button1 { get; set; } = "Кнопка 1";
        [DisplayName("Кнопка 2")] public string Button2 { get; set; } = "Кнопка 2";
        [DisplayName("Кнопка 3")] public string Button3 { get; set; } = "Кнопка 3";
    }

    [DisplayName("Трипвайер")]
    public class Trippier
    {
        [DisplayName("Текст 1")] public string Text1 { get; set; } = "Текст 1";
        [DisplayName("Текст 2")] public string Text2 { get; set; } = "Текст 2";
        [DisplayName("Текст 3")] public string Text3 { get; set; } = "Текст 3";

        [DisplayName("Кнопка 1")] public string Button1 { get; set; } = "Кнопка 1";
    }

    [DisplayName("Гланвый продукт")]
    public class MainProduct
    {
        [DisplayName("Текст 1")] public string Text1 { get; set; } = "Текст 1";
        [DisplayName("Кнопка 1")] public string Button1 { get; set; } = "Кнопка 1";
        [DisplayName("Кнопка 2")] public string Button2 { get; set; } = "Кнопка 2";
    }
}

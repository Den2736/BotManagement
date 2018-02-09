using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Models.Shemes.Register
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
            Load();
        }

        protected override string FilePath { get; set; }
        public Lamagna Lamagna { get; set; }
        public Trippier Trippier { get; set; }
        public MainProduct MainProduct { get; set; }
        public Other Other { get; set; }
    }

    [DisplayName("Другое")]
    public class Other
    {
        [DisplayName("Положительный ответ")] public string Positive { get; set; }
        [DisplayName("Отрицательный ответ")] public string Negative { get; set; }
        [DisplayName("Контакты")] public string Contacts { get; set; }
    }

    [DisplayName("Лидмагнит")]
    public class Lamagna
    {
        [DisplayName("Приветствие")] public string Greeting { get; set; }
        [DisplayName("Текст 1")] public string Text1 { get; set; }
        [DisplayName("Текст 2")] public string Text2 { get; set; }
        [DisplayName("Текст 3")] public string Text3 { get; set; }
        [DisplayName("Текст 4")] public string Text4 { get; set; }

        [DisplayName("Кнопка 1")] public string Button1 { get; set; }
        [DisplayName("Кнопка 2")] public string Button2 { get; set; }
        [DisplayName("Кнопка 3")] public string Button3 { get; set; }
    }

    [DisplayName("Трипвайер")]
    public class Trippier
    {
        [DisplayName("Текст 1")] public string Text1 { get; set; }
        [DisplayName("Текст 2")] public string Text2 { get; set; }
        [DisplayName("Текст 3")] public string Text3 { get; set; }

        [DisplayName("Кнопка 1")] public string Button1 { get; set; }
    }

    [DisplayName("Гланвый продукт")]
    public class MainProduct
    {
        [DisplayName("Текст 1")] public string Text1 { get; set; }
        [DisplayName("Кнопка 1")] public string Button1 { get; set; }
        [DisplayName("Кнопка 2")] public string Button2 { get; set; }
    }
}

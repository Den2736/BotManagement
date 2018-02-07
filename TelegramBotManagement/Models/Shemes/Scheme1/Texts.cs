using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Models.Shemes.Text1
{
    public class Texts : TextsBase
    {
        public override string FileName { get; set; }
        public Lamagna Lamagna { get; set; }
        public Trippier Trippier { get; set; }
        public MainProduct MainProduct { get; set; }
        public Other Other { get; set; }
    }

    public class Other
    {
        [DisplayName("Положительный ответ")] public string Positive { get; set; }
        [DisplayName("Отрицательный ответ")] public string Negative { get; set; }
        [DisplayName("Контакты")] public string Contacts { get; set; }
    }

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

    public class Trippier
    {
        [DisplayName("Текст 1")] public string Text1 { get; set; }
        [DisplayName("Текст 2")] public string Text2 { get; set; }
        [DisplayName("Текст 3")] public string Text3 { get; set; }

        [DisplayName("Кнопка 1")] public string Button1 { get; set; }
    }

    public class MainProduct
    {
        [DisplayName("Текст 1")] public string Text1 { get; set; }
        [DisplayName("Кнопка 1")] public string Button1 { get; set; }
        [DisplayName("Кнопка 2")] public string Button2 { get; set; }
    }
}

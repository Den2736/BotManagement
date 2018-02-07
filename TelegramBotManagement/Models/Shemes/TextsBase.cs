using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TelegramBotManagement.Models.Shemes
{
    public enum Block
    {
        Lamagna,
        Trippier,
        MainProduct,
        Other
    }

    public interface ITexts
    {
        void Update(Block? block, string fieldDisplayName, string newText);

        void Load();

        string GetText(Block? block, string fieldDisplayName);

        PropertyInfo GetFieldInfo(object blockObj, string fieldDisplayName);
    }

    public abstract class TextsBase: ITexts
    {
        public abstract string FileName { get; set; }

        public string BackButton = $"{Emoji.Back} Назад";
        public string ToStartButton = $"{Emoji.Top} К началу";

        public void Load()
        {
            var file = XDocument.Load(FileName);
            var root = file.Element("Root");

            foreach (var prop in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!Enum.GetNames(typeof(Block)).Contains(prop.Name))
                {
                    var value = root.Element(prop.Name)?.Value;

                    if (value != null)
                    {
                        prop.SetValue(this, value);
                    }
                }
                else
                {
                    var blockElement = root.Element(prop.Name);
                    var blockName = blockElement?.Name.ToString();
                    if (blockName != null)
                    {
                        var block = prop.GetValue(this);
                        foreach (var blockProp in block.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            var value = blockElement.Element(blockProp.Name)?.Value;

                            if (value != null)
                            {
                                blockProp.SetValue(block, value);
                            }
                        }
                    }
                }
            }
        }

        public void Update(Block? block, string fieldDisplayName, string newText)
        {
            // update data in RAM
            PropertyInfo prop = null;
            object blockObj = null;
            if (block != null)
            {
                var blockProp = GetType().GetProperty(block.ToString());
                if (blockProp != null)
                {
                    blockObj = blockProp.GetValue(this);
                    if (blockObj != null)
                    {
                        prop = GetFieldInfo(blockObj, fieldDisplayName);
                        if (prop != null)
                        {
                            prop.SetValue(blockObj, newText);
                        }
                    }
                }
            }
            else
            {
                prop = prop = GetFieldInfo(null, fieldDisplayName); ;
                if (prop != null)
                {
                    prop.SetValue(this, newText);
                }
            }

            // save changes
            var file = XDocument.Load(FileName);
            var root = file.Element("Root");
            if (!string.IsNullOrEmpty(block.ToString()))
            {
                var Xblock = root.Element(block.ToString());
                if (Xblock != null)
                {
                    var text = Xblock.Element(prop.Name);
                    if (text != null)
                    {
                        text.Remove();
                        Xblock.Add(new XElement(prop.Name, prop.GetValue(blockObj)));
                    }
                }
            }
            else
            {
                var text = root.Element(prop.Name);
                if (text != null)
                {
                    text.Remove();
                    root.Add(new XElement(prop.Name, prop.GetValue(this)));
                }
            }

            file.Save(FileName);
        }

        public string GetText(Block? block, string fieldDisplayName)
        {
            PropertyInfo prop = null;
            object blockObj = null;
            if (block != null)
            {
                var blockProp = GetType().GetProperty(block.ToString());
                if (blockProp != null)
                {
                    blockObj = blockProp.GetValue(this);
                    if (blockObj != null)
                    {
                        prop = GetFieldInfo(blockObj, fieldDisplayName);
                        if (prop != null)
                        {
                            return prop.GetValue(blockObj).ToString();
                        }
                    }
                }
            }
            else
            {
                prop = prop = GetFieldInfo(null, fieldDisplayName); ;
                if (prop != null)
                {
                    return prop.GetValue(this).ToString();
                }
            }

            return "";
        }

        public PropertyInfo GetFieldInfo(object blockObj, string fieldDisplayName)
        {
            if (blockObj != null)
            {
                foreach (var prop in blockObj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    DisplayNameAttribute attr = (DisplayNameAttribute)prop.GetCustomAttribute(typeof(DisplayNameAttribute));
                    if (attr != null && attr.DisplayName == fieldDisplayName)
                    {
                        return prop;
                    }
                }
            }
            else
            {
                foreach (var prop in GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    DisplayNameAttribute attr = (DisplayNameAttribute)prop.GetCustomAttribute(typeof(DisplayNameAttribute));
                    if (attr != null && attr.DisplayName == fieldDisplayName)
                    {
                        return prop;
                    }
                }
            }

            return null;
        }

        public PersonalAccount PersonalAccount { get; set; }

        /// TODO public void Store(){}
    }

    public class PersonalAccount
    {
        public string PersonalAccountButton = $"{Emoji.Door} Личный кабинет";

        public string PersnonalAccountGreeting(string name) => $"Добро пожаловать, {name}! {Emoji.EyeHearts}";
        public string StatisticsButton = $"{Emoji.Graphic} Статистика";
        public string TextsEditingButton = $"{Emoji.TextEdit} Настройка текстов";

        public string ChooseStatistics = $"Что хотите посмотреть? {Emoji.Eyes}";
        public string AllUsersButton = "Кто писал боту?";
        public string LamagnaPassedUsersButton = "Кто прошёл Лидмагнит?";
        public string TrippierPassedUsersButton = "Кто прошёл Трипвайер?";
        public string MainProductPassedUsersButton = $"{Emoji.MoneyWithWings} Кто купил главный продукт?";

        public string ChooseBlock = $"{Emoji.Block} Выберите блок";
        public string ChooseText = $"{Emoji.Text} Какой текст вы хотите изменить?";

        public string YouWantToChange = "Вы хотите поменять";
        public string EnterNewText = "Пришлите мне новый текст";
        public string NewTextSaved = $"{Emoji.Success} Отлично! Новый текст сохранён!";
    }
}

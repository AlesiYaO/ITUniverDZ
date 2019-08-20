using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication2Library
{
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Группа, к которой относится пользователь
        /// </summary>
        public string Group { get; set; }
    }

    public class Document
    {
        /// <summary>
        /// Тип документа
        /// </summary>
        public char TypeDocument { get; set; }

        /// <summary>
        /// Дата создания документа
        /// </summary>
        public DateTime DateCreature { get; set; }

        /// <summary>
        /// Автор документа
        /// </summary>
        public string Author { get; set; }
    }

    public class PravoDostupaKPapke
    {
        /// <summary>
        /// Ссылка на Папку
        /// </summary>
        public int Papka { get; set; }

        /// <summary>
        /// Уровень доступа к данной папке
        /// </summary>
        public string UrovenDostupa { get; set; }

        /// <summary>
        /// Ссылка на Группу пользователей 
        /// </summary>
        public int GroupUsers { get; set; }

        /// <summary>
        /// Ссылка на Пользователя
        /// </summary>
        public int User { get; set; }
    }

    public class Papka
    {
        /// <summary>
        /// Идентификатор папки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя папки(название)
        /// </summary>
        public string Name { get; set; }

    }

    public class VersionDocument
    {
        /// <summary>
        /// Идентификатор версии документа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Файл
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Автор версии
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreature { get; set; }

        /// <summary>
        /// Ссылка на документ
        /// </summary>
        public int Document { get; set; }
    }

    public class GroupUsers
    {
        /// <summary>
        /// Идентификатор группы пользователей
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название группы
        /// </summary>
        public string Name { get; set; }
    }
}

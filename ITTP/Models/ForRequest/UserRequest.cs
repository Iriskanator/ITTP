using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace ITTP.Models.FromBody
{
    public class UserRequest
    {
        /// <summary>
        /// Уникальный Логин (запрещены все символы кроме латинских букв и цифр)
        /// </summary>
        [Required]
        [DisplayName("Уникальный Логин (запрещены все символы кроме латинских букв и цифр)")]
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Пароль(запрещены все символы кроме латинских букв и цифр)
        /// </summary>
        [Required]
        [DisplayName("Пароль(запрещены все символы кроме латинских букв и цифр)")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Имя (запрещены все символы кроме латинских и русских букв)
        /// </summary>
        [Required]
        [DisplayName("Имя (запрещены все символы кроме латинских и русских букв)")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Пол 0 - женщина, 1 - мужчина, 2 - неизвестно
        /// </summary>
        [Required]
        [DisplayName("Пол 0 - женщина, 1 - мужчина, 2 - неизвестно")]
        public int Gender { get; set; }

        /// <summary>
        /// Поле даты рождения может быть Null
        /// </summary>
        [MaybeNull]
        [DisplayName("Поле даты рождения может быть Null")]
        public DateTime? Birthday { get; set; } = null;

        /// <summary>
        /// Указание - является ли пользователь админом
        /// </summary>
        [Required]
        [DisplayName("Указание - является ли пользователь админом")]
        public bool Admin { get; set; }
    }
}

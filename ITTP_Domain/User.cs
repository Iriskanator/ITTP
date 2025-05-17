using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ITTP_Domain
{
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        [Key]
        [Required]
        [DisplayName("Уникальный идентификатор пользователя")]
        public Guid Guid { get; set; }

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
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Указание - является ли пользователь админом
        /// </summary>
        [Required]
        [DisplayName("Указание - является ли пользователь админом")]
        public bool Admin { get; set; }

        /// <summary>
        /// Дата создания пользователя
        /// </summary>
        [Required]
        [DisplayName("Дата создания пользователя")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Логин Пользователя, от имени которого этот пользователь создан
        /// </summary>
        [Required]
        [DisplayName("Логин Пользователя, от имени которого этот пользователь создан")]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Дата изменения пользователя
        /// </summary>
        [Required]
        [DisplayName("Дата изменения пользователя")]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Логин Пользователя, от имени которого этот пользователь изменён
        /// </summary>
        [Required]
        [DisplayName("Логин Пользователя, от имени которого этот пользователь изменён")]
        public string ModifiedBy { get; set; } = string.Empty;

        /// <summary>
        /// Дата удаления пользователя
        /// </summary>
        [MaybeNull]
        [DisplayName("Дата удаления пользователя")]
        public DateTime? RevokedOn { get; set; } = null;

        /// <summary>
        /// Логин Пользователя, от имени которого этот пользователь удалён
        /// </summary>
        [Required]
        [DisplayName("Логин Пользователя, от имени которого этот пользователь удалён")]
        public string RevokedBy { get; set; } = string.Empty;
    }
}

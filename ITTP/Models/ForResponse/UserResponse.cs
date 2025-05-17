using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using ITTP_Domain;

namespace ITTP.Models.ForResponse
{
    public class UserResponse
    {
        public UserResponse(User user)
        {
            this.Name = user.Name;
            this.Gender = user.Gender;
            this.Birthday = user.Birthday;
            this.IsActive = user.RevokedOn == null;
        }

        /// <summary>
        /// Имя
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
        /// Поле даты рождения
        /// </summary>
        [MaybeNull]
        [DisplayName("Поле даты рождения может быть Null")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Активный
        /// </summary>
        [MaybeNull]
        [DisplayName("Активный")]
        public bool IsActive { get; set; }
    }
}

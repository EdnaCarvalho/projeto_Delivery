using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Usuario : Pessoa
    {
        #region Atributos

        private Boolean isAdmin;

        #endregion

        #region Propriedades

        [Required]
        [Display(Name = "Administrador")]
        public Boolean IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        #endregion


    }
}

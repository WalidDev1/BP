//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projet_Transport.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class trajet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trajet()
        {
            this.reservations = new HashSet<reservation>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_ville_depart { get; set; }
        public Nullable<int> id_ville_arrive { get; set; }
        public Nullable<System.DateTime> Date_depart { get; set; }
        public Nullable<System.DateTime> Date_arrive { get; set; }
        public Nullable<int> idCar { get; set; }
        public decimal prix { get; set; }
    
        public virtual car car { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservation> reservations { get; set; }
        public virtual ville ville { get; set; }
        public virtual ville ville1 { get; set; }
    }
}

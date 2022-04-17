using System;
namespace LibraryManager.BLL
{
    public class DVD : Item
    {

        public String director { get; set; }
        public String nationality { get; set; }
        public DateTime birthDate { get; set; }

        public DVD(String title, int barcode, String director, String nationality, DateTime birthDate) : base(title, barcode)
        {
            this.director = director;
            this.nationality = nationality;
            this.birthDate = birthDate;
        }
    }
}

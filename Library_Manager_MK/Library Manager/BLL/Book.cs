using System;
namespace LibraryManager.BLL
{
    public class Book : Item
    {

        public String author { get; set; }
        public String ISBN { get; set; }
        public String nationality { get; set; }
        public DateTime birthDate { get; set; }

        public Book(String title, int barcode, String ISBN, String author, String nationality, DateTime birthDate):base(title,barcode)
        {
            this.ISBN = ISBN;
            this.author = author;
            this.nationality = nationality;
            this.birthDate = birthDate;
        }
    }
}

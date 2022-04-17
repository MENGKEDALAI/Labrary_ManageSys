using System;
using System.Collections.Generic;

namespace LibraryManager.BLL
{
    public sealed class DVDStore : ItemSearch<DVD>
    {
        public List<DVD> DVDs { get; set; }

        private static readonly DVDStore instance = new DVDStore();

        static DVDStore()
        {

        }

        private DVDStore()
        {
            DVDs = new List<DVD>();
        }

        public static DVDStore Instance
        {
            get
            {
                return instance;
            }
        }

        public List<DVD> SearchByBarcode(int barcode)
        {
            throw new NotImplementedException();
        }

        public List<DVD> SearchByTitle(string title)
        {
            throw new NotImplementedException();
        }

        List<DVD> SearchDVDByDirector(string director)
        {
            return DVDs.FindAll(i => i.director == director);
        }
        public List<DVD> SearchByAuthorNationality(String nation)
        {
            return DVDs.FindAll(i => i.nationality == nation);
        }

        public List<DVD> SearchByAuthorBirth(DateTime birthDate)
        {
            return DVDs.FindAll(i => i.birthDate == birthDate);
        }
        public void AddNewDVD(String title, int barcode, String director, String nationality, DateTime birthDate)
        {
            if (!DVDs.Exists(i => i.barcode == barcode))
            {
                DVD dvd = new DVD(title, barcode, director, nationality, birthDate);
                DVDs.Add(dvd);
            }
        }

        public void RemoveDVD(DVD dvd)
        {
            if (DVDs.Contains(dvd))
            {
                _ = DVDs.Remove(dvd);
            }
        }
    }
}

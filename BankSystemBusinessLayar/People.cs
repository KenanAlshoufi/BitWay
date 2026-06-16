using BankSystemDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBusinessLayar
{
    public class People
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gendor { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Nationality{ get; set; }

        private string _PersonPhoto;
        public string PersonPhoto
        { get { return _PersonPhoto; } set { _PersonPhoto = value; } }

        public Countries InfoCountries;

        public string FullName { get; set; }

        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        public People()
        {
            PersonID = 0;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gendor = 0;
            Phone = "";
            Email = "";
            Nationality = 0;
            PersonPhoto = "";
            Mode = enMode.AddNew;
        }
        private People(int personID, string nationalNo, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateOfBirth, short gendor, string phone,
            string email, int nationality, string PersonPhoto)
        {
            this.PersonID = personID;
            this.NationalNo = nationalNo;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.FullName = firstName + " " + secondName + " " + thirdName + " " + lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gendor = gendor;
            this.Phone = phone;
            this.Email = email;
            this.Nationality = nationality;
            this.PersonPhoto = PersonPhoto;
            this.InfoCountries = Countries.FindCountryByID(Nationality);
            Mode = enMode.Update;
        }

        public static DataTable GetAllPesron()
        {
            return PeopleData.GetAllPerson();
        }

        public bool _AddNewPerson()
        {
            this.PersonID = PeopleData.AddNewPerson(NationalNo, FirstName, SecondName,
             ThirdName, LastName, Gendor,DateOfBirth
            , Phone, Email, Nationality, PersonPhoto);

            return (this.PersonID != -1);
        }

        public bool _UpdatePerosn()
        {
            return (PeopleData.UpdatePerson(PersonID, FirstName, SecondName,
             ThirdName, LastName 
            , Phone, Email, Nationality, PersonPhoto));

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    return (_UpdatePerosn());
                    
            }
            return false;
        }



        public static bool DeletePerson(int PersonID)
        {
            return PeopleData.DeletePerson(PersonID);
        }


        public static bool IsPersonExist(int PersonID)
        {
            return PeopleData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return PeopleData.IsPersonExist(NationalNo);
        }

        public static People FindByPersonID(int PersonID)
        {
            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gendor = 0;
           
            string Phone = "";
            string Email = "";
            int NationalityCountryID = 0;
            string PersonPhoto = "";

            if (PeopleData.FindByPersonID(PersonID, ref NationalNo, ref FirstName, ref SecondName,
           ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor
            , ref Phone, ref Email, ref NationalityCountryID, ref PersonPhoto))
            {
                return new People(PersonID, NationalNo, FirstName, SecondName,
            ThirdName, LastName, DateOfBirth, Gendor
            , Phone, Email, NationalityCountryID, PersonPhoto);
            }
            else
            {
                return null;
            }
        }

        public static People FindByNationalNo(string NationalNo)
        {
            int PersonID = 0;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gendor = 0;
            string Phone = "";
            string Email = "";
            int NationalityCountryID = 0;
            string PersonPhoto = "";

            if (PeopleData.FindByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName,
           ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor
            , ref Phone, ref Email, ref NationalityCountryID, ref PersonPhoto))
            {
                return new People(PersonID, NationalNo, FirstName, SecondName,
            ThirdName, LastName, DateOfBirth, Gendor
            , Phone, Email, NationalityCountryID, PersonPhoto);
            }
            else
            {
                return null;
            }
        }


        public static People FindByEmail(string Email)
        {
            int PersonID = 0;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gendor = 0;
            string Phone = "";
            string NationalNo = "";
            int NationalityCountryID = 0;
            string PersonPhoto = "";

            if (PeopleData.FindByEmail(Email,ref PersonID , ref NationalNo, ref FirstName, ref SecondName,
           ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor
            , ref Phone , ref NationalityCountryID, ref PersonPhoto))
            {
                return new People(PersonID, NationalNo, FirstName, SecondName,
            ThirdName, LastName, DateOfBirth, Gendor
            , Phone, Email, NationalityCountryID, PersonPhoto);
            }
            else
            {
                return null;
            }
        }


    }
}

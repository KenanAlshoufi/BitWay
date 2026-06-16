using BankSystemDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBusinessLayar
{
    public class DocumentationInformation
    {
       
        public int AccountID { get; set; }
        public int DocumentationInformationID { get; set; }
        public string Address { get; set; }
        public string FrontImageoftheID { get; set; }
        public string BackImageoftheID { get; set; }
        public DateTime DocumentationInformationDate { get; set; }
        public bool IsVerified { get; set; }



        public DocumentationInformation()
        {
            AccountID = -1;
            DocumentationInformationID = -1;
            Address = "";
            FrontImageoftheID = "";
            BackImageoftheID = "";
            DocumentationInformationDate = DateTime.Now;
            IsVerified = false;
        }

        private DocumentationInformation(int documentationInformationID, int accountID,  string address,
           string frontImageoftheID, string backImageoftheID, DateTime documentationInformationDate,
           bool isVerified)
        {
            AccountID = accountID;
            DocumentationInformationID = documentationInformationID;
            Address = address;
            FrontImageoftheID = frontImageoftheID;
            BackImageoftheID = backImageoftheID;
            DocumentationInformationDate = documentationInformationDate;
            IsVerified = isVerified;
        }


        public  bool AddNewDocumentationInformation()
        {
            this.DocumentationInformationID = DocumentationInformationData.AddNewDocumentationInformation
                ( AccountID,  Address,  FrontImageoftheID, BackImageoftheID);

            return this.DocumentationInformationID !=-1;
        }


        public static bool IsDocumentationInformationExist(int AccountID)
        {
            return DocumentationInformationData.IsDocumentationInformationExist( AccountID );
        }



        public static DocumentationInformation FindDocumentationInformationByAccountID(int AccountID)
        {
            int DocumentationInformationID = -1;
            string Address = "";
            string FrontImageoftheID = "";
            string BackImageoftheID = "";
            DateTime DocumentationInformationDate = DateTime.Now;
            bool IsVerified = false;

            if (DocumentationInformationData.FindDocumentationInformationByAccountID(AccountID,
                 ref DocumentationInformationID, ref Address,
           ref FrontImageoftheID, ref BackImageoftheID, ref DocumentationInformationDate
           , ref IsVerified))
            {
                return new DocumentationInformation(DocumentationInformationID,AccountID,Address, 
                    FrontImageoftheID, BackImageoftheID, DocumentationInformationDate, IsVerified);
            }

            return null;
        }



    }
}

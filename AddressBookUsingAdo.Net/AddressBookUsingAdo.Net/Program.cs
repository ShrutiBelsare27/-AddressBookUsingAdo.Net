using System;

namespace AddressBookUsingAdo.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookRepo addressBookRepo = new AddressBookRepo();
           
            AddressBookModel addressBookModel = new AddressBookModel();
            addressBookModel.FirstName = "kajol";
            addressBookModel.LastName = "pawar";
            addressBookModel.Address = "rajkaml";
            addressBookModel.City = "akola";
            addressBookModel.State = "Maharashtra";
            addressBookModel.Zip = 444601;
            addressBookModel.PhoneNumber = 9949713160;
            addressBookModel.Email = "kj@gmail.com";
            addressBookModel.AddressBookName= "friend address book";
            addressBookModel.AddressBookType = "Family";
            addressBookRepo.checkConnection();
            addressBookRepo.addNewContactToDataBase(addressBookModel);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactList.Models;

namespace ContactList.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ContactsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Contacts.Any())
            {
                return;   // DB has been seeded
            }

            var Contacts = new Contact[]
            {
                new Contact{FirstMidName="Carson",LastName="Alexander",BirthDate=DateTime.Parse("2005-09-01"),EmailAddress="CAlexander@email.com",PhoneNumber=5558029901,Company="Companya1"},
                new Contact{FirstMidName="Meredith",LastName="Alonso",BirthDate=DateTime.Parse("2002-09-01"),EmailAddress="MAlonso@email.com",PhoneNumber=5558029901,Company="Companya2"},
                new Contact{FirstMidName="Arturo",LastName="Anand",BirthDate=DateTime.Parse("2003-09-01"),EmailAddress="AAnand@email.com",PhoneNumber=5558029901,Company="Companya3"},
                new Contact{FirstMidName="Gytis",LastName="Barzdukas",BirthDate=DateTime.Parse("2002-09-01"),EmailAddress="GBarzdukas@email.com",PhoneNumber=5558029901,Company="Companya4"},
                new Contact{FirstMidName="Yan",LastName="Li",BirthDate=DateTime.Parse("2002-09-01"),EmailAddress="YLi@email.com",PhoneNumber=5558029901,Company="Companya5"},
                new Contact{FirstMidName="Peggy",LastName="Justice",BirthDate=DateTime.Parse("2001-09-01"),EmailAddress="PJustice@email.com",PhoneNumber=5558029901,Company="Companya6"},
                new Contact{FirstMidName="Laura",LastName="Norman",BirthDate=DateTime.Parse("2003-09-01"),EmailAddress="LNorman@email.com",PhoneNumber=5558029901,Company="Companya7"},
                new Contact{FirstMidName="Nino",LastName="Olivetto",BirthDate=DateTime.Parse("2005-09-01"),EmailAddress="NOlivetto@email.com",PhoneNumber=5558029901,Company="Companya8"}
            };
            foreach (Contact c in Contacts)
            {
                context.Contacts.Add(c);
            }
            context.SaveChanges();


        }
    }
}
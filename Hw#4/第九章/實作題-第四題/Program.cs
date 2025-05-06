using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 实作题_第四题
{
    public class Card
    {
        String Name, Occupation, Age, Email;
        PhoneList Phone;
        public Card(String name, String occupation, String age, String email, PhoneList phone)
        {
            //PhoneList Phone = new PhoneList();
            this.Name = name;
            this.Occupation = occupation;
            this.Age = age;
            this.Email = email;
            this.Phone = phone;
        }
        public String GetCard()
        {
            return $"Name: {Name}\nOccupation: {Occupation}\nPhone:\n HomePhone:{Phone.HomePhone}\n BusinessPhone: {Phone.BusinessPhone}\n CellPhone: {Phone.CellPhone}\nAge: {Age}\nEmail: {Email}";
        }
    }
    public class PhoneList
    {
        public String HomePhone { get; set; }
        public String BusinessPhone { get; set; }
        public String CellPhone { get; set; }

        public PhoneList(String homePhone, String businessPhone, String cellPhone)
        {
            this.HomePhone = homePhone;
            this.BusinessPhone = businessPhone;
            this.CellPhone = cellPhone;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] card_data = new string[] { "Name", "Occupation", "Age", "Phone", "Email" };
            String[] data = new string[card_data.Length];
            PhoneList phone = null;

            for (int i = 0; i < card_data.Length; i++)
            {
                Console.Write($"{card_data[i]}:");
                if (card_data[i] == "Phone")
                {
                    Console.Write("\n  Home Phone: ");
                    String home = Console.ReadLine();
                    Console.Write("  Business Phone: ");
                    String business = Console.ReadLine();
                    Console.Write("  Cell Phone: ");
                    String cell = Console.ReadLine();

                    phone = new PhoneList(home, business, cell);
                    continue;
                }
                data[i] = Console.ReadLine();
            }
            Card card = new Card(data[0], data[1], data[2], data[4], phone);
            Console.Write(card.GetCard());
        }
    }
}

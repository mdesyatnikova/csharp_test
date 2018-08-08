using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebArrdessbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmail;
        private string allInfo;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return (Firstname == other.Firstname) && (Lastname == other.Lastname);
        }

        public int GetHachCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + (Firstname + Lastname);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int value = Lastname.CompareTo(other.Lastname);
            if (value == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else return value;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Id { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return null;
            }
            else
            {
                return Regex.Replace(phone, "[ -()]", "") + "\r\n";
            }
        }

        private string TransformContactFild(string element)
        {
            if (element == null || element == "")
            {
                return null;
            }
            else
            {
                if (element  == HomePhone)
                {
                    return ("H: " + element + "\r\n");
                }
                if (element == MobilePhone)
                {
                    return ("M: " + element + "\r\n");
                }
                if (element == WorkPhone)
                {
                    return ("W: " + element + "\r\n");
                }

                else return element + "\r\n";
            }
        }

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (TransformContactFild(Email) +TransformContactFild(Email2) + TransformContactFild(Email3)).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

        public string AllInfo
        {
            get
            {
                if (allInfo != null)
                {
                    return allInfo;
                }
                else
                {
                    return (Firstname + " " + Lastname + "\r\n" + TransformContactFild(Nickname) + TransformContactFild(Address) + "\r\n" + TransformContactFild(HomePhone) + TransformContactFild(MobilePhone) + TransformContactFild(WorkPhone) + "\r\n" + TransformContactFild(Email) + TransformContactFild(Email2) + TransformContactFild(Email3)).Trim();

                }
            }
            set
            {
                allInfo = value;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkAssist.Model
{
    public class DepartmentMember
    {
        int id;
        string name;
        string phoneNumber;
        string email;
        string subCompany;
        string department;
        string group;
        bool isOnJob;
        DateTime? professionStartDate;//入行日期
        DateTime? companyEntryDate;//入职日期
        string workingExperience;//职业经历

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string SubCompany { get => subCompany; set => subCompany = value; }
        public string Department { get => department; set => department = value; }
        public string Group { get => group; set => group = value; }
        public bool IsOnJob { get => isOnJob; set => isOnJob = value; }
        public DateTime? ProfessionStartDate { get => professionStartDate; set => professionStartDate = value; }
        public DateTime? CompanyEntryDate { get => companyEntryDate; set => companyEntryDate = value; }
        public string WorkingExperience { get => workingExperience; set => workingExperience = value; }
    }
}

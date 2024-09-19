namespace Laborororna2
{
    public class CompanyData
    {
        public Dictionary<string, Company> Company { get; set; }

        public string maxEmployeers()
        {
            int emplaoyerrs = 0;
            string nameCompany = "";
            foreach(var company in Company.Values)
            {
                if(company.Employees > emplaoyerrs)
                {
                    emplaoyerrs = company.Employees;
                    nameCompany = company.NameCompany;
                }
            }
            return $"Max employeers have company {nameCompany} - {emplaoyerrs}";
        }
        public override string? ToString()
        {
            string? infoCompany = "";
            foreach(var company in Company.Values)
            {
                infoCompany += company.ToString() + "\n";
            }
            return infoCompany;
        }
    }

    public class Company
    {
        public string NameCompany { get; set; } = "";
        public int Employees { get; set; } = 0;

        public string CompanyActivists { get; set; } = "";

        public string Salary { get; set; } = "";
        public override string? ToString()
        {
            return $"Company class {NameCompany} - {Employees} -" +
                $" {CompanyActivists} - {Salary}";
        }
    }

       public class CompanyINI
            {
       public Company? Apple { get; set; }
        public Company? Google { get; set; }
        public Company? Microsoft { get; set; }

        public string MaxSalary()
            {
                List<Company> listCompany = new List<Company> { Apple, Google, Microsoft};         
                int maxSalary = listCompany.Max(e => e.Employees);
                return $" Max employerrs - {listCompany.Last(e => e.Employees == maxSalary).ToString()}";
            }
        public override string ToString()
        {
        return $"Apple: {Apple}, \nGoogle: {Google}, \nMicrosoft: {Microsoft}";
            }
        }

    public class AboutMe
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public List<string> Lang { get; set; }

        public override string ToString()
        {
            return $"name - {Name}\nage - {Age}\nCountry - {Country}\nLanguage: \n{String.Join("\n", Lang)}";
        }
    }
}

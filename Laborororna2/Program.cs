namespace Laborororna2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            builder.Configuration.AddJsonFile("companyJSON.json").AddXmlFile("companyXML.xml").AddIniFile("companyINI.ini").AddJsonFile("aboutME.json");
            
            var companyDataJSON = new CompanyData();
            app.Configuration.Bind("companyJSON", companyDataJSON);
            var companyDataXML = new CompanyData();
            app.Configuration.Bind("companyXML", companyDataXML);
            var companyDataINI = new CompanyINI();
            app.Configuration.Bind(companyDataINI);
            var aboutME = new AboutMe();
            app.Configuration.Bind(aboutME);


            app.MapGet("/json", () => $"JSON\n {companyDataJSON.ToString()} \n{companyDataJSON.maxEmployeers()}");
            app.MapGet("/xml", () => $"XNL\n {companyDataXML.ToString()} \n {companyDataXML.maxEmployeers()}");
            app.MapGet("/ini", () => $"INI\n {companyDataINI.ToString()} \n {companyDataINI.MaxSalary()}");
            app.MapGet("/me", () => aboutME.ToString()  );
            app.MapGet("/", () => "/json -> info about file JSON\n" +
            "/xml -> info about fils XML\n" +
            "/ini -> info about file INI\n" +
            "/me -> info about me");
            app.Run();
        }
    }
}

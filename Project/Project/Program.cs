using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using static CVSVIEWMODEL;

public class CVSVIEWMODEL
{
    public static int ID;
    public static string DI=ID.ToString();
    public string Xml { get; set; }

    public WCV Poco { get; set; }

    public CVSVIEWMODEL()
    {
        Xml = Serialize(new WCV());

        Poco = (WCV)Deserialize(Xml, typeof(WCV));
    }


    [XmlRoot(ElementName = "CVS")]
    public class WCV
    {
        [XmlAttribute(AttributeName = "CVs")]
        public int GrandTotal { get; set; }

        [XmlElement(ElementName = "CV")]
        public string job { get; set; }
        public string school { get; set; }
        public int uniScore { get; set; }
        public string[] companiesWorkedAt { get; set; }
        public string jobStartDate { get; set; }
        public string jobEndDate { get; set; }
        public string[] skills { get; set; }
        public bool doesHaveLicense { get; set; }
        public string GITLINK { get; set; }
        public string LINKEDIN { get; set; }
            public WCV(string jb, string sch, int uniS, string[] compWA, string jobSD, string jobED, string[] skl, bool dHL
                , string GIT, string LINKED)
            {
                job = jb;
                school = sch;
                uniScore = uniS;
                foreach (string items in compWA)
                {
                    companiesWorkedAt = compWA;
                }
                jobStartDate = jobSD;
                jobEndDate = jobED;
                foreach (string items in skl)
                {
                    skills = skl;
                }
                doesHaveLicense = dHL;
                GITLINK = GIT;
                LINKEDIN = LINKED;
            }
        public WCV()
        {
            job = "Lawyer";
            school = "Hogwarts";
            uniScore = 600;
            companiesWorkedAt= new string[3] { "Warner Bros", "Apple", "Microsoft" }; 
            jobStartDate = "2007";
            jobEndDate = "2098";
            skills = new string[3] { "Eating", "Sleeping", "Yelling" };
            doesHaveLicense = false;
            GITLINK = "git.com/lawyerguy";
            LINKEDIN = "linkedin.com/lawyerguy";
        }
        public void CreateACV()
        {
            Console.WriteLine("Please enter what do you work as");
            job = Console.ReadLine();
            Console.WriteLine("Ok, now which school did you study at?");
            school = Console.ReadLine();
            Console.WriteLine("Understandable,what score did you get at Universe?");
            uniScore = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many companies have you worked at before?");
            int companyCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < companyCount; i++)
            {
                companiesWorkedAt[i] = Console.ReadLine();
            }
            Console.WriteLine("Amazing! now when was the year you started working in this industry?");
            jobStartDate = Console.ReadLine();
            Console.WriteLine("Remarkable! but could you please write down the year you quit this job");
            jobEndDate = Console.ReadLine();
            Console.WriteLine("Fabulous! now tell me do you have a license?? (1- Yes I do\t\t\t2- No I do not");
            int licenceagreement = Convert.ToInt32(Console.ReadLine());
            if (licenceagreement == 1)
            {
                doesHaveLicense = true;
            }
            else if (licenceagreement == 2)
            {
                doesHaveLicense = false;
            }
            Console.WriteLine("oh cool!and also, do you have a Linkedin? (1- Yes I do\t\t\t2- No I do not");
            int linkedagreement = Convert.ToInt32(Console.ReadLine());
            if (linkedagreement == 1)
            {
                LINKEDIN = Console.ReadLine();
            }
            Console.WriteLine("So awesomw!so do you possibly use Github? (1- Yes I do\t\t\t2- No I do not");
            int gitagreement = Convert.ToInt32(Console.ReadLine());
            if (gitagreement == 1)
            {
                GITLINK = Console.ReadLine();
            }
            Console.WriteLine("Wonderful! Thank you for Cooperating we hope to see you again next time! Goodbye!!");

        }
    }
    
    private string Serialize(object obj)
    {
        var serializer = new XmlSerializer(obj.GetType());

        using (var stringWriter = new StringWriter())
        {
            serializer.Serialize(stringWriter, obj);
            return stringWriter.ToString();
        }
    }

    private object Deserialize(string serializedObj, Type type)
    {
        var serializer = new XmlSerializer(type);

        using (var stringReader = new StringReader(serializedObj))
        using (var xmlTextReader = new XmlTextReader(stringReader))
        {
            return serializer.Deserialize(xmlTextReader);
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
    }
}
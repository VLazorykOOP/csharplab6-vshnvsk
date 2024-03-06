namespace Task1
{
    public interface User
    {
        void Show();
    }

    public interface Net
    {
        void Connect();
    }

    public abstract class Organization : User
    {
        protected string name;
        protected string address;

        public Organization(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Organization: \t\t{name} \nAddress: \t\t{address}");
        }
    }

    public class InsuranceCompany : Organization, User
    {
        protected string insuranceType;

        public InsuranceCompany(string name, string address, string insuranceType) : base(name, address)
        {
            this.insuranceType = insuranceType;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Type of insurance: \t{insuranceType}");
        }
    }

    public class OilCompany : Organization, User
    {
        protected string specialization;

        public OilCompany(string name, string address, string specialization) : base(name, address)
        {
            this.specialization = specialization;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Specialization: \t{specialization}");
        }
    }

    public class Factory : Organization, User, Net
    {
        protected string productType;

        public Factory(string name, string address, string productType) : base(name, address)
        {
            this.productType = productType;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Type of product: \t{productType}");
        }

        public void Connect()
        {
            Console.WriteLine("Factory connected to the network");
        }
    }

    class Program
    {
        public static void Main_Task1()
        {
            User[] organizations = new User[]
            {
                new InsuranceCompany("Страхова Компанiя 1", "Адреса 1", "Автострахування"),
                new OilCompany("Нафтогазова Компанiя 1", "Адреса 2", "Видобуток нафти та газу"),
                new Factory("Завод 1", "Адреса 3", "Електронiка"),
                new InsuranceCompany("Страхова Компанiя 2", "Адреса 4", "Медичне страхування"),
                new Factory("Завод 2", "Адреса 5", "Машинобудування")
            };

            Console.WriteLine("\nArray of organizations: \n");
            foreach (Organization org in organizations)
            {
                org.Show();
                Console.WriteLine();
            }
        }
    }
}

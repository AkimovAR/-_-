using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace motoStore.Entities
{
   public class Employee_E :E_Notifier
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;

            }
        }
        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value;
                OnPropertyChanged("Surname");
            }
        }     
        private string post;
        public string Post
        {
            get { return post; }
            set { post = value;
                OnPropertyChanged("Post");
            }
        }
        private string empphonenumber;
        public string Empphonenumber
        {
            get { return empphonenumber; }
            set { empphonenumber = value;
                OnPropertyChanged("Empphonenumber");
            }
        }
        private string empaddress;
        public string Empaddress
        {
            get { return empaddress; }
            set { empaddress = value;
                OnPropertyChanged("Empaddress");
            }
        }
        private string emppassport;
        public string Emppassport
        {
            get { return emppassport; }
            set { emppassport = value;
                OnPropertyChanged("Emppassport");
            }
        }
        private string account;
        public string Account
        {
            get { return account; }
            set
            {
                account = value;
                OnPropertyChanged("Account");
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value;
                OnPropertyChanged("Email");
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value;
                OnPropertyChanged("Password");
            }
        }
        private string salary;
        public string Salary
        {
            get { return salary; }
            set { salary = value;
                OnPropertyChanged("Salary");
            }
        }
        private int motoshop_code;
        public int Motoshop_code
        {
            get { return motoshop_code; }
            set
            {
                motoshop_code = value;
                OnPropertyChanged("Motoshop_code");
            }
        }
        private string motoshop_name;
        public string Motoshop_name
        {
            get { return motoshop_name; }
            set
            {
                motoshop_name = value;
                OnPropertyChanged("Motoshop_name");
            }
        }
        private ObservableCollection<Employee_E> employee_list;
        public ObservableCollection<Employee_E> Employee_list
        {
            get
            {
                return employee_list;
            }
            set
            {
                employee_list = value;
                OnPropertyChanged("Employee_list");
            }
        }
        private void EmployeeModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Employee_list");
        }
    }
}

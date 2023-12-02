using Project_4.Models;
using System.Text.RegularExpressions;

namespace Project_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Contex _contex = new Contex();
                Console.WriteLine("Plese Eneter 1 For Login And 2 For Signup.");
                int entryOption;
                int.TryParse(Console.ReadLine(), out entryOption);
                switch (entryOption)
                {
                    case 1:
                        Login(_contex);
                        break;
                    case 2:
                        SignUp(_contex);
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Login(Contex _contex)
        {
            try
            {
                Console.WriteLine("Plese Enter Your Email or Phone.");
                string loginCredential = Console.ReadLine();
                var firstLetter = loginCredential.First();
                var isUserExist = _contex.User.Where(x => x.IsDeleted == false)
                                              .Any(x => x.Email == loginCredential || x.Phone == loginCredential);
                if (isUserExist)
                {
                    var user = _contex.User.Where(x => x.Email == loginCredential || x.Phone == loginCredential).First();
                    var isAdmin = user.IsAdmin;
                    if (isAdmin)
                    {
                        bool isHavingPassword = user.Password == string.Empty;
                        if(!isHavingPassword)
                        {
                            Console.WriteLine("Plese Enter your Password");
                            string password = Console.ReadLine();
                            bool isPasswordMatching = user.Password == password;
                            if (isPasswordMatching)
                            {
                                Console.WriteLine($"Welcome To RamaRao Vehicles {user.UserName}");
                                AdminDashboard.AdminDashboardPage();
                            }
                            else 
                            {
                                Console.WriteLine("Invalid Password please try again.");
                                Login(_contex);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Plese Enter your Password to set.");
                            user.Password = Console.ReadLine();
                            _contex.Update(user);
                            _contex.SaveChanges();
                            Console.WriteLine($"Your Password saved sucessfully.\nWelcome To RamaRao Vehicles {user.UserName}");
                            AdminDashboard.AdminDashboardPage();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Plese Enter your Password");
                        string password = Console.ReadLine();
                        bool isPasswordMatching = user.Password == password;
                        if (isPasswordMatching)
                        {
                            Console.WriteLine($"Welcome To RamaRao Vehicles {user.UserName}");
                            UserDashboard.Home(user);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Password please try again.");
                            Login(_contex);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The Email or Phone you have Entered is does not belong to any account plese Signup.");
                    SignUp(_contex);
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void SignUp(Contex _contex)
        {
            try
            {
                User user = new User();
                Console.WriteLine("Enter UserName:");
                user.UserName = Console.ReadLine();
                Console.WriteLine("Enter Email:");
                string email = Console.ReadLine();
                IsValidEmail(email, user);
                Console.WriteLine("Enter Phone:");
                string phone = Console.ReadLine();
                IsValidPhoneNumber(phone, user);
                Console.WriteLine("Enter Password");
                user.Password = Console.ReadLine();
                Console.WriteLine("Enter LicenceNo");
                user.LicenceNo = Console.ReadLine();
                Console.WriteLine("Select User Type; \n1.Gold\n2.Silver\n3.Platinum");
                int userType;
                int.TryParse(Console.ReadLine(), out userType);
                user.UserTypeId = userType;
                _contex.Add(user);
                _contex.SaveChanges();
                Console.WriteLine("SignUp sucessfull.");
                UserDashboard.Home(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        public static void IsValidEmail(string email, User user)
        {
            try
            {
                string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
                if (Regex.IsMatch(email, emailPattern))
                {
                    user.Email = email;
                    return;
                }
                else
                {
                    Console.WriteLine("Please Enter a valid Email:");
                    email = Console.ReadLine();
                    IsValidEmail(email, user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        public static void IsValidPhoneNumber(string phoneNumber, User user)
        {
            try
            {
                string localMobilePattern = @"^[0-9]{6,15}$";
                if (Regex.IsMatch(phoneNumber, localMobilePattern))
                {
                    user.Phone = phoneNumber;
                    return;
                }
                else
                {
                    Console.WriteLine("Please Enter a valid Phone:");
                    phoneNumber = Console.ReadLine();
                    IsValidPhoneNumber(phoneNumber, user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException);
            }
        }
    }
}

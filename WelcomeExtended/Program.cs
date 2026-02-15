using Microsoft.Extensions.Logging;
using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserData userData = new UserData();
                User studentUser = new User()
                {
                    Names = "student",
                    Email = "student@tu-sofia.bg",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT
                };
                User studentUser2 = new User()
                {
                    Names = "student2",
                    Email = "student2@tu-sofia.bg",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT
                };
                User teacherUser = new User()
                {
                    Names = "teacher",
                    Email = "teacher@tu-sofia.bg",
                    Password = "1234",
                    Role = UserRolesEnum.PROFESSOR
                };
                User adminUser = new User()
                {
                    Names = "admin",
                    Email = "admin@tu-sofia.bg",
                    Password = "12345",
                    Role = UserRolesEnum.ADMIN
                };
                userData.addUser(studentUser);
                userData.addUser(studentUser2);
                userData.addUser(teacherUser);
                userData.addUser(adminUser);

                Console.WriteLine("Enter name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();
                
                if(UserDataHelper.ValidateCredentials(userData, name, password))
                {
                    UserHelper.ToUserString(UserDataHelper.GetUser(userData, name, password));
                    SuccesssfulLoginFileLogger successsfulLogin = new SuccesssfulLoginFileLogger("loggingLog.txt");
                    successsfulLogin.Log(name);
                }
                else
                {
                    throw new ArgumentException("User with such credentials does not exist!");
                }

            }
            catch (Exception ex)
            {
                ErrorFileLogger errorFileLogger = new ErrorFileLogger("errorsLog.txt");
                var log = new ActionOnError(Delegates.Log);
                log += errorFileLogger.Log;
                log(ex.Message);
            }
            finally
            {
                //var hashLogger = new HashLogger("MainLogger");
                //var showAllMessages = new ShowAllMessages(hashLogger.printLogMessages);
                //showAllMessages();
                //hashLogger.printLogMessagesById(new EventId(1));
                //hashLogger.DeleteLogMessageById(new EventId(0));
                //showAllMessages();
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}

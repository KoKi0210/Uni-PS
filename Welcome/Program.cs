using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;
using Welcome.View;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Names = "Zdravko Milkov";
            user.Email = "zmilkov@tu-sofia.bg";
            user.Role = UserRolesEnum.STUDENT;

            UserViewModel userViewModel = new UserViewModel(user);

            UserView userView = new UserView(userViewModel);

            userView.Display();
        }
    }
}

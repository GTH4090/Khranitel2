using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using static KhranitelProDesktop.Classes.Helper;
using KhranitelProDesktop.Models;


namespace KhranitelProDesktop.Pages;

public partial class Registration : UserControl
{
    public Registration()
    {
        InitializeComponent();
    }

    
    private void RegBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        string nums = "1234567890";
        string LLet = "qwertyuiopasdfghjklzxcvbnm";
        string ULet = LLet.ToUpper();
        string spec = "!@#$%^&*()";

        if (PasswordTbx.Text.Intersect(nums).Count() != 0 && PasswordTbx.Text.Intersect(LLet).Count() != 0 &&
            PasswordTbx.Text.Intersect(ULet).Count() != 0 && PasswordTbx.Text.Intersect(spec).Count() != 0 && 
            PasswordTbx.Text.Length >6 && PasswordTbx.Text == Password2Tbx.Text && Db.Users
                .FirstOrDefault(el => el.Login == LoginTbx.Text) == null)
        {
            try
            {
                User user = new User();
                user.Login = LoginTbx.Text;
                user.Password = BCrypt.Net.BCrypt.HashPassword(PasswordTbx.Text);
                Db.Users.Add(user);
                Db.SaveChanges();
                Navigationn.Content = new Auth();
            }
            catch (Exception exception)
            {
                Error();
            }
        }
    }
}
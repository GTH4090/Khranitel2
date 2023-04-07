using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using KhranitelProDesktop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static KhranitelProDesktop.Classes.Helper;

namespace KhranitelProDesktop.Pages;

public partial class Auth : UserControl
{
    public Auth()
    {
        InitializeComponent();
    }

    
    private void PasCb_OnChecked(object? sender, RoutedEventArgs e)
    {
        PasswordTbx.PasswordChar = '\0';
    }

    private void PasCb_OnUnchecked(object? sender, RoutedEventArgs e)
    {
        PasswordTbx.PasswordChar = '*';
    }

    private void LoginBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Db.Users.FirstOrDefault(el =>
                el.Login == LoginTbx.Text) != null)
        {
            User user = Db.Users.FirstOrDefault(el => el.Login == LoginTbx.Text) as User;

            if (BCrypt.Net.BCrypt.Verify(PasswordTbx.Text, user.Password))
            {
                Navigationn.Content = new MainMenu(user.Id);
            }
            
        }
    }

    private void RegBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new Registration();
    }
}
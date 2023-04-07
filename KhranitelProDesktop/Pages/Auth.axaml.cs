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

    
    

    private void LoginBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Db.Employees.FirstOrDefault(el =>
                el.Code == LoginTbx.Text) != null)
        {
            

            Navigationn.Content = new MainMenu();
        
            
        }
    }

    
}
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using static KhranitelProDesktop.Classes.Helper;
using KhranitelProDesktop.Models;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
using Microsoft.EntityFrameworkCore;

namespace KhranitelProDesktop.Pages;

public partial class OrderEdit : Window
{
    private int _id;
    public OrderEdit(int id)
    {
        _id = id;
        InitializeComponent();
        DivisionCbx.Items = Db.Divisions.ToList();
        NameCbx.Items = Db.Employees.ToList();
        StatusCbx.Items = Db.Visitstatuses.ToList();
        TargetCbx.Items = Db.Visittargets.ToList();

        VisitGrid.DataContext = Db.Visits.Include(el => el.Visitors).FirstOrDefault(el => el.Id == id);
        
        VisitorGrid.DataContext = (VisitGrid.DataContext as Visit).Visitors.ToList()[0];

        DateDp.DisplayDateStart = (VisitGrid.DataContext as Visit).Startdate;
        DateDp.DisplayDateEnd = (VisitGrid.DataContext as Visit).Enddate;
        if ((VisitorGrid.DataContext as Visitor).Photo != null)
        {
            MemoryStream stream = new MemoryStream((VisitorGrid.DataContext as Visitor).Photo);
            UserImg.Source = new Bitmap(stream);
        }
        

        if ((VisitorGrid.DataContext as Visitor).Isbanned)
        {
            MessageBoxManager.GetMessageBoxStandardWindow("Внимание!", "Этот пользователь в чёрном списке",
                ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Warning).ShowDialog(Win);
            StatusCbx.IsEnabled = false;
            StatusCbx.SelectedIndex = 3;
            TimeTp.IsEnabled = false;
            DateDp.IsEnabled = false;
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandardWindow("Внимание!", "Этот пользователь не в чёрном списке",
                ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Warning).ShowDialog(Win);
        }
    }

    public OrderEdit()
    {
        
    }

    

    private void ClearBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    private void OkBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Db.SaveChanges();
        Close();
    }
}
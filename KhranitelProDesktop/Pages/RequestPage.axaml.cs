using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Dialogs;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Skia;
using KhranitelProDesktop.Models;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
using static KhranitelProDesktop.Classes.Helper;

namespace KhranitelProDesktop.Pages;

public partial class RequestPage : UserControl
{
    private void LoadCbx()
    {
        TargetCbx.Items = Db.Visittargets.ToList();
        DivisionCbx.Items = Db.Divisions.ToList();
        
        
        
        FromDp.DisplayDateStart = DateTime.Now.AddDays(1);
        FromDp.DisplayDateEnd = DateTime.Now.AddDays(15);
        ToDp.DisplayDateEnd = DateTime.Now.AddDays(15);
        
        BirthDp.DisplayDateEnd = DateTime.Now.AddYears(-16);
    }

    private int _id;
    public RequestPage(int id)
    {
        _id = id;
        InitializeComponent();
        LoadCbx();

        Visit visit = new Visit();
        Visitor visitor = new Visitor();
        VisitGrid.DataContext = visit;
        VisitorGrid.DataContext = visitor;
        DivisionCbx.SelectedIndex = 0;
        TargetCbx.SelectedIndex = 0;
        FromDp.SelectedDate = DateTime.Now.AddDays(1);
        ToDp.SelectedDate = DateTime.Now.AddDays(1);
        BirthDp.SelectedDate = DateTime.Now.AddYears(-16);
        if (id != -1)
        {
            (VisitGrid.DataContext as Visit).Userid = id;
        }
        
        (VisitGrid.DataContext as Visit).Typeid = 1;
        (VisitGrid.DataContext as Visit).Statusid = 1;
    }

    public RequestPage()
    {
        
    }


    private void DivisionCbx_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var item = DivisionCbx.SelectedItem as Division;
        NameCbx.Items = Db.Employees.Where(el => el.Divisionid == item.Id).ToList();
        NameCbx.SelectedIndex = 0;
    }

    private void FromDp_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        ToDp.DisplayDateStart = FromDp.SelectedDate;
    }

    private async void  DocsBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        OpenFileDialog file = new OpenFileDialog();
        file.AllowMultiple = false;
        file.Filters = new List<FileDialogFilter>()
        {
            new FileDialogFilter(){Name = "Pdf", Extensions = new List<string>(){"pdf"}}
        };
        var res = await file.ShowAsync(Win);
        if (res.Count() != 0)
        {
            (VisitorGrid.DataContext as Visitor).Passportscan = File.ReadAllBytes(res[0]);
        }
        



    }

    private async void ImageBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        OpenFileDialog file = new OpenFileDialog();
        file.AllowMultiple = false;
        file.Filters = new List<FileDialogFilter>()
        {
            new FileDialogFilter(){Name = "Jpg", Extensions = new List<string>(){"jpg"}}
        };
        var res = await file.ShowAsync(Win);
        if (res.Count() != 0)
        {
            MemoryStream stream = new MemoryStream(File.ReadAllBytes(res[0]));
            Bitmap bit = new Bitmap(stream);
            if (bit.Size.Width * 3 == bit.Size.Height * 4 && stream.Length <= 4 * 1024 * 1024)
            {
                (VisitorGrid.DataContext as Visitor).Photo = File.ReadAllBytes(res[0]);
            }
            
            
            
            UserImg.Source = bit;
            

        }
        
    }

    private void OkBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {

            if (EmailTbx.Text[0] != '@' && EmailTbx.Text[^1] != '@' && EmailTbx.Text.Count(el => el == '@') == 1)
            {
                Db.Visits.Add(VisitGrid.DataContext as Visit);
                Db.SaveChanges();
                (VisitorGrid.DataContext as Visitor).Visitid = (VisitGrid.DataContext as Visit).Id;
                Db.Visitors.Add(VisitorGrid.DataContext as Visitor);
                Db.SaveChanges();
                Navigationn.Content = new MainMenu(_id);
            }
            else
            {
                MessageBoxManager
                    .GetMessageBoxStandardWindow("Внимание", "Вы ввели чё-то не так", ButtonEnum.Ok, Icon.Info)
                    .ShowDialog(Win);
            }
                
            
            
        }
        catch (Exception exception)
        {
            Error();
        }
    }
}
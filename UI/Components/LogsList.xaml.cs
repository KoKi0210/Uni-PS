using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using DataLayer.Database;

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for LogsList.xaml
    /// </summary>
    public partial class LogsList : UserControl
    {
        public LogsList()
        {
            InitializeComponent();

            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                var records = context.Logs.ToList();
                logs.ItemsSource = records;
            }
        }
    }
}

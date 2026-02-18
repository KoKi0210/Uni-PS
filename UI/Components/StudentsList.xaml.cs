using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using DataLayer.Database;

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for StudentsList.xaml
    /// </summary>
    public partial class StudentsList : UserControl
    {
        public StudentsList()
        {
            InitializeComponent();
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                var records = context.Users.ToList();
                students.DataContext = records;
            }
        }
    }
}

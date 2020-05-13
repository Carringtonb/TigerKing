using System;
using System.Collections.Generic;
using System.IO;
using TigerKingApp.Models;
using Xamarin.Forms;
using System.Linq;


namespace TigerKingApp
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

      
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notes = new List<Note>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
            foreach (var filename in files)
            {
                notes.Add(new Note
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }

        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e) { 
            await Navigation.PushAsync(new NotesPage
            {
                BindingContext = new Note()
            });
        }
    }
}

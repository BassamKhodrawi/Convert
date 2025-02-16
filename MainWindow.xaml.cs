using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using Konventierung.Properties;

namespace Konventierung
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Laden des gespeicherten Werts
            tbxVariable.Text = Settings.Default.VariableName;
        }

        private void tbxVariable_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Speichern des Werts, wenn sich der Text ändert
            Settings.Default.VariableName = tbxVariable.Text;
            Settings.Default.Save();
        }

        private void btnLöschenBearbeiten_Click(object sender, RoutedEventArgs e)
        {
            tbxBearbeiten.Clear();
        }

        private void btnLöschenVerarbeitete_Click(object sender, RoutedEventArgs e)
        {
            tbxVerarbeitete.Clear();
        }

        private void btnKopierenBearbeiten_Click(object sender, RoutedEventArgs e)
        {
            string textData = tbxBearbeiten.Text;
            Clipboard.SetData(DataFormats.Text, (Object)textData);
        }

        private void btnKopierenVerarbeitete_Click(object sender, RoutedEventArgs e)
        {
            string textData = tbxVerarbeitete.Text;
            Clipboard.SetData(DataFormats.Text, (Object)textData);
        }

        private void btnKonventieren_Click(object sender, RoutedEventArgs e)
        {
            string variable = tbxVariable.Text;
            string inhalt = tbxBearbeiten.Text;
            string vor = $"Dim {variable} As New System.Text.StringBuilder";
            string[] zeilen = inhalt.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (!tbxBearbeiten.Text.Contains("AppendLine"))
            {
                StringBuilder sb = new StringBuilder();

                foreach (string zeile in zeilen)
                {
                    sb.AppendLine($"{variable}.AppendLine(\"{zeile}\")");
                }

                tbxVerarbeitete.Text = $"{vor}{Environment.NewLine}{sb.ToString()}";
            }
            else
            {
                string[] zeilens = inhalt.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                Regex regex = new Regex("\"([^\"]*)\"");
                string text = String.Empty;
                foreach (string zeile in zeilens)
                {
                    MatchCollection matches = regex.Matches(zeile);

                    foreach (Match match in matches)
                    {
                        text += match.Groups[1].Value + Environment.NewLine;
                    }
                }
                tbxVerarbeitete.Text = text;
            }
        }

        private void btnSortieren_Click(object sender, RoutedEventArgs e)
        {
            string inhalt = tbxBearbeiten.Text;

            string[] zeilen = inhalt.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (chkQuoted.IsChecked != true)
            {
                string ergebnis = string.Join(",", zeilen);

                tbxVerarbeitete.Text = ergebnis;
            }
            else
            {
                string ergebnis = string.Join(",", zeilen.Select(z => $"'{z}'"));

                tbxVerarbeitete.Text = ergebnis;
            }
        }

        private void btnDoppelteLöschen_Click(object sender, RoutedEventArgs e)
        {
            if (tbxBearbeiten.Text.Contains("Select") || tbxBearbeiten.Text.Contains("StringBuilder")) return;

            string[] zeichen = tbxBearbeiten.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string entfernteDoppelte = string.Join(Environment.NewLine, zeichen.Distinct());

            tbxBearbeiten.Text = entfernteDoppelte;
        }

        private void btnPascal_Click(object sender, RoutedEventArgs e)
        {
            string inhalt = tbxBearbeiten.Text;

            bool keineAhnung = inhalt.Contains("*EQ") || inhalt.Contains("*NE") ||
                        inhalt.Contains("*LT") || inhalt.Contains("*GT") ||
                        inhalt.Contains("*GE") || inhalt.Contains("*LE") ||
                        inhalt.Contains("*&lt") || inhalt.Contains("*&gt");

            if (keineAhnung)
            {
                string neuerInhalt = inhalt.Replace("*EQ", "=")
                                           .Replace("*NE", "!=")
                                           .Replace("*LT", "<")
                                           .Replace("*GT", ">")
                                           .Replace("*GE", ">=")
                                           .Replace("*LE", "<=")
                                           .Replace("*&lt", "<")
                                           .Replace("*&gt", ">");

                tbxVerarbeitete.Text = neuerInhalt;
            }

            else
            {
                string neuerInhalt = inhalt.Replace("<>", "!=")
                                            .Replace("<", "*LT")
                                           .Replace("<", "*&lt")
                                           .Replace(">", "*&gt");
                                           






                tbxVerarbeitete.Text = neuerInhalt;
            }
        }

    }
}

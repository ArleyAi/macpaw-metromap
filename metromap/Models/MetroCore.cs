using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace MetroMap.Models
{
    class MetroCore
    {
        private MetroMap Map;

        private Canvas canvasL0;

        private Canvas canvasL1;

        private Canvas canvasL2;

        private MetroStation From;

        private MetroStation To;

        private Label infoLabel;

        /// <summary>
        /// Initialize MetroCore.
        /// </summary>
        /// <param name="filepath">Path to map xml file.</param>
        /// <param name="imagepath">Path to image file.</param>
        /// <param name="canvas">Canvas to work with.</param>
        public void Initialize(string filepath, string imagepath, Canvas canvas)
        {
            //Loading file. (TODO: IO Exception checking)
            using (var stream = File.OpenRead(filepath))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(MetroMap));
                Map = (MetroMap)formatter.Deserialize(stream);
            }

            //Loading background image. (TODO: IO Exception checking)
            canvas.Background = new ImageBrush(new BitmapImage(new Uri(imagepath, UriKind.Relative)));

            //Creating layers.
            canvas.Children.Clear();
            canvasL0 = new Canvas();
            canvas.Children.Add(canvasL0);
            canvasL1 = new Canvas();
            canvas.Children.Add(canvasL1);
            canvasL2 = new Canvas();
            canvas.Children.Add(canvasL2);

            //Drawing Map.
            DrawMap();

            //Adding info label.
            infoLabel = new Label();
            infoLabel.Content = $"Click on stations to build route";
            infoLabel.FontSize = 20;
            infoLabel.Margin = new Thickness(25);
            infoLabel.Padding = new Thickness(5);
            infoLabel.Background = Brushes.White;
            canvas.Children.Add(infoLabel);
        }

        /// <summary>
        /// Draw full map.
        /// </summary>
        public void DrawMap()
        {
            foreach (var line in Map.Lines)
            {
                for (int i = 0; i<line.Stations.Count;i++)
                {
                    if (i + 1 < line.Stations.Count)
                        ConnectStations(line.Stations[i], line.Stations[i + 1], line.Color, canvasL0);
                    DrawStation(line.Stations[i], line.Color, canvasL0);
                }
            }
        }

        /// <summary>
        /// Draw route between two stations.
        /// </summary>
        /// <param name="s1">From station.</param>
        /// <param name="s2">To station.</param>
        public void DrawRoute(MetroStation s1, MetroStation s2)
        {
            canvasL1.Children.Clear();

            var searcher = new RouteSearcher(Map); //Creating searcher instance.

            var info = searcher.FindRoute(s1, s2); //Searching route.

            if (info == null)
            {
                infoLabel.Content = $"Route not found :(";
                return;
            }

            var route = info.Route;

            infoLabel.Content = $"From {s1.Title} to {s2.Title} - {info.Minutes} minutes";

            //Performing drawing.
            for (int i = 0; i < route.Count; i++)
            {
                if (i + 1 < route.Count)
                    ConnectStations(route[i], route[i + 1], "#FFFF9000", canvasL1);
                DrawStation(route[i], "#FFFF9000", canvasL1);
            }

            //Animating.
            AnimateRoute(route);
        }

        /// <summary>
        /// Animate route.
        /// </summary>
        /// <param name="route">List of route stations.</param>
        public void AnimateRoute(List<MetroStation> route)
        {
            //Creating "train"
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 24;
            ellipse.Height = 24;
            ellipse.Margin = new Thickness(route[0].X - 12, route[0].Y - 12, 0, 0);
            ellipse.Fill = Brushes.Black;
            canvasL1.Children.Add(ellipse);

            //Creating animation that travels across each station. (Recoursive).
            ThicknessAnimation animate = new ThicknessAnimation(new Thickness(route[0].X - 12, route[0].Y - 12, 0, 0), TimeSpan.FromMilliseconds(500));
            animate.Completed += (sender, e) => {
                if (route.Count > 0)
                {
                    var first = route.First();
                    animate.To = new Thickness(route[0].X - 12, route[0].Y - 12, 0, 0);
                    ellipse.BeginAnimation(Ellipse.MarginProperty, animate);

                    route.Remove(first);
                }
                else canvasL1.Children.Remove(ellipse);

            };

            ellipse.BeginAnimation(Ellipse.MarginProperty, animate);
            route.Remove(route.First());
        }

        private Ellipse DrawStation(MetroStation station, string color, Canvas c)
        {
            //Creating and configuring ellipse.
            Ellipse ellipse = new Ellipse();
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = (Color)ColorConverter.ConvertFromString(color);
            ellipse.Width = 24;
            ellipse.Height = 24;
            ellipse.Margin = new Thickness(station.X-12, station.Y-12, 0, 0);
            ellipse.Fill = Brushes.White;
            ellipse.StrokeThickness = 3;
            ellipse.Stroke = mySolidColorBrush;
            ellipse.Cursor = Cursors.Hand;
            ellipse.Tag = station;
            ellipse.MouseDown += ellipse_MouseDown; //Click on ellipse event handler attaching.

            Label label = new Label();
            label.Content = station.Title;
            label.Margin = new Thickness(station.X - 12, station.Y - 35, 0, 0);
            label.Background = Brushes.White;
            label.Opacity = 0.5;
            c.Children.Add(label);

            c.Children.Add(ellipse);

            return ellipse;
        }

        private Line ConnectStations(MetroStation station1, MetroStation station2, string color, Canvas c)
        {
            var myLine = new Line();
            myLine.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
            myLine.X1 = station1.X;
            myLine.X2 = station2.X;
            myLine.Y1 = station1.Y;
            myLine.Y2 = station2.Y;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 8;
            c.Children.Add(myLine);

            return myLine;
        }

        private void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var station = (MetroStation)((Ellipse)sender).Tag; //Unbox station from sender tag.

            //Creating stack panel and adding two buttons with click event handlers.

            StackPanel sp = new StackPanel();
            sp.VerticalAlignment = VerticalAlignment.Top;
            sp.HorizontalAlignment = HorizontalAlignment.Left;
            sp.Margin = new Thickness(station.X, station.Y, 0, 0);

            Button buttonFrom = new Button() { Content = "From" };
            buttonFrom.Tag = station;
            buttonFrom.Click += ButtonFrom_Click;
            sp.Children.Add(buttonFrom);

            Button buttonTo = new Button() { Content = "To" };
            buttonTo.Tag = station;
            buttonTo.Click += ButtonTo_Click;
            sp.Children.Add(buttonTo);

            canvasL2.Children.Add(sp); //Adding to 2nd layer.
        }

        private void ButtonTo_Click(object sender, RoutedEventArgs e)
        {
            var station = (MetroStation)((Button)sender).Tag; //Unbox station from sender tag.
            To = station;

            TryBuildRoute();

            canvasL2.Children.Clear();
        }

        private void ButtonFrom_Click(object sender, RoutedEventArgs e)
        {
            var station = (MetroStation)((Button)sender).Tag; //Unbox station from sender tag.
            From = station;

            TryBuildRoute();

            canvasL2.Children.Clear();
        }

        /// <summary>
        /// Try to build route with selected stations.
        /// </summary>
        private void TryBuildRoute()
        {
            if (From != null && To != null)
            {
                if (From == To)
                {
                    infoLabel.Content = $"You are on the taget station. Choose another to get route";
                    canvasL1.Children.Clear();
                    return;
                }
                DrawRoute(From, To);
            }
        }

        #region Singleton

        private static MetroCore instanse;

        public static MetroCore GetInstance()
        {
            if (instanse == null)
                instanse = new MetroCore();

            return instanse;
        }
        #endregion

    }
}

using EngineLineLibrary.Connection;
using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Connection.Enums;
using EngineLineLibrary.Connection.ExternalDependencies;
using EngineLineLibrary.Vehicle;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace EngineLine.Pages
{
    public sealed partial class Connection : Page
    {
        private readonly ConnectionManager connectionManager;

        public Connection()
        {
            this.InitializeComponent();

            var serialPort = new SerialPortWrapper();
            connectionManager = new ConnectionManager(serialPort);

            protocolComboBox.ItemsSource = connectionManager.SupportedProtocols;
            connectionMethodComboBox.ItemsSource = connectionManager.ConnectionMethods;

            serialConnectionOptions.RegisterPropertyChangedCallback(UIElement.VisibilityProperty, SerialConnectionOptions_VisibilityChanged);
        }

        private void SerialConnectionOptions_VisibilityChanged(DependencyObject sender, DependencyProperty dp)
        {
            if (((UIElement)sender).Visibility == Visibility.Visible)
            {
                comPortComboBox.ItemsSource = connectionManager.GetAvailableSerialDevices();
                baudRateComboBox.ItemsSource = connectionManager.BaudRates;
            }
        }

        private void ConnectionMethodComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (connectionMethodComboBox.SelectedValue as string == ConnectionMethod.Serial.ToString())
            {
                serialConnectionOptions.Visibility = Visibility.Visible;
            }
            else if (connectionMethodComboBox.SelectedValue as string == ConnectionMethod.Bluetooth.ToString())
            {
                serialConnectionOptions.Visibility = Visibility.Collapsed;
            }
            else if (connectionMethodComboBox.SelectedValue as string == ConnectionMethod.Wifi.ToString())
            {
                serialConnectionOptions.Visibility = Visibility.Collapsed;
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            IObd2Device device = null;
            try
            {
                if (AreValidSelections())
                {
                    connectProgressRing.IsActive = true;

                    device = CreateConnetionWithDevice();
                    device.InitalizeDevice();

                    ConnectionAccess.QueryManager = new QueryManager(device);

                    this.Frame.Navigate(typeof(MainPage));
                }
                else
                {
                    var title = "Validation";
                    var message = "Please select all the settings and try again";
                    ShowMessageDialog(title, message);
                }
            }
            catch (Exception ex)
            {
                var title = "An Error Occurred!";
                ShowMessageDialog(title, ex.Message);

                device.Disconnect();
                connectProgressRing.IsActive = false;
            }
        }

        private IObd2Device CreateConnetionWithDevice()
        {
            var protocol = protocolComboBox.SelectedIndex;
            var connectionMethod = connectionMethodComboBox.SelectedValue as string;

            IObd2Device device = null;
            if (connectionMethod == ConnectionMethod.Serial.ToString())
            {
                var comPort = comPortComboBox.SelectedValue as string;
                var baudRate = (int)baudRateComboBox.SelectedValue;

                device = connectionManager.CreateSerialConnection(comPort, baudRate, protocol);
            }

            return device;
        }

        private bool AreValidSelections()
        {
            bool valid = true;

            if (protocolComboBox.SelectedIndex == -1 || connectionMethodComboBox.SelectedValue == null)
                valid = false;
            else if (connectionMethodComboBox.SelectedValue as string == ConnectionMethod.Serial.ToString())
            {
                if (comPortComboBox.SelectedValue == null || baudRateComboBox.SelectedValue == null)
                    valid = false;
            }
            else
                valid = false;

            return valid;
        }

        private async void ShowMessageDialog(string title, string message)
        {
            var messageDialog = new ContentDialog()
            {
                XamlRoot = this.XamlRoot,
                Title = title,
                CloseButtonText = "Ok",
                Content = message,
            };
            await messageDialog.ShowAsync();
        }
    }
}
